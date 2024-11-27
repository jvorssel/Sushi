using System;
using System.IO;
using System.Text;
using Sushi.Tests.Extensions;

namespace Sushi.Tests;

public abstract class TestBase
{
	protected const string XmlFileName = "Sushi.TestModels.xml";
	
	/// <summary>
	///     Write the generated script values to the file.
	/// </summary>
	internal void WriteToFile(string script, string path, Encoding? encoding = null)
	{
		if (path.IsEmpty())
			throw new ArgumentNullException(nameof(path));

		var directory = Path.GetDirectoryName(path) ?? string.Empty;
		if (!Directory.Exists(directory))
			Directory.CreateDirectory(directory);

		File.WriteAllText(path, script, encoding ?? Encoding.Default);
	}
}