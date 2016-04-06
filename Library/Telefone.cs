namespace TelefoneLibrary
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Brazilian phone number utility class.
    /// </summary>
    public static class Telefone
    {
        /// <summary>
        /// Parses the given brazilian phone number.
        /// Checks for numbers in the formats
        /// "AANNNNNNNN", "AA NNNNNNNN", "AA9NNNNNNNN", "AA NNNN-NNNN", "AA 9NNNNNNNN", "AA 9NNNN-NNNN"
        /// </summary>
        /// <param name="number">Phone number to parse</param>
        /// <returns>The parsed phone number</returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "26 is almost 25.")]
        public static PhoneNumber Parse(string number)
        {
            if (number == null)
                throw new ArgumentNullException("number");

            // trim
            number = number.Trim();

            // too short
            if (number.Length < 10)
                return null;
            
            // checking the phone number string
            if (
                // 'AANNNNNNNN'
                (number.Length != 10) &&

                 // 'AA NNNNNNNN'
                (number.Length != 11 && number[2] != ' ') &&

                 // 'AA9NNNNNNNN'
                (number.Length != 11 && number[2] != '9') &&

                 // 'AA NNNN-NNNN'
                (number.Length != 12 && number[2] != ' ' && number[7] != '-') &&

                 // 'AA 9NNNNNNNN'
                (number.Length != 12 && number[2] != ' ' && number[3] != '9') &&

                 // 'AA 9NNNN-NNNN'
                (number.Length != 13 && number[2] != ' ' && number[3] != '9' && number[8] != '-')
            )
                return null;

            // striping off the mask
            var digits = new string(number.Where(char.IsDigit).ToArray());

            // checking the phone number digits
            if (
                // 'AANNNNNNNN'
                (digits.Length != 10) &&

                 // 'AA9NNNNNNNN'
                (digits.Length != 11 && digits[8] != '9')
            )
                return null;

            // getting the area code
            var areaCode = string.Join(string.Empty, digits.Take(2));

            // getting the phone number
            var phoneNumber = string.Join(string.Empty, digits.Skip(2));

            // a phone number can't start with '0' or '1'
            if (phoneNumber.Length == 8 && (phoneNumber[0] == '0' || phoneNumber[0] == '1'))
                return null;

            // finding out if it's a landline number
            var landline = phoneNumber[0] >= '2' && phoneNumber[0] <= '5';

            // finding the area code state
            var state = FindState(areaCode);

            // an invalid area code were found
            if (state == null)
                return null;

            // here, take it
            return new PhoneNumber(areaCode, phoneNumber, landline, state.Value);
        }

        // https://en.wikipedia.org/wiki/List_of_dialling_codes_in_Brazil
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "It's just a long switch case.")]
        private static State? FindState(string areaCode)
        {
            int _areaCode;
            if (int.TryParse(areaCode, out _areaCode))
            {
                switch (_areaCode)
                {
                    case 11: // Sao Paulo metropolitan area
                    case 12: // Vale do Paraíba (São José dos Campos, Taubaté, Guaratinguetá) and Northern coast (Ubatuba, São Sebastião)
                    case 13: // Baixada Santista (Santos, Guarujá, Cubatão) and South (Registro, Iguape)
                    case 14: // Central (Bauru, Marília, Botucatu)
                    case 15: // Southwest (Sorocaba, Itapetininga)
                    case 16: // Northeast (Ribeirão Preto, Franca, São Carlos)
                    case 17: // Northwest (São José do Rio Preto, Catanduva)
                    case 18: // West (Presidente Prudente, Araçatuba)
                    case 19: // Central-South (Campinas, Piracicaba, Rio Claro)
                        return State.SaoPaulo;

                    case 21: // Greater Rio de Janeiro and Teresópolis
                    case 22: // East and North (Campos dos Goytacazes, Cabo Frio, Nova Friburgo)
                    case 23: // reserved
                    case 24: // West (Petrópolis, Volta Redonda, Angra dos Reis)
                    case 25: // reserved
                    case 26: // reserved
                        return State.RioDeJaneiro;

                    case 27: // Central and North (Vitória, Linhares, Colatina)
                    case 28: // South (Cachoeiro de Itapemirim)
                    case 29: // reserved
                        return State.EspiritoSanto;

                    case 31: // Central (Greater Belo Horizonte, Sete Lagoas, Ipatinga)
                    case 32: // Southeast (Juiz de Fora, Muriaé, Barbacena)
                    case 33: // East and Northeast (Governador Valadares, Teófilo Otoni, Almenara)
                    case 34: // West (Uberlândia, Uberaba, Patos de Minas)
                    case 35: // Southwest (Poços de Caldas, Varginha, Pouso Alegre)
                    case 36: // reserved
                    case 37: // Central-West (Divinópolis)
                    case 38: // North (Montes Claros, Diamantina, Januária, Paracatu)
                    case 39: // reserved
                        return State.MinasGerais;

                    case 41: // Greater Curitiba and coast (Paranaguá)
                    case 42: // Central-South (Ponta Grossa, Guarapuava)
                    case 43: // Northeast (Londrina, Apucarana)
                    case 44: // Northwest (Maringá, Umuarama)
                    case 45: // West (Foz do Iguaçu, Cascavel)
                    case 46: // Southwest (Francisco Beltrão, Pato Branco)
                        return State.Parana;

                    case 47: // Northeast (Joinville, Blumenau, Itajaí)
                    case 48: // Greater Florianópolis and South (Criciúma, Tubarão)
                    case 49: // Central and West (Lages, Chapecó)
                        return State.SantaCatarina;

                    case 51: // Greater Porto Alegre, Central-South (Santa Cruz do Sul), Northern coast (Torres)
                    case 52: // reserved
                    case 53: // South (Pelotas, Rio Grande, Bagé)
                    case 54: // North (Caxias do Sul, Passo Fundo)
                    case 55: // Central and West (Santa Maria, Uruguaiana, Cruz Alta)
                    case 56: // reserved
                    case 57: // reserved
                    case 58: // reserved
                    case 59: // reserved
                        return State.RioGrandeDoSul;

                    case 61: // entire Federal District (Brasília) and surrounding area of Goiás state
                    case 62: // Central and North (Greater Goiânia, Anápolis, Porangatu)
                    case 64: // South and West (Rio Verde, Itumbiara, Catalão)
                        return State.Goias;

                    case 63: // entire State of Tocantins (capital city Palmas)
                        return State.Tocantins;

                    case 65: // Southwest (Cuiabá, Cáceres)
                    case 66: // East and North (Rondonópolis, Sinop)
                        return State.MatoGrosso;

                    case 67: // entire State of Mato Grosso do Sul (capital city Campo Grande)
                        return State.MatoGrossoDoSul;

                    case 68: // entire State of Acre (capital city Rio Branco)
                        return State.Acre;

                    case 69: // entire State of Rondônia (capital city Porto Velho)
                        return State.Rondonia;

                    case 71: // Greater Salvador
                    case 72: // reserved
                    case 73: // South (Ilhéus, Itabuna, Porto Seguro, Jequié)
                    case 74: // Northwest (Juazeiro, Jacobina)
                    case 75: // Northeast (Feira de Santana, Alagoinhas)
                    case 76: // reserved
                    case 77: // Southwest and West (Vitória da Conquista, Barreiras)
                    case 78: // reserved
                        return State.Bahia;

                    case 79: // entire State of Sergipe (capital city Aracaju)
                        return State.Sergipe;

                    case 81: // East (Greater Recife, Caruaru, Fernando de Noronha)
                    case 87: // Central and West (Petrolina, Garanhuns)
                        return State.Pernambuco;

                    case 82: // entire State of Alagoas (capital city Maceió)
                        return State.Alagoas;

                    case 83: // entire State of Paraíba (capital city João Pessoa)
                        return State.Paraiba;

                    case 84: // entire State of Rio Grande do Norte (capital city Natal)
                        return State.RioGrandeDoNorte;

                    case 85: // Greater Fortaleza
                    case 88: // Central, West and South (Juazeiro do Norte, Sobral)
                        return State.Ceara;

                    case 86: // North (Teresina, Parnaíba)
                    case 89: // Central and South (Picos, Floriano)
                        return State.Piaui;

                    case 91: // Northeast (Greater Belém, Capanema)
                    case 93: // Central and West (Santarém, Altamira)
                    case 94: // Southeast (Marabá, Carajás)
                        return State.Para;

                    case 92: // Northeast (Greater Manaus, Itacoatiara, Parintins)
                    case 97: // Central, South and West (Coari, Tabatinga, Humaitá)
                        return State.Amazonas;

                    case 95: // entire State of Roraima (capital city Boa Vista)
                        return State.Roraima;

                    case 96: // entire State of Amapá (capital city Macapá)
                        return State.Amapa;

                    case 98: // North (Greater São Luís, Pinheiro)
                    case 99: // Central and South (Imperatriz, Caxias)
                        return State.Maranhao;
                }
            }

            return null;
        }
    }
}
