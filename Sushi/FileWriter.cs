using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Sushi.Models;
using Sushi.Utility;

namespace Sushi
{
	public class FileWriter
	{
		private readonly ModelConverter _converter;
		private readonly string _extension;
		private readonly string _path;
		private readonly bool _minify;
		private readonly Encoding _encoding;

		public FileWriter(ModelConverter converter, string path, string extension, bool minify = false, Encoding encoding = null)
		{
			if (path.IsEmpty())
				throw new ArgumentNullException(nameof(converter));

			_converter = converter ?? throw new ArgumentNullException(nameof(converter));
			_extension = extension;
			_path = path.Replace('/', '\\').TrimEnd('\\');
			_minify = minify;
			_encoding = encoding ?? Encoding.Default;

			if (!Directory.Exists(_path))
				Directory.CreateDirectory(_path);
		}


		public void FlushToFile(DataModel model, string fileName = "")
			=> FlushToFile(new List<DataModel> { model }, fileName);

		public async Task FlushToFileAsync(DataModel model, string fileName = "")
			=> await FlushToFileAsync(new List<DataModel> { model }, fileName);

		public void FlushToFile(IEnumerable<DataModel> models, string fileName = "")
		{
			fileName = Path.GetFileNameWithoutExtension(fileName);

			// Default to model name as name
			if (fileName.IsEmpty())
				fileName = $@"Generated_{"".GetTimeStamp()}";

			var fileContent = _converter.JoinModels(models, _minify);
			var filePath = $@"{_path}\{fileName}{_extension}";

			File.WriteAllText(filePath, fileContent, _encoding);
		}

		public async Task FlushToFileAsync(IEnumerable<DataModel> models, string fileName = "")
		{
			fileName = Path.GetFileNameWithoutExtension(fileName);

			// Default to model name as name
			if (fileName.IsEmpty())
				fileName = $@"Generated_{"".GetTimeStamp()}";

			var fileContent = _converter.JoinModels(models, _minify);
			var filePath = $@"{_path}\{fileName}{_extension}";

			using (var writer = new StreamWriter(filePath, false, _encoding))
			{
				await writer.WriteAsync(fileContent);
				await writer.FlushAsync();

				writer.Close();
				writer.Dispose();
			}
		}
	}
}