using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Sushi.Extensions
{
    /// <summary>
    ///     SOURCED FROM: Royaldesk.Common.Utility.Extensions
    /// </summary>
    public static class ReflectionExtensions
    {
        #region Get Property or Field

        /// <summary>
        ///     Get the <see cref="Type"/> and default <see cref="object"/> value 
        ///     for the available Properties in the given <typeparamref name="T"/> <paramref name="this"/>.
        /// </summary>
        public static IEnumerable<KeyValuePair<PropertyInfo, object>> GetPropertiesWithStaticValue<T>(this T @this)
        {
            if (@this == null)
                yield break;

            var type = (typeof(T) == typeof(Type) ? @this as Type : typeof(T)) ?? typeof(T);
            var properties = type.GetProperties();

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
        ///     Simple check if the given <see cref="Type"/> is <see cref="Nullable"/>.
        /// </summary>
        public static bool IsNullable(this Type @this)
            => Nullable.GetUnderlyingType(@this) != null;
    }
}
