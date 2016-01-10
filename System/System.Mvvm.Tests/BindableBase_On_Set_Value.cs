using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Mvvm.Tests
{
    [TestClass]
    public class BindableBase_On_Set_Value
    {
        [TestMethod]
        public void Should_Raise_Property_Changed_Event_When_Property_Is_Changed()
        {
            var isPropertyChanged = false;
            var testBindableBase = new TestBindableBase();
            testBindableBase.PropertyChanged +=
                (sender, args) =>
                {
                    if (args.PropertyName.Equals("Property"))
                        isPropertyChanged = true;
                };

            testBindableBase.Property = new object();

            Assert.IsTrue(isPropertyChanged,
                "When any observable propery of Bindable base is changed it is supposed to raise property changed " +
                "event with that property name as argument!");
        }
    }

    public class TestBindableBase : BindableBase
    {
        public object Property
        {
            get { return GetValue<object>(); }
            set { SetValue(value, "Property"); }
        }
    }
}