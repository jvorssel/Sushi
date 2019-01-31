using System.Collections.Generic;
using System.Linq;
using Sushi.Consistency;
using Sushi.Enum;
using static Sushi.Consistency.TemplateKeys;

namespace Sushi.Helpers
{
	public static class TemplateConsistency
	{
		public static readonly Dictionary<TemplateKeyType, List<string>> KeysWithType =
			new Dictionary<TemplateKeyType, List<string>>
			{
				{
					TemplateKeyType.Comment,
					new List<string>
					{
						SUMMARY_KEY,
						TYPE_NAME_KEY,
						TYPE_NAMESPACE_KEY
					}
				},

				{
					TemplateKeyType.Validation,
					new List<string>
					{
						VALIDATION_KEY,
						IS_DEFINED_CHECK,
						IS_UNDEFINED_CHECK
					}
				},

				{
					TemplateKeyType.Definition, new List<string>
					{
						CLASS_PROPERTIES_KEY,
						CTOR_PROPERTIES_KEY,
						ARGUMENT_NAME,
					}
				}
			};

		public static IEnumerable<string> Keys => KeysWithType.SelectMany(kv => kv.Value);

		/// <summary>
		///     Find what <see cref="TemplateKeys"/> are not used by the given <paramref name="templateContent"/>.
		/// </summary>
		/// <returns>The <see cref="List{T}"/> of missing <see cref="TemplateKeys"/>.</returns>
		public static IEnumerable<string> TestTemplate(string templateContent)
			=> Keys.Where(key => !templateContent.Contains(key));

		/// <summary>
		///     If the given <paramref name="template"/> uses the correct $$<see cref="TemplateKeys.SCRIPT_MODELS"/>$$ placeholder.
		/// </summary>
		public static bool TestWrapTemplate(string template) => template.Contains(SCRIPT_MODELS);
	}
}