namespace TelefoneLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Tests
    {
        [TestMethod]
        public void EqualityWithoutNine()
        {
            var phone1 = Telefone.Parse("1187654321");
            var phone2 = Telefone.Parse("11 87654321");
            var phone3 = Telefone.Parse("11 8765-4321");

            Assert.IsNotNull(phone1);
            Assert.IsNotNull(phone2);
            Assert.IsNotNull(phone3);

            Assert.AreEqual(phone1, phone2);
            Assert.AreEqual(phone2, phone3);
        }

        [TestMethod]
        public void EqualityWithNine()
        {
            var phone1 = Telefone.Parse("11987654321");
            var phone2 = Telefone.Parse("11 987654321");
            var phone3 = Telefone.Parse("11 98765-4321");

            Assert.IsNotNull(phone1);
            Assert.IsNotNull(phone2);
            Assert.IsNotNull(phone3);

            Assert.AreEqual(phone1, phone2);
            Assert.AreEqual(phone2, phone3);
        }
    }
}
