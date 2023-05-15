// /***************************************************************************\
// Module Name:       ReflectionExtensions.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace Sushi.Extensions
{
	/// <summary>
	///     SOURCED FROM: Royaldesk.Common.Utility.Extensions
	/// </summary>
	public static class ReflectionExtensions
	{
		#region Get Property or Field

		/// <summary>
		///		Attempts to create an instance of the given type.
		///		Does not support generic type defs, interfaces or abstract classes
		///		and it uses the default value for constructors with parameters.
		/// </summary>
		public static object? CreateInstance(this Type type)
		{
			if (type.IsInterface || type.IsAbstract || type.IsGenericTypeDefinition)
				return null;

			try
			{
				var emptyCtor = type.GetConstructor(Type.EmptyTypes);
				if (emptyCtor != null)
					return Activator.CreateInstance(type);

				var constructors = type.GetConstructors();
				foreach (var ctor in constructors)
				{
					var parameters = ctor.GetParameters();
					var arguments = parameters.Select(x => GetDefault(x.ParameterType)).ToArray();
					return ctor.Invoke(arguments);
				}
			}
			catch (Exception e)
			{
#if DEBUG
				throw e;
#endif
				return null;
			}

			return null;
		}

		private static object? GetDefault(Type? type)
		{
			// Source: https://stackoverflow.com/questions/407337/net-get-default-value-for-a-reflected-propertyinfo
			// If no Type was supplied, if the Type was a reference type, or if the Type was a System.Void, return null
			if (type is not { IsValueType: true } || type == typeof(void))
				return null;

			// If the supplied Type has generic parameters, its default value cannot be determined
			if (type.ContainsGenericParameters)
			{
				throw new ArgumentException(
					"{" + MethodBase.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" + type +
					"> contains generic parameters, so the default value cannot be retrieved");
			}

			// If the Type is a primitive type, or if it is another publicly-visible value type (i.e. struct), return a 
			//  default instance of the value type
			if (type.IsPrimitive || !type.IsNotPublic)
			{
				try
				{
					return Activator.CreateInstance(type);
				}
				catch (Exception e)
				{
					throw new ArgumentException(
						"{"                                                          + MethodBase.GetCurrentMethod() +
						"} Error:\n\nThe Activator.CreateInstance method could not " +
						"create a default instance of the supplied value type <"     + type      +
						"> (Inner Exception message: \""                             + e.Message + "\")",
						e);
				}
			}

			// Fail with exception
			throw new ArgumentException("{"  + MethodBase.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" +
			                            type +
			                            "> is not a publicly-visible type, so the default value cannot be retrieved");
		}

		/// <summary>
		///     Get the <see cref="Type" /> and default <see cref="object" /> value
		///     for the available Properties in the given <typeparamref name="T" /> <paramref name="this" />.
		/// </summary>
		public static IEnumerable<KeyValuePair<PropertyInfo, object>> GetPropertiesWithStaticValue<T>(this T @this)
		{
			if (@this == null)
				yield break;

			var type = (typeof(T) == typeof(Type) ? @this as Type : typeof(T)) ?? typeof(T);
			var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			var instance = type.CreateInstance();
			foreach (var prp in properties)
			{
				var isReadonly = prp.CanWrite;

				var defaultValue = instance != null && prp.CanWrite ? prp.GetValue(instance) : null;

				yield return new KeyValuePair<PropertyInfo, object>(prp, defaultValue);
			}
		}

		#endregion

		/// <summary>
		///     Get the <see cref="PropertyInfo" /> of the property <paramref name="propertyLambda" /> in
		///     <typeparamref name="TSource" />.
		/// </summary>
		public static PropertyInfo GetPropertyInfo<TSource, TProperty>(this TSource @this,
			Expression<Func<TSource, TProperty>> propertyLambda,
			bool checkReflectedType = false)
		{
			var type = typeof(TSource);
			if (typeof(TSource) == typeof(Type))
				type = @this as Type;

			var unary = propertyLambda.Body as UnaryExpression;
			var member = unary?.Operand as MemberExpression ?? propertyLambda.Body as MemberExpression;
			if (member == null)
			{
				throw new ArgumentException($@"Expression '{propertyLambda}' refers to a method, not a property.",
					nameof(propertyLambda));
			}

			var propInfo = member.Member as PropertyInfo;
			if (propInfo == null)
			{
				throw new ArgumentException($@"Expression '{propertyLambda}' refers to a field, not a property.",
					nameof(propertyLambda));
			}

			if (type != propInfo.ReflectedType             &&
			    !type.IsSubclassOf(propInfo.ReflectedType) &&
			    checkReflectedType)
			{
				throw new ArgumentException(
					$@"Expresion '{propertyLambda}' refers to a property that is not from type {type}.",
					nameof(propertyLambda));
			}

			return propInfo;
		}

		/// <summary>
		///     A T extension method that query if '@this' is type or inherits of.
		/// </summary>
		public static bool InheritsInterface<T>(this Type objectType)
		{
			// Checking basetype for interfaces doesn't really work.
			var interfaces = objectType.GetInterfaces();
			var type = typeof(T);
			if (!type.IsInterface)
				throw new ArgumentException($"Expected {type.Name} to be an interface.");

			return interfaces.Any(x => x.Name == type.Name);
		}

		/// <summary>
		///     Simple check if the given <see cref="Type" /> is <see cref="Nullable" />.
		/// </summary>
		public static bool IsNullable(this Type @this)
			=> !@this.IsClass && Nullable.GetUnderlyingType(@this) != null;

		/// <summary>
		///     If the given type is an array.
		/// </summary>
		public static bool IsArray(this Type type)
		{
			var isInterfaceArray = type.InheritsInterface<IEnumerable>() || type.IsArray;
			var isString = type == typeof(string);
			return isInterfaceArray && !isString;
		}
	}
}