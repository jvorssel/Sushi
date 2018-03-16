using System;
using ModelConverter.DefinitelyTyped.Properties;
using ModelConverter.Interfaces;

namespace ModelConverter.DefinitelyTyped
{
	public static class ConversionKernelExtensions
	{
		/// <summary>
		///     Initialize a <see cref="ModelConverter"/> to work with creating DefinitelyTyped files.
		/// </summary>
		/// <param name="this">The <see cref="ConversionKernel"/> to use.</param>
		/// <returns></returns>
		public static ModelConverter CreateConverterForDefinitelyTyped(this ConversionKernel @this)
		{
			var language = new DefinitelyTypedSpecification("DefinitelyTyped", new Version(1, 0))
				.UseTemplate(Resources._interface);

			var converter = @this.CreateConverterForTemplate(language);
			return converter;
		}
	}
}