namespace TelefoneLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Tests
    {
        [TestMethod]
        public void DashWithoutNine()
        {
            var phone = Telefone.Parse("112345-6789");

            Assert.IsNotNull(phone);

            Assert.AreEqual("11", phone.AreaCode);
            Assert.AreEqual("23456789", phone.Number);
            Assert.AreEqual(true, phone.Landline);
            Assert.AreEqual(State.SaoPaulo, phone.State);
        }

        [TestMethod]
        public void DashWithNine()
        {
            var phone = Telefone.Parse("1198765-4321");

            Assert.IsNotNull(phone);

            Assert.AreEqual("11", phone.AreaCode);
            Assert.AreEqual("987654321", phone.Number);
            Assert.AreEqual(false, phone.Landline);
            Assert.AreEqual(State.SaoPaulo, phone.State);
        }
    }
}
