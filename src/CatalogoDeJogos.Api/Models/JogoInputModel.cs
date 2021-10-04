using Newtonsoft.Json;

namespace CatalogoDeJogos.Api.Models
{
    public class JogoInputModel
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("produtora")]
        public string Produtora { get; set; }

        [JsonProperty("preco")]
        public double Preco { get; set; }
    }
}