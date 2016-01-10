namespace System.IO.Helpers
{
	public static class ExceptionToErrorConverterExtension
	{
		public static FileCreationError ToFileCreationError(this Exception ex)
		{
			var fileCreationError = FileCreationError.None;

			if (ex is UnauthorizedAccessException)
			{
				fileCreationError = FileCreationError.NotEnoughPermissions;
			}
			if (ex is ArgumentNullException)
			{
				fileCreationError = FileCreationError.NullPath;
			}
			if (ex is ArgumentException)
			{
				fileCreationError = FileCreationError.InvalidPath;
			}
			if (ex is PathTooLongException)
			{
				fileCreationError = FileCreationError.PathTooLong;
			}
			if (ex is DirectoryNotFoundException)
			{
				fileCreationError = FileCreationError.DirectoryNotFound;
			}
			if (ex is IOException)
			{
				fileCreationError = FileCreationError.IOError;
			}
			if (ex is NotSupportedException)
			{
				fileCreationError = FileCreationError.PathFormatInvalid;
			}

			return fileCreationError;
			
		}
	}
}