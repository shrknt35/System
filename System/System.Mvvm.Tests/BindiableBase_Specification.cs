using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Mvvm.Tests
{
    [TestClass]
    public class BindiableBase_Specification
    {
        [TestMethod]
        public void Has_To_Be_Abstract()
        {
            var bindableBaseType = typeof(BindableBase);

            Assert.IsTrue(bindableBaseType.IsAbstract, "Bindable base should be abstract.");
        }
    }
}