using Newtonsoft.Json;
using System;

namespace CatalogoDeJogos.Api.Models
{
    public class JogoViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("produtora")]
        public string Produtora { get; set; }

        [JsonProperty("preco")]
        public double Preco { get; set; }

    }
}
