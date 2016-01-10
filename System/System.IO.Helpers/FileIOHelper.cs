using System.Common;

namespace System.IO.Helpers
{
	public class FileIOHelper
	{
		private IResult<FileStream, FileCreationError> Create(string filePath)
		{
			FileStream fileStream = null;
			var fileCreationError = FileCreationError.None;

			try
			{
				fileStream = File.Create(filePath);
			}
			catch (Exception ex)
			{
				fileCreationError = ex.ToFileCreationError();
			}

			return new Result<FileStream, FileCreationError>(fileStream, fileCreationError,
				fileCreationError == FileCreationError.None);
		}

		private IResult<FileStream, FileCreationError> Create(string filePath, int bufferSize)
		{
			FileStream fileStream = null;
			var fileCreationError = FileCreationError.None;

			try
			{
				fileStream = File.Create(filePath, bufferSize);
			}
			catch (Exception ex)
			{
				fileCreationError = ex.ToFileCreationError();
			}

			return new Result<FileStream, FileCreationError>(fileStream, fileCreationError,
				fileCreationError == FileCreationError.None);
		}
	}
}