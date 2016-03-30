namespace TelefoneLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Tests
    {
        [TestMethod]
        public void SpaceWithoutNine()
        {
            var phone = Telefone.Parse("11 23456789");

            Assert.IsNotNull(phone);

            Assert.AreEqual("11", phone.AreaCode);
            Assert.AreEqual("23456789", phone.Number);
            Assert.AreEqual(true, phone.Landline);
            Assert.AreEqual(State.SaoPaulo, phone.State);
        }

        [TestMethod]
        public void SpaceWithNine()
        {
            var phone = Telefone.Parse("11 987654321");

            Assert.IsNotNull(phone);

            Assert.AreEqual("11", phone.AreaCode);
            Assert.AreEqual("987654321", phone.Number);
            Assert.AreEqual(false, phone.Landline);
            Assert.AreEqual(State.SaoPaulo, phone.State);
        }
    }
}
