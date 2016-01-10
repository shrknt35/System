namespace System.Mvvm.EventArgs
{
    public class AssociatableEventArgs<TAssociatedType> : System.EventArgs
    {
        public TAssociatedType AssociatedObject { get; private set; }

        public AssociatableEventArgs(TAssociatedType associatedObject)
        {
            AssociatedObject = associatedObject;
        }
    }
}