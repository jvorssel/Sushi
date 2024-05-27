// /***************************************************************************\
// Module Name:       TypeConverterTests.cs
// Project:                   Sushi.Tests
// Author:                   Jeroen Vorsselman 15-05-2023
// Copyright:              Goblin workshop @ 2023
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// \***************************************************************************/

#region

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Sushi.Descriptors;
using Sushi.Enum;
using Sushi.Helpers;
using Sushi.Tests.Models;

#endregion

namespace Sushi.Tests.Converters;

public abstract class TypeScriptConverterTests
{
    protected Type[] TestTypes => new[]
        { typeof(TypeModel), typeof(StudentViewModel), typeof(PersonViewModel), typeof(ViewModel), typeof(Gender) };

    [TestClass]
    public class ResolveScriptTypeTests : TypeScriptConverterTests
    {
        [TestMethod]
        public void ResolveScriptType_ClassProperty_ShouldFormatCorrectly()
        {
            // Arrange
            var descriptor = new ClassDescriptor(typeof(TypeModel));
            var propertyDescriptor = descriptor.Properties[nameof(TypeModel.Student)];
            var converter = new SushiConverter(TestTypes)
                .TypeScript();

            // Act
            var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

            // Assert
            Assert.AreEqual("StudentViewModel", scriptType);
        }

        [TestMethod]
        public void ResolveScriptType_ClassPropertyMissing_ShouldUseAny()
        {
            // Arrange
            var descriptor = new ClassDescriptor(typeof(TypeModel));
            var propertyDescriptor = descriptor.Properties[nameof(TypeModel.Student)];
            var converter = new SushiConverter(typeof(TypeModel), typeof(ViewModel))
                .TypeScript();

            // Act
            var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

            // Assert
            Assert.AreEqual("any", scriptType);
        }

        [TestMethod]
        public void ResolveScriptType_EnumPropertyMissing_ShouldReturnNumber()
        {
            // Arrange
            var descriptor = new ClassDescriptor(typeof(StudentViewModel));
            var types = new[]
                { descriptor, new ClassDescriptor(typeof(PersonViewModel)), new ClassDescriptor(typeof(ViewModel)) };

            new DescriptorTreeBuilder(types).BuildTree();
            
            var propertyDescriptor = descriptor.Parent.Properties[nameof(StudentViewModel.Gender)];
            var converter = new SushiConverter(TestTypes.Where(x => x != typeof(Gender)).ToList())
                .TypeScript();

            // Act
            var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

            // Assert
            Assert.AreEqual("number", scriptType);
        }

        [TestMethod]
        public void ResolveScriptType_GenericArrayType_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var results = new[]
            {
                converter.ResolveScriptType(typeof(HashSet<StudentViewModel>)),
                converter.ResolveScriptType(typeof(Collection<StudentViewModel>)),
                converter.ResolveScriptType(typeof(IList<StudentViewModel>)),
                converter.ResolveScriptType(typeof(ICollection<StudentViewModel>)),
                converter.ResolveScriptType(typeof(ImmutableHashSet<StudentViewModel>)),
                converter.ResolveScriptType(typeof(IReadOnlyList<StudentViewModel>)),
                converter.ResolveScriptType(typeof(ReadOnlyCollection<StudentViewModel>)),
                converter.ResolveScriptType(typeof(List<StudentViewModel>))
            };

            // Assert
            foreach (var scriptTypeValue in results)
                Assert.AreEqual("Array<StudentViewModel>", scriptTypeValue);
        }

        [TestMethod]
        public void ResolveScriptType_Dictionary_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var withNumber = converter.ResolveScriptType(typeof(Dictionary<string, int>));
            var withGender = converter.ResolveScriptType(typeof(IDictionary<string, Gender>));
            var withStudent = converter.ResolveScriptType(typeof(IDictionary<string, StudentViewModel>));

            // Assert
            Assert.AreEqual("{ [key: string]: number }", withNumber);
            Assert.AreEqual("{ [key: string]: Gender | number }", withGender);
            Assert.AreEqual("{ [key: string]: StudentViewModel }", withStudent);
        }

        [TestMethod]
        public void ResolveScriptType_NormalArrayType_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var numericArray = converter.ResolveScriptType(typeof(int[]));
            Assert.AreEqual("Array<number>", numericArray);

            var classArray = converter.ResolveScriptType(typeof(StudentViewModel[]));
            Assert.AreEqual("Array<StudentViewModel>", classArray);

            var enumArray = converter.ResolveScriptType(typeof(Gender[]));
            Assert.AreEqual("Array<Gender | number>", enumArray);
        }

        [TestMethod]
        public void ResolveScriptType_DeepGenerics_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var result = converter.ResolveScriptType(typeof(List<List<List<List<List<bool?>>>>>), isNullable: true);

            // Assert
            Assert.AreEqual("Array<Array<Array<Array<Array<boolean | null>>>>>", result);
        }

        [TestMethod]
        public void ResolveScriptType_DeepComplexGenerics_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var result = converter.ResolveScriptType(typeof(Dictionary<string, List<StudentViewModel>>));

            // Assert
            Assert.AreEqual("{ [key: string]: Array<StudentViewModel> }", result);
        }

        [TestMethod]
        public void ResolveScriptType_NullableProperty_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();

            // Act
            var result = converter.ResolveScriptType(typeof(bool?), isNullable: true);

            // Assert
            Assert.AreEqual("boolean | null", result);
        }

        [TestMethod]
        public void ResolveScriptType_WithPrefix_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(typeof(StudentViewModel), typeof(GenericStandalone<>)).TypeScript();
            const string prefix = "vm.";

            // Act
            var classType = converter.ResolveScriptType(typeof(StudentViewModel), prefix);
            var arrayType = converter.ResolveScriptType(typeof(StudentViewModel[]), prefix);
            var genericType = converter.ResolveScriptType(typeof(GenericStandalone<StudentViewModel>[]), prefix);
            var nativeType = converter.ResolveScriptType(typeof(bool), prefix);

            // Assert
            Assert.AreEqual("vm.StudentViewModel", classType);
            Assert.AreEqual("Array<vm.StudentViewModel>", arrayType);
            Assert.AreEqual("Array<vm.GenericStandalone<vm.StudentViewModel>>", genericType);
            Assert.AreEqual("boolean", nativeType);
        }

        [TestMethod]
        public void ResolveScriptType_Overridden_ShouldFormatCorrectly()
        {
            // Act
            var converter = new SushiConverter(typeof(ViewModel), typeof(NullablePropertiesViewModel)).TypeScript();

            // Assert
            var model = converter.Models.Single(x => x.Name == nameof(NullablePropertiesViewModel));
            Assert.IsTrue(model.Properties.Any(x => x.Value is { Name: "Guid", IsOverridden: true }));

            var baseModel = converter.Models.Single(x => x.Name == nameof(ViewModel));
            Assert.IsTrue(baseModel.Properties.Any(x => x.Value is { Name: "Guid", IsOverridden: false }));
        }
    }

    [TestClass]
    public class ResolveDefaultValueTests : TypeScriptConverterTests
    {
        [TestMethod]
        public void ResolveDefaultValue_NullableProperty_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var nullableBoolType = new PropertyDescriptor(typeof(bool?));
            var nullableClassType = new PropertyDescriptor(typeof(Nullable<bool>));

            // Act
            var boolResult = converter.ResolveDefaultValue(nullableBoolType);
            var nullableResult = converter.ResolveDefaultValue(nullableClassType);

            // Assert
            Assert.AreEqual(NativeType.Null.ToScriptType(), boolResult);
            Assert.AreEqual(NativeType.Null.ToScriptType(), nullableResult);
        }

        [TestMethod]
        public void ResolveDefaultValue_ArrayProperty_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(List<int>));

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("[]", value);
        }

        [TestMethod]
        public void ResolveDefaultValue_NullValue_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(int?));

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("null", value);
        }

        [TestMethod]
        public void ResolveDefaultValue_BooleanValue_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(bool), true);

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("true", value);
        }

        [TestMethod]
        public void ResolveDefaultValue_BooleanValueFalse_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(bool), false);

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("false", value);
        }

        [TestMethod]
        public void ResolveDefaultValue_EnumValue_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(Gender), Gender.Male);

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("1", value);
        }

        [TestMethod]
        public void ResolveDefaultValue_DecimalValue_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(decimal), 2.666666666666666666666666666666666m);

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("2.6666666666666666666666666667".Substring(0, 15), value);
        }

        [TestMethod]
        public void ResolveDefaultValue_StringValue_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(string), "Hi!");

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("\"Hi!\"", value);
        }

        [TestMethod]
        public void ResolveDefaultValue_ClassValue_ReturnsNewClassTest()
        {
            // Arrange
            var converter = new SushiConverter(typeof(ViewModel), typeof(PersonViewModel), typeof(StudentViewModel))
                .TypeScript();
            var prop = new PropertyDescriptor(typeof(StudentViewModel), new StudentViewModel());

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("new StudentViewModel()", value);
        }

        [TestMethod]
        public void ResolveDefaultValue_NoScriptTypeClassValue_ReturnsEmptyStringTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(StudentViewModel), new StudentViewModel());

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual(string.Empty, value, "Class constructor not found.");
        }

        [TestMethod]
        public void ResolveDefaultValue_NullValue_ExpectNullTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(string));

            // Act
            var result = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("null", result);
        }

        [TestMethod]
        public void ResolveDefaultValue_Dictionary_ExpectObjectTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(Dictionary<string, StudentViewModel>),
                new Dictionary<string, StudentViewModel>());

            // Act
            var result = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.AreEqual("{}", result);
        }
    }

    [TestClass]
    public class GenericClassSupport : TypeScriptConverterTests
    {
        [TestMethod]
        public void GenericClassDefinition_ShouldConvertTest()
        {
            // Arrange
            var type = typeof(GenericStandalone<>);

            // Act
            var converter = new SushiConverter(type)
                .TypeScript();

            // Assert
            Assert.AreEqual(1, converter.Models.Count);
            var descriptor = converter.Models.Single(x => x.Name == "GenericStandalone");

            Assert.AreEqual(2, descriptor.Properties.Count);

            var valuesProperty = descriptor.Properties["Values"];
            Assert.IsTrue(valuesProperty.Type.IsGenericType);

            var genericTypeArgument = converter.GetGenericTypeArguments(valuesProperty.Type, string.Empty, false);
            var valuesAsScript = converter.ResolveScriptType(valuesProperty.Type);
            Assert.AreEqual("Array<TEntry>", valuesAsScript);

            var totalAmountProperty = descriptor.Properties["TotalAmount"];
            var totalAmountAsScript = converter.ResolveScriptType(totalAmountProperty.Type);
            Assert.AreEqual("number", totalAmountAsScript);
        }

        [TestMethod]
        public void ComplexGenericClassDefinition_ShouldConvertTest()
        {
            // Arrange
            var type = typeof(GenericComplexStandalone<,>);

            // Act
            var converter = new SushiConverter(type)
                .TypeScript();

            // Assert
            Assert.AreEqual(1, converter.Models.Count);
            var descriptor = converter.Models.Single(x => x.Name == "GenericComplexStandalone");
            Assert.AreEqual(2, descriptor.GenericParameterNames.Count);
            Assert.IsTrue(descriptor.GenericParameterNames.Contains("TFirst"));
            Assert.IsTrue(descriptor.GenericParameterNames.Contains("TSecond"));

            // Should not contain readonly properties.
            Assert.IsFalse(descriptor.Properties.Any(x => x.Value.Readonly));

            Assert.AreEqual(3, descriptor.Properties.Count);

            var firstProperty = descriptor.Properties["First"];
            Assert.IsTrue(firstProperty.Type.IsGenericType);

            var firstAsScript = converter.ResolveScriptType(firstProperty.Type);
            Assert.AreEqual("Array<TFirst>", firstAsScript);

            var secondProperty = descriptor.Properties["Second"];
            Assert.IsTrue(secondProperty.Type.IsGenericType);

            var secondAsScript = converter.ResolveScriptType(secondProperty.Type);
            Assert.AreEqual("Array<TSecond>", secondAsScript);
        }

        [TestMethod]
        public void ComplexGenericClassDefinition_ShouldResolveScriptTypeTest()
        {
            // Arrange
            var type = typeof(GenericComplexStandalone<List<string>, GenericStandalone<int>>);

            // Act
            var converter = new SushiConverter(type, type.GetGenericTypeDefinition(), typeof(GenericStandalone<>))
                .TypeScript();
            var script = converter.ResolveScriptType(type);

            // Assert
            Assert.AreEqual("GenericComplexStandalone<Array<string>, GenericStandalone<number>>", script);
        }
    }

    [TestClass]
    public class ConstValuesSupport : TypeScriptConverterTests
    {
        [TestMethod]
        public void ConstValuesSupport_ShouldConvertTest()
        {
            // Arrange
            var type = typeof(ConstValues);

            // Act
            var converter = new SushiConverter(type)
                .TypeScript();

            // Assert
            Assert.AreEqual(1, converter.Models.Count);
            var descriptor = converter.Models.Single(x => x.Name == nameof(ConstValues));

            Assert.AreEqual(3, descriptor.Properties.Count);
            Assert.IsTrue(descriptor.Properties.Any(x => x.Value.DefaultValue.ToString() == ConstValues.First));
            Assert.IsTrue(descriptor.Properties.Any(x => x.Value.DefaultValue.ToString() == ConstValues.Last));
            Assert.IsTrue(descriptor.Properties.Any(x => x.Value.DefaultValue.ToString() == ConstValues.Static));
        }
    }
}