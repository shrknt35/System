using System.Mvvm.EventArgs;

namespace System.Mvvm
{
	public interface IProcedure<TResultType>
	{
		event EventHandler<AssociatableEventArgs<TResultType>> Started;

		event EventHandler<AssociatableEventArgs<TResultType>> Failed;

		event EventHandler<AssociatableEventArgs<TResultType>> Completed;
	}
}