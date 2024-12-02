using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using Sushi.Converters.TypeScript;
using Sushi.Descriptors;
using Sushi.Extensions;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests.Converters;

public abstract class TypeScriptConverterTests
{
    protected Type[] TestTypes => new[]
    {
        typeof(TypeModel), typeof(StudentViewModel), typeof(PersonViewModel), typeof(ViewModel), typeof(ScriptModel),
        typeof(Gender)
    };

    
    public sealed class ResolveScriptTypeTests : TypeScriptConverterTests
    {
        [Fact]
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
            Assert.Equal("StudentViewModel", scriptType);
        }

        [Fact]
        public void ResolveScriptType_ClassPropertyMissing_NotStrict_ShouldUseAny()
        {
            // Arrange
            var descriptor = new ClassDescriptor(typeof(TypeModel));
            var propertyDescriptor = descriptor.Properties[nameof(TypeModel.Student)];
            
            var config = new DefaultConverterConfig { Strict = false };
            var converter = new SushiConverter(typeof(TypeModel), typeof(ViewModel), typeof(ScriptModel))
                .TypeScript(config);

            // Act
            var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

            // Assert
            Assert.Equal("any", scriptType);
        }

        [Fact]
        public void ResolveScriptType_EnumPropertyMissing_ShouldReturnNumber()
        {
            // Arrange
            var descriptor = new ClassDescriptor(typeof(StudentViewModel));
            new[]
            {
                descriptor, new ClassDescriptor(typeof(PersonViewModel)), new ClassDescriptor(typeof(ViewModel)),
                new ClassDescriptor(typeof(ScriptModel))
            }.BuildTree();

            var propertyDescriptor = descriptor.Parent.Properties[nameof(StudentViewModel.Gender)];
            var converter = new SushiConverter(TestTypes.Where(x => x != typeof(Gender)).ToList())
                .TypeScript();

            // Act
            var scriptType = converter.ResolveScriptType(propertyDescriptor.Type);

            // Assert
            Assert.Equal("number", scriptType);
        }

        [Fact]
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
                Assert.Equal("Array<StudentViewModel>", scriptTypeValue);
        }

        [Fact]
        public void ResolveScriptType_Dictionary_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var withNumber = converter.ResolveScriptType(typeof(Dictionary<string, int>));
            var withGender = converter.ResolveScriptType(typeof(IDictionary<string, Gender>));
            var withStudent = converter.ResolveScriptType(typeof(IDictionary<string, StudentViewModel>));

            // Assert
            Assert.Equal("{ [key: string]: number }", withNumber);
            Assert.Equal("{ [key: string]: Gender | number }", withGender);
            Assert.Equal("{ [key: string]: StudentViewModel }", withStudent);
        }

        [Fact]
        public void ResolveScriptType_NormalArrayType_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var numericArray = converter.ResolveScriptType(typeof(int[]));
            Assert.Equal("Array<number>", numericArray);

            var classArray = converter.ResolveScriptType(typeof(StudentViewModel[]));
            Assert.Equal("Array<StudentViewModel>", classArray);

            var enumArray = converter.ResolveScriptType(typeof(Gender[]));
            Assert.Equal("Array<Gender | number>", enumArray);
        }

        [Fact]
        public void ResolveScriptType_DeepGenerics_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var result = converter.ResolveScriptType(typeof(List<List<List<List<List<bool?>>>>>), isNullable: true);

            // Assert
            Assert.Equal("Array<Array<Array<Array<Array<boolean | null>>>>>", result);
        }

        [Fact]
        public void ResolveScriptType_DeepComplexGenerics_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes).TypeScript();

            // Act
            var result = converter.ResolveScriptType(typeof(Dictionary<string, List<StudentViewModel>>));

            // Assert
            Assert.Equal("{ [key: string]: Array<StudentViewModel> }", result);
        }

        [Fact]
        public void ResolveScriptType_NullableProperty_ShouldFormatCorrectly()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();

            // Act
            var result = converter.ResolveScriptType(typeof(bool?), isNullable: true);

            // Assert
            Assert.Equal("boolean | null", result);
        }

        [Theory]
        [InlineData(typeof(ScriptModel), "vm.ScriptModel")]
        [InlineData(typeof(ScriptModel[]), "Array<vm.ScriptModel>")]
        [InlineData(typeof(GenericStandalone<ScriptModel>[]), "Array<vm.GenericStandalone<vm.ScriptModel>>")]
        [InlineData(typeof(bool), "boolean")]
        public void ResolveScriptType_WithPrefix_ShouldFormatCorrectly(Type type, string script)
        {
            // Arrange
            var converter = new SushiConverter(typeof(ScriptModel), typeof(GenericStandalone<>)).TypeScript();
            const string prefix = "vm.";

            // Act
            var scriptType = converter.ResolveScriptType(type, prefix);

            // Assert
            Assert.Equal(script, scriptType);
        }

        [Fact]
        public void ResolveScriptType_Overridden_ShouldFormatCorrectly()
        {
            // Act
            var converter =
                new SushiConverter(typeof(ScriptModel), typeof(ViewModel), typeof(NullablePropertiesViewModel))
                    .TypeScript();

            // Assert
            var model = converter.Models.Single(x => x.Name == nameof(NullablePropertiesViewModel));
            Assert.Contains(model.Properties, x => x.Value is { Name: "Guid", IsOverridden: true });

            var baseModel = converter.Models.Single(x => x.Name == nameof(ViewModel));
            Assert.Contains(baseModel.Properties, x => x.Value is { Name: "Guid", IsOverridden: false });
        }
    }

    
    public sealed class ResolveDefaultValueTests : TypeScriptConverterTests
    {
        [Theory]
        [InlineData(typeof(bool?), "null")]
        [InlineData(typeof(List<int>), "[]")]
        [InlineData(typeof(int[]), "[]")]
        [InlineData(typeof(IEnumerable<int>), "[]")]
        [InlineData(typeof(bool), "true", true)]
        [InlineData(typeof(bool?), "false", false)]
        [InlineData(typeof(Gender), "1", Gender.Male)]
        [InlineData(typeof(string), "\"Hi!\"", "Hi!")]
        [InlineData(typeof(string), "null")]
        [InlineData(typeof(DateTime), "(new Date()).toISOString()")]
        [InlineData(typeof(DateTime?), "null")]
        public void ResolveDefaultValue_DefaultTypeMap_ShouldReturnScriptTypeTest(Type type, string expectedValue, object? defaultValue = null)
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var descriptor = new PropertyDescriptor(type, defaultValue);

            // Act
            var result = converter.ResolveDefaultValue(descriptor);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ResolveDefaultValue_DecimalValue_ReturnsCorrectValueTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(decimal), 2.666666666666666666666666666666666m);

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.Equal("2.6666666666666666666666666667".Substring(0, 15), value);
        }

        [Fact]
        public void ResolveDefaultValue_ClassValue_ReturnsNewClassTest()
        {
            // Arrange
            var converter = new SushiConverter(TestTypes)
                .TypeScript();
            var prop = new PropertyDescriptor(typeof(StudentViewModel), new StudentViewModel());

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.Equal("new StudentViewModel()", value);
        }

        [Fact]
        public void ResolveDefaultValue_NoScriptTypeClassValue_ReturnsEmptyStringTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(StudentViewModel), new StudentViewModel());

            // Act
            var value = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.Equal(string.Empty, value);
        }

        [Fact]
        public void ResolveDefaultValue_Dictionary_ExpectObjectTest()
        {
            // Arrange
            var converter = new SushiConverter().TypeScript();
            var prop = new PropertyDescriptor(typeof(Dictionary<string, StudentViewModel>),
                new Dictionary<string, StudentViewModel>());

            // Act
            var result = converter.ResolveDefaultValue(prop);

            // Assert
            Assert.Equal("{}", result);
        }
    }

    public sealed class GenericClassSupport : TypeScriptConverterTests
    {
        [Fact]
        public void GenericClassDefinition_ShouldConvertTest()
        {
            // Arrange
            var type = typeof(GenericStandalone<>);

            // Act
            var converter = new SushiConverter(type)
                .TypeScript();

            // Assert
            Assert.Single(converter.Models);
            var descriptor = converter.Models.Single(x => x.Name == "GenericStandalone");

            Assert.Equal(2, descriptor.Properties.Count);

            var valuesProperty = descriptor.Properties["Values"];
            Assert.True(valuesProperty.Type.IsGenericType);

            converter.GetGenericTypeArguments(valuesProperty.Type, string.Empty, false);
            var valuesAsScript = converter.ResolveScriptType(valuesProperty.Type);
            Assert.Equal("Array<TEntry>", valuesAsScript);

            var totalAmountProperty = descriptor.Properties["TotalAmount"];
            var totalAmountAsScript = converter.ResolveScriptType(totalAmountProperty.Type);
            Assert.Equal("number", totalAmountAsScript);
        }

        [Fact]
        public void ComplexGenericClassDefinition_ShouldConvertTest()
        {
            // Arrange
            var type = typeof(GenericComplexStandalone<,>);

            // Act
            var converter = new SushiConverter(type)
                .TypeScript();

            // Assert
            Assert.Single(converter.Models);
            var descriptor = converter.Models.Single(x => x.Name == "GenericComplexStandalone");
            Assert.Equal(2, descriptor.GenericParameterNames.Count);
            Assert.Contains("TFirst", descriptor.GenericParameterNames);
            Assert.Contains("TSecond", descriptor.GenericParameterNames);

            // Should not contain readonly properties.
            Assert.DoesNotContain(descriptor.Properties, x => x.Value.Readonly);

            Assert.Equal(3, descriptor.Properties.Count);

            var firstProperty = descriptor.Properties["First"];
            Assert.True(firstProperty.Type.IsGenericType);

            var firstAsScript = converter.ResolveScriptType(firstProperty.Type);
            Assert.Equal("Array<TFirst>", firstAsScript);

            var secondProperty = descriptor.Properties["Second"];
            Assert.True(secondProperty.Type.IsGenericType);

            var secondAsScript = converter.ResolveScriptType(secondProperty.Type);
            Assert.Equal("Array<TSecond>", secondAsScript);
        }

        [Fact]
        public void ComplexGenericClassDefinition_ShouldResolveScriptTypeTest()
        {
            // Arrange
            var type = typeof(GenericComplexStandalone<List<string>, GenericStandalone<int>>);

            // Act
            var converter = new SushiConverter(type, type.GetGenericTypeDefinition(), typeof(GenericStandalone<>))
                .TypeScript();
            var script = converter.ResolveScriptType(type);

            // Assert
            Assert.Equal("GenericComplexStandalone<Array<string>, GenericStandalone<number>>", script);
        }
    }

    
    public sealed class ConstValuesSupport : TypeScriptConverterTests
    {
        [Fact]
        public void ConstValuesSupport_ShouldConvertTest()
        {
            // Arrange
            var type = typeof(ConstValues);

            // Act
            var converter = new SushiConverter(type)
                .TypeScript();

            // Assert
            Assert.Single(converter.Models);
            var descriptor = converter.Models.Single(x => x.Name == nameof(ConstValues));

            Assert.Equal(3, descriptor.Properties.Count);
            Assert.Contains(descriptor.Properties, x => x.Value.DefaultValue?.ToString() == ConstValues.First);
            Assert.Contains(descriptor.Properties, x => x.Value.DefaultValue?.ToString() == ConstValues.Last);
            Assert.Contains(descriptor.Properties, x => x.Value.DefaultValue?.ToString() == ConstValues.Static);
        }
    }
}