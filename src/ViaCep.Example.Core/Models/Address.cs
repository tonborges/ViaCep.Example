using System.Text.Json.Serialization;

namespace ViaCep.Example.Core.Models
{
    public class Address
    {
        [JsonPropertyName("cep")]
        public string ZipCode { get; set; }
        [JsonPropertyName("logradouro")]
        public string PublicPlace { get; set; }
        [JsonPropertyName("complemento")]
        public string Complement { get; set; }
        [JsonPropertyName("bairro")]
        public string Neighborhood { get; set; }
        [JsonPropertyName("localidade")]
        public string Location { get; set; }
        [JsonPropertyName("uf")]
        public string State { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }
    }
}