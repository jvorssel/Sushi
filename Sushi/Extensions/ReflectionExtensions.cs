using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using Sushi.Descriptors;

namespace Sushi.Extensions;

internal static class ReflectionExtensions
{
    /// <summary>
    ///     Attempts to create an instance of the given type.
    ///     Does not support generic type defs, interfaces or abstract classes
    ///     and it uses the default value for constructors with parameters.
    /// </summary>
    internal static object? CreateInstance(this Type type)
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
        catch
        {
#if DEBUG
            throw;
#endif
            return null;
        }

        return null;
    }

    private static object? GetDefault(Type type)
    {
        // Source: https://stackoverflow.com/questions/407337/net-get-default-value-for-a-reflected-propertyinfo
        // If no Type was supplied, if the Type was a reference type, or if the Type was a System.Void, return null
        if (!type.IsValueType || type == typeof(void))
            return null;

        // If the supplied Type has generic parameters, its default value cannot be determined
        if (type.ContainsGenericParameters)
            throw new ArgumentException(
                "{" + MethodBase.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" + type +
                "> contains generic parameters, so the default value cannot be retrieved");

        // If the Type is a primitive type, or if it is another publicly-visible value type (i.e. struct), return a 
        //  default instance of the value type
        if (type is { IsPrimitive: false, IsNotPublic: true })
            throw new ArgumentException("{" + MethodBase.GetCurrentMethod() + "} Error:\n\nThe supplied value type <" +
                                        type +
                                        "> is not a publicly-visible type, so the default value cannot be retrieved");
        try
        {
            return Activator.CreateInstance(type);
        }
        catch (Exception e)
        {
            throw new ArgumentException(
                "{" + MethodBase.GetCurrentMethod() +
                "} Error:\n\nThe Activator.CreateInstance method could not " +
                "create a default instance of the supplied value type <" + type +
                "> (Inner Exception message: \"" + e.Message + "\")",
                e);
        }
    }

    /// <summary>
    ///     Get the <see cref="Type" /> and default <see cref="object" /> value
    ///     for the available Properties in the given <typeparamref name="T" /> <paramref name="this" />.
    /// </summary>
    internal static IEnumerable<KeyValuePair<PropertyInfo, object?>> GetPropertiesWithStaticValue<T>(this T @this)
    {
        if (@this == null)
            yield break;

        var classType = (typeof(T) == typeof(Type) ? @this as Type : typeof(T)) ?? typeof(T);
        var properties = classType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.DeclaringType == classType);

        var instance = classType.CreateInstance();
        foreach (var prp in properties)
        {
            var defaultValue = instance != null && prp.CanWrite ? prp.GetValue(instance) : null;
            yield return new KeyValuePair<PropertyInfo, object?>(prp, defaultValue);
        }
    }

    /// <summary>
    ///     Get the <see cref="PropertyInfo" /> of the property <paramref name="propertyLambda" /> in
    ///     <typeparamref name="TSource" />.
    /// </summary>
    internal static PropertyInfo GetPropertyInfo<TSource, TProperty>(this TSource @this,
        Expression<Func<TSource, TProperty>> propertyLambda,
        bool checkReflectedType = false)
    {
        var type = typeof(TSource);
        if (typeof(TSource) == typeof(Type))
            type = @this as Type;

        var unary = propertyLambda.Body as UnaryExpression;
        var member = unary?.Operand as MemberExpression ?? propertyLambda.Body as MemberExpression;
        if (member == null)
            throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a property.",
                nameof(propertyLambda));

        var propInfo = member.Member as PropertyInfo;
        if (propInfo == null)
            throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.",
                nameof(propertyLambda));

        var reflectedType = propInfo.ReflectedType!;
        if (type != reflectedType && !type!.IsSubclassOf(reflectedType) &&
            checkReflectedType)
            throw new ArgumentException(
                $"Expression '{propertyLambda}' refers to a property that is not from type {type}.",
                nameof(propertyLambda));

        return propInfo;
    }

    /// <summary>
    ///     A T extension method that query if '@this' is type or inherits of.
    /// </summary>
    internal static bool IsOrInheritsInterface<T>(this Type objectType)
    {
        var type = typeof(T);
        if (!type.IsInterface)
            throw new ArgumentException($"Expected {type.Name} to be an interface.");

        var interfaces = objectType.GetInterfaces();
        return objectType == type || interfaces.Any(x => x.Name == type.Name);
    }

    /// <summary>
    ///     Simple check if the given <see cref="Type" /> is <see cref="Nullable" />.
    /// </summary>
    internal static bool IsNullable(this Type @this)
    {
        return !@this.IsClass && Nullable.GetUnderlyingType(@this) != null;
    }

    /// <summary>
    ///     If the given type is a dictionary.
    /// </summary>
    internal static bool IsDictionary(this Type type)
    {
        if (!type.IsGenericType)
            return false;

        var genericType = type.GetGenericTypeDefinition();
        return genericType == typeof(Dictionary<,>) || genericType == typeof(IDictionary<,>);
    }

    /// <summary>
    ///     If the given type is an array.
    /// </summary>
    internal static bool IsArrayType(this Type type)
    {
        var isInterfaceArray = type.IsOrInheritsInterface<IEnumerable>() || type.IsArray;
        var isString = type == typeof(string);
        var isDict = type.IsDictionary();

        return isInterfaceArray && !isString && !isDict;
    }

    /// <summary>
    ///		Get the first base type if generic or array.
    /// </summary>
    internal static Type? GetBaseType(this Type type, IReadOnlyCollection<ITypeDescriptor>? descriptors = null,
        bool deep = true)
    {
        var currentType = type;

        while (true)
        {
            if (descriptors != null && descriptors.Any(x => x.Type == currentType))
                return currentType;

            if (currentType is { IsGenericType: false, IsArray: false, IsGenericTypeDefinition: false })
            {
                if (descriptors != null && descriptors.All(x => x.Type != currentType))
                    return null;

                return currentType;
            }

            if (currentType.IsArray)
            {
                currentType = currentType.GetElementType() ?? currentType;
                if (!deep)
                    return currentType;
            }
            else if (currentType.IsGenericType)
            {
                currentType = currentType.GetGenericArguments().First();
                if (!deep)
                    return currentType;
            }
            else
            {
                return currentType;
            }
        }
    }


    internal static bool IsPropertyHidingBaseClassProperty(this Type? derivedType, string propertyName)
    {
        // Get the base type of the derived type
        var baseType = derivedType?.BaseType;

        // Ensure the base type is not null (i.e., derivedType is not Object)
        if (derivedType == null || baseType == null) return false;

        // Get the property from the derived class
        var derivedProperty = derivedType.GetProperty(propertyName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        if (derivedProperty == null)
            throw new ArgumentException($"Property '{propertyName}' does not exist in type '{derivedType.Name}'.");

        // Get the property from the base class
        var baseProperty = baseType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        if (baseProperty == null) return false;

        // Get the getter methods for both properties
        var baseMethod = baseProperty.GetGetMethod();
        var derivedMethod = derivedProperty.GetGetMethod();

        // Compare the methods to determine if they are different
        return derivedMethod != null && baseMethod != null && derivedMethod != baseMethod;
    }
}