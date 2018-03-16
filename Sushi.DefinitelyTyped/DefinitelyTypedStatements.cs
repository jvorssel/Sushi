using System.Collections.Generic;
using Sushi.Models;

namespace Sushi.DefinitelyTyped
{
	public class DefinitelyTypedStatements : StatementPipeline
	{
		#region Overrides of StatementPipeline

		/// <inheritdoc />
		public override Statement ArgumentDefinedStatement(ConversionKernel kernel) 
			=> null;

		/// <inheritdoc />
		public override Statement ArgumentUndefinedStatement(ConversionKernel kernel)
			=> null;

		/// <inheritdoc />
		public override Statement CreateKeyCheckStatement(ConversionKernel kernel, Property property)
			=> null;

		/// <inheritdoc />
		public override Statement CreateUndefinedStatement(ConversionKernel kernel, Property property)
			=> null;

		/// <inheritdoc />
		public override Statement CreateInstanceCheckStatement(ConversionKernel kernel, Property property, IEnumerable<DataModel> dataModels)
			=> null;

		/// <inheritdoc />
		public override Statement CreateTypeCheckStatement(ConversionKernel kernel, Property property)
			=> null;

		#endregion
	}
}