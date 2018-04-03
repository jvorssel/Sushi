using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sushi.Attributes;

namespace Sushi.Tests
{
	[TestClass]
	public class IgnoreAttributeTest
	{
		private readonly List<Type> _types = new List<Type> { typeof(IgnoreMe), typeof(IgnoreTestRoot), typeof(DoNotIgnoreMe) };

		[IgnoreForScript]
		private class IgnoreMe : IgnoreTestRoot { }

		[ConvertToScript]
		private class IgnoreTestRoot { }

		private class DoNotIgnoreMe : IgnoreTestRoot
		{
			public string ShouldExist { get; set; }

			[IgnoreForScript]
			public string ShouldNotExist { get; set; }
		}

		[TestMethod]
		public void FindModelWithAttributeTest()
		{
			using (var kernel = new ConversionKernel(_types))
			{
				// Have the ConvertToScript attribute, should exist in queue.
				Assert.IsTrue(kernel.Models.Any(x => x.Name == nameof(DoNotIgnoreMe) || x.Name == nameof(IgnoreTestRoot)), 
					$"Expected the {nameof(DoNotIgnoreMe)} and {nameof(IgnoreTestRoot)} classes to be available.");

				// IgnoreMe has the ignore attribute, should not exist in queue.
				Assert.IsTrue(kernel.Models.All(x => x.Name != nameof(IgnoreMe)), $"Expected the {nameof(IgnoreMe)} class not to be available.");
			}
		}

		[TestMethod]
		public void ExcludePropertyWithAttributeTest()
		{
			using (var kernel = new ConversionKernel(_types))
			{
				// Get the model with the properties that should use the Ignore attribute.
				var model = kernel.Models.SingleOrDefault(x => x.Name == nameof(DoNotIgnoreMe));
				Assert.IsNotNull(model);

				Assert.IsTrue(model.Properties.Any(x => x.Name == nameof(DoNotIgnoreMe.ShouldExist)), $"Expected the {nameof(DoNotIgnoreMe.ShouldExist)} to be available");
				Assert.IsTrue(model.Properties.All(x => x.Name != nameof(DoNotIgnoreMe.ShouldNotExist)), $"Expected the {nameof(DoNotIgnoreMe.ShouldNotExist)} to not be available");
			}
		}

	}
}