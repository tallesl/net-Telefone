namespace TelefoneLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Tests
    {
        [TestMethod]
        public void DashAndSpaceWithoutNine()
        {
            var phone = Telefone.Parse("11 2345-6789");

            Assert.IsNotNull(phone);

            Assert.AreEqual("11", phone.AreaCode);
            Assert.AreEqual("23456789", phone.Number);
            Assert.AreEqual(true, phone.Landline);
            Assert.AreEqual(State.SaoPaulo, phone.State);
        }

        [TestMethod]
        public void DashAndSpaceWithNine()
        {
            var phone = Telefone.Parse("11 98765-4321");

            Assert.IsNotNull(phone);

            Assert.AreEqual("11", phone.AreaCode);
            Assert.AreEqual("987654321", phone.Number);
            Assert.AreEqual(false, phone.Landline);
            Assert.AreEqual(State.SaoPaulo, phone.State);
        }
    }
}
