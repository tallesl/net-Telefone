namespace TelefoneLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Tests
    {
        [TestMethod]
        public void States()
        {
            Assert.AreEqual(State.Acre, Telefone.Parse("68 23456789").State);
            Assert.AreEqual(State.Alagoas, Telefone.Parse("82 23456789").State);
            Assert.AreEqual(State.Amapa, Telefone.Parse("96 23456789").State);
            Assert.AreEqual(State.Amazonas, Telefone.Parse("92 23456789").State);
            Assert.AreEqual(State.Bahia, Telefone.Parse("71 23456789").State);
            Assert.AreEqual(State.Ceara, Telefone.Parse("85 23456789").State);
            Assert.AreEqual(State.EspiritoSanto, Telefone.Parse("27 23456789").State);
            Assert.AreEqual(State.Goias, Telefone.Parse("61 23456789").State);
            Assert.AreEqual(State.Maranhao, Telefone.Parse("98 23456789").State);
            Assert.AreEqual(State.MatoGrosso, Telefone.Parse("65 23456789").State);
            Assert.AreEqual(State.MatoGrossoDoSul, Telefone.Parse("67 23456789").State);
            Assert.AreEqual(State.MinasGerais, Telefone.Parse("31 23456789").State);
            Assert.AreEqual(State.Para, Telefone.Parse("91 23456789").State);
            Assert.AreEqual(State.Paraiba, Telefone.Parse("83 23456789").State);
            Assert.AreEqual(State.Parana, Telefone.Parse("41 23456789").State);
            Assert.AreEqual(State.Pernambuco, Telefone.Parse("81 23456789").State);
            Assert.AreEqual(State.Piaui, Telefone.Parse("86 23456789").State);
            Assert.AreEqual(State.RioDeJaneiro, Telefone.Parse("21 23456789").State);
            Assert.AreEqual(State.RioGrandeDoNorte, Telefone.Parse("84 23456789").State);
            Assert.AreEqual(State.RioGrandeDoSul, Telefone.Parse("51 23456789").State);
            Assert.AreEqual(State.Rondonia, Telefone.Parse("69 23456789").State);
            Assert.AreEqual(State.Roraima, Telefone.Parse("95 23456789").State);
            Assert.AreEqual(State.SantaCatarina, Telefone.Parse("47 23456789").State);
            Assert.AreEqual(State.SaoPaulo, Telefone.Parse("11 23456789").State);
            Assert.AreEqual(State.Sergipe, Telefone.Parse("79 23456789").State);
            Assert.AreEqual(State.Tocantins, Telefone.Parse("63 23456789").State);
        }
    }
}
