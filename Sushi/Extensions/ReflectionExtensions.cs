// /***************************************************************************\
// Module Name:       ReflectionExtensions.cs
// Project:                   Sushi
// Author:                   Jeroen Vorsselman 04-11-2022
// Copyright:              Royaldesk @ 2022
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

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
		///     Get the <see cref="Type" /> and default <see cref="object" /> value
		///     for the available Properties in the given <typeparamref name="T" /> <paramref name="this" />.
		/// </summary>
		public static IEnumerable<KeyValuePair<PropertyInfo, object>> GetPropertiesWithStaticValue<T>(this T @this)
		{
			if (@this == null)
				yield break;

			var type = (typeof(T) == typeof(Type) ? @this as Type : typeof(T)) ?? typeof(T);
			var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			var ctor = type.GetConstructor(Type.EmptyTypes);
			var instance = !type.IsAbstract && ctor != null ? Activator.CreateInstance(type) : null;
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
		/// <param name="objectType">The Type.</param>
		/// <param name="type">The type.</param>
		/// <returns>true if type or inherits of, false if not.</returns>
		public static bool IsTypeOrInheritsOf(this Type objectType, Type type)
		{
			// Checking basetype for interfaces doesn't really work.
			var interfaces = objectType.GetInterfaces();
			if (type.IsInterface)
				return interfaces.Any(x => x.Name == type.Name);

			while (objectType.BaseType != null)
			{
				if (objectType == type)
					return true;

				objectType = objectType.BaseType;
			}

			return false;
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
			var isInterfaceArray = type.IsTypeOrInheritsOf(typeof(IEnumerable<>)) || type.IsArray;
			var isString = type == typeof(string);
			return isInterfaceArray && !isString;
		}
	}
}