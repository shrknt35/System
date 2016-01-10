namespace System.IO.Helpers
{
	[Flags]
	public enum FileCreationError : uint
	{
		None = 0,
		NotEnoughPermissions = 1,
		NullPath = 2,
		InvalidPath = 4,
		PathTooLong = 8,
		DirectoryNotFound = 16,
		IOError = 32,
		PathFormatInvalid = 64
	}
}