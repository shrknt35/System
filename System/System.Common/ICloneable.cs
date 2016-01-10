namespace System.Common
{
	public interface ICloneable<out TCloneable>
	{
		TCloneable Clone();
	}
}