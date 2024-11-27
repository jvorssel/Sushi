using System;
using System.Linq;
using Sushi.Descriptors;
using Sushi.TestModels;
using Xunit;

namespace Sushi.Tests.ModelDescriptors;

public abstract class ClassDescriptorTests
{
	
	public sealed class InitializerTests : ClassDescriptorTests
	{
		[Fact]
		public void Initialize_WithSimpleClass_ShouldMapCorrectly()
		{
			// Arrange
			var type = typeof(ViewModel);

			// Act
			var descriptor = new ClassDescriptor(type);

			// Assert
			Assert.Equal(nameof(ViewModel), descriptor.Name);
			Assert.Equal(type.FullName, descriptor.FullName);

			Assert.Equal(2, descriptor.Properties.Count);
			Assert.False(descriptor.HasParameterlessCtor);
		}

		[Fact]
		public void Initialize_WithNestedClass_ShouldMapCorrectly()
		{
			// Arrange
			var type = typeof(PersonViewModel);

			// Act
			var descriptor = new ClassDescriptor(type);

			// Assert
			Assert.Equal(4, descriptor.Properties.Count);
			Assert.Equal(descriptor.Properties.Distinct().Count(), descriptor.Properties.Count);
			Assert.False(descriptor.HasParameterlessCtor);
		}
			
		[Fact]
		public void Initialize_GenericClassWithoutType_ShouldMapCorrectly()
		{
			// Arrange
			var withoutGenericType = typeof(GenericStandalone<>);

			// Act
			var result = new ClassDescriptor(withoutGenericType);

			// Assert
			Assert.Equal(2, result.Properties.Count);
			Assert.Equal("TEntry", result.GenericParameterNames.Single());
			Assert.True(result.HasParameterlessCtor);
		}
			
		[Fact]
		public void Initialize_GenericClassWithType_ShouldMapCorrectly()
		{
			// Arrange
			var withGenericType = typeof(GenericStandalone<string>);

			// Act
			var result = new ClassDescriptor(withGenericType);

			// Assert
			Assert.Equal(2, result.Properties.Count);
			Assert.False(result.GenericParameterNames.Any());
			Assert.True(result.HasParameterlessCtor);
		}
			
		[Fact]
		public void Initialize_WithExcludedClass_ShouldThrowCorrectly()
		{
			// Arrange
			var type = typeof(NotAScriptModel);

			// Act
			var result = new ClassDescriptor(type);

			// Assert
			Assert.False(result.IsApplicable);
		}
	}

	
	public sealed class EqualityOperatorTests
	{
		[Theory]
		[InlineData(typeof(ViewModel), typeof(ViewModel), true)]
		[InlineData(typeof(ViewModel), typeof(PersonViewModel), false)]
		[InlineData(typeof(Gender), typeof(NotAScriptModel), false)]
		[InlineData(typeof(TypeModel), typeof(TypeModel), true)]
		public void EqualityOperator_CompareClassTest(Type source, Type compareTo, bool equality)
		{
			// Arrange
			var m1 = new ClassDescriptor(source);
			var m2 = new ClassDescriptor(compareTo);

			// Act
			var result = m1 == m2;

			// Assert
			Assert.Equal(equality, result);
		}
			
		[Fact]
		public void EqualityOperator_ExpectNullTest()
		{
			// Arrange
			var m1 = new ClassDescriptor(typeof(ViewModel));
			ClassDescriptor? m2 = null;

			// Act & Assert
			Assert.False(m1 == m2);
			Assert.True(m2 != m1);
			Assert.False(m1 is null);
			Assert.True(m2 is null);
			Assert.False(m1.Equals(m2));
			Assert.False(m1.Equals(null));
			Assert.False(m1.GetHashCode() == m2?.GetHashCode());
		}
	}

	
	public sealed class PropertyDescriptorsTests
	{
		[Fact]
		public void NestedTypeModel_ShouldFindAllFieldsAndPropertiesTest()
		{
			// Arrange
			var type = typeof(TypeModel);

			// Act
			var descriptor = new ClassDescriptor(type);

			// Assert
			Assert.Equal(8, descriptor.Properties.Count);
		}
	}

	
	public sealed class GetPropertiesTests : ClassDescriptorTests
	{
		[Fact]
		public void GetProperties_ExcludeInheritedTest()
		{
			// Arrange
			var descriptor = new ClassDescriptor(typeof(InheritedViewModel))
			{
				Parent = new ClassDescriptor(typeof(BaseViewModel))
			};

			// Act
			var properties = descriptor.GetProperties().ToList();

			// Assert
			Assert.DoesNotContain(properties, x => x.Name  == "Guid");
			Assert.Contains(properties, x => x.Name  == "Addition");
			Assert.Contains(properties, x => x.Name == "Value");
			Assert.DoesNotContain(properties, x => x.Name == "Base");
		}
	}
		
	
	public sealed class FilterTypesTest : ClassDescriptorTests
	{
		[Fact]
		public void FilterTypes_WithoutAttribute_ShouldFilterTest()
		{
			// Arrange
			var descriptors = new[] { typeof(ViewModel), typeof(string) }.Select(x=> new ClassDescriptor(x));

			// Act
			var result = descriptors.Where(x=>x.IsApplicable).ToList();

			// Assert
			Assert.Single(result);
			Assert.Equal(typeof(ViewModel), result.Single().Type);
		}

		[Fact]
		public void FilterTypes_WithNonClassTypes_ShouldFilterTest()
		{
			// Arrange
			var descriptors = new[] { typeof(ViewModel), typeof(bool), typeof(Gender) }.Select(x=> new ClassDescriptor(x));

			// Act
			var result = descriptors.Where(x=>x.IsApplicable).ToList();

			// Assert
			Assert.Single(result);
			Assert.Equal(typeof(ViewModel), result.Single().Type);
		}
	}
}