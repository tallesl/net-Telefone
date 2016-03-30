namespace TelefoneLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public partial class Tests
    {
        [TestMethod]
        public void Invalid()
        {
            var phones = new List<PhoneNumber> {
                Telefone.Parse(""),
                Telefone.Parse("text"),
                Telefone.Parse("987654321"),
                Telefone.Parse("0000000000"),
                Telefone.Parse("1111111111"),
                Telefone.Parse("1098765432"),
                Telefone.Parse("0123456789"),
                Telefone.Parse("1112345678"),
                Telefone.Parse("1101234567"),
            };

            phones.ForEach(Assert.IsNull);
        }
    }
}
