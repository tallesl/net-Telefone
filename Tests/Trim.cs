namespace TelefoneLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Tests
    {
        [TestMethod]
        public void Trim()
        {
            Assert.IsNotNull(Telefone.Parse(" 11 98765-4321"));
            Assert.IsNotNull(Telefone.Parse("11 98765-4321 "));
            Assert.IsNotNull(Telefone.Parse(" 11 98765-4321 "));
            Assert.IsNotNull(Telefone.Parse("\t11987654321\t"));
        }
    }
}
