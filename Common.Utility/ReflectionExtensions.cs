using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Common.Utility
{
    /// <summary>
    ///     SOURCED FROM: Royaldesk.Common.Utility.Extensions
    /// </summary>
    public static class ReflectionExtensions
    {
        #region Get Property or Field

        /// <summary>
        ///     A T extension method that searches for the public field with the specified name.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The string containing the name of the data field to get.</param>
        /// <returns>
        ///     An object representing the field that matches the specified requirements, if found;
        ///     otherwise, null.
        /// </returns>
        public static FieldInfo GetField<T>(this T @this, string name)
        {
            return @this.GetType().GetField(name);
        }

        /// <summary>
        ///     A T extension method that searches for the specified field, using the specified
        ///     binding constraints.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The string containing the name of the data field to get.</param>
        /// <param name="bindingAttr">
        ///     A bitmask comprised of one or more BindingFlags that specify how the
        ///     search is conducted.
        /// </param>
        /// <returns>
        ///     An object representing the field that matches the specified requirements, if found;
        ///     otherwise, null.
        /// </returns>
        public static FieldInfo GetField<T>(this T @this, string name, BindingFlags bindingAttr)
        {
            return @this.GetType().GetField(name, bindingAttr);
        }

        /// <summary>
        ///     A T extension method that gets a property.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The name.</param>
        /// <returns>The property.</returns>
        public static PropertyInfo GetProperty<T>(this T @this, string name)
        {
            return @this.GetType().GetProperty(name);
        }

        /// <summary>
        ///     A T extension method that gets a property.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The name.</param>
        /// <param name="bindingAttr">The binding attribute.</param>
        /// <returns>The property.</returns>
        public static PropertyInfo GetProperty<T>(this T @this, string name, BindingFlags bindingAttr)
        {
            return @this.GetType().GetProperty(name, bindingAttr);
        }

        /// <summary>
        ///     A T extension method that gets property or field.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The name.</param>
        /// <returns>The property or field.</returns>
        public static MemberInfo GetPropertyOrField<T>(this T @this, string name)
        {
            var property = @this.GetProperty(name);
            if (property != null)
            {
                return property;
            }

            var field = @this.GetField(name);
            return field ?? null;
        }

        /// <summary>
        ///     Get the <see cref="Type"/> and default <see cref="object"/> value 
        ///     for the available Properties in the given <typeparamref name="T"/> <paramref name="@this"/>.
        /// </summary>
        public static IEnumerable<KeyValuePair<PropertyInfo, object>> GetPropertiesWithStaticValue<T>(this T @this)
        {
            if (@this == null)
                yield break;

            var type = (typeof(T) == typeof(Type) ? @this as Type : typeof(T)) ?? typeof(T);
            var instance = Activator.CreateInstance(type);
            var properties = type.GetProperties();

            foreach (var prp in properties)
            {
                var defaultValue = prp.GetValue(instance);
                yield return new KeyValuePair<PropertyInfo, object>(prp, defaultValue);
            }
        }

        #endregion

        /// <summary>
        ///     If the <see cref="Type"/> <typeparamref name="T"/> has a parameter less constructor
        /// </summary>
        public static bool HasDefaultConstructor<T>(this T t)
            where T : Type
        {
            return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
        }

        /// <summary>
        ///     Get the <see cref="PropertyInfo"/> of the property <paramref name="propertyLambda"/> in <typeparamref name="TSource"/>.
        /// </summary>
        public static PropertyInfo GetPropertyInfo<TSource, TProperty>(this TSource @this, Expression<Func<TSource, TProperty>> propertyLambda, bool checkReflectedType = false)
        {
            var type = typeof(TSource);
            if (typeof(TSource) == typeof(Type))
                type = @this as Type;

            var unary = propertyLambda.Body as UnaryExpression;
            var member = unary?.Operand as MemberExpression ?? propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException($@"Expression '{propertyLambda}' refers to a method, not a property.", nameof(propertyLambda));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException($@"Expression '{propertyLambda}' refers to a field, not a property.", nameof(propertyLambda));


            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType) &&
                checkReflectedType)
                throw new ArgumentException($@"Expresion '{propertyLambda}' refers to a property that is not from type {type}.", nameof(propertyLambda));

            return propInfo;
        }

        /// <summary>
        ///     Get a field name for the <see cref="TSource"/> that the <see cref="Expression"/> <paramref name="this"/> refers to.
        /// </summary>
        public static string GetFieldName<TSource, TProperty>(this Expression<Func<TSource, TProperty>> @this, bool checkReflectedType = false)
        {
            var member = @this.Body as MemberExpression;
            if (member != null)
                return member.Member.Name;

            if (@this.Body is UnaryExpression unary)
                member = unary.Operand as MemberExpression;

            if (member == null)
                throw new ArgumentException(@"Expression is not a MemberExpression", nameof(@this));

            return member.Member.Name;
        }

        /// <summary>
        ///     If the <see cref="PropertyInfo"/> <paramref name="this"/> is an array.
        /// </summary>
        public static bool IsArray(this PropertyInfo @this)
        {
            return (typeof(IEnumerable).IsAssignableFrom(@this.PropertyType) || @this.PropertyType.IsArray) &&
                @this.PropertyType != typeof(string);
        }

        /// <summary>
        ///     If the <see cref="Type"/> <paramref name="this"/> has the <see cref="Attribute"/> <typeparamref name="TAttr"/>.
        /// </summary>
        public static bool HasAttribute<TAttr>(this Type @this)
            where TAttr : Attribute
            => @this?.GetCustomAttributes(typeof(TAttr)) != null;

        /// <summary>
        ///     Check if the <see cref="Type"/> <typeparamref name="T"/> inherits one or more
        ///     <paramref name="attributes"/>.
        /// </summary>
        public static bool HasAttribute<T>(this T @this, params Type[] attributes)
        {
            if (@this is Type)
            {
                var t = @this as Type;
                return attributes.Any(x => t?.GetCustomAttributes(x, false).Length > 0);
            }
            else if (@this is MemberInfo)
            {
                var t = @this as MethodInfo;
                return attributes.Any(x => t?.GetCustomAttributes(x, false).Length > 0);
            }
            else
            {
                var t = typeof(T);
                return attributes.Any(x => t.GetCustomAttributes(x, false).Length > 0);
            }
        }

        /// <summary>
        ///     A T extension method that query if '@this' is type or inherits of.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="type">The type.</param>
        /// <returns>true if type or inherits of, false if not.</returns>
        public static bool IsTypeOrInheritsOf<T>(this T @this, Type type)
        {
            var objectType = @this.GetType();
            if (typeof(T) == typeof(Type))
                objectType = @this as Type;

            // Checking basetype for interfaces doens't really work.
            if (type.IsInterface)
                return objectType?.GetInterfaces().Contains(type) ?? false;

            while (objectType?.BaseType != null)
            {
                if (objectType == type)
                    return true;

                objectType = objectType.BaseType;
            }

            return false;
        }

        /// <summary>
        ///     If the <see cref="Type"/> <paramref name="type"/> is a primitive type.
        /// </summary>
        /// <remarks>
        ///     Source: https://gist.github.com/jonathanconway/3330614
        /// </remarks>
        public static bool IsPrimitiveType(this Type type)
        {
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new[] {
                    typeof(String),
                    typeof(Decimal),
                    typeof(DateTime),
                    typeof(DateTimeOffset),
                    typeof(TimeSpan),
                    typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }

        /// <summary>
        ///     Enumerate over each instance of a <see cref="Exception.InnerException"/>.
        /// </summary>
        public static IEnumerable<Exception> Enumerate(this Exception @this)
        {
            var ex = @this;

            while (ex != null)
            {
                yield return ex;
                ex = ex.InnerException;
            }
        }
    }
}
