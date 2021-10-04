using System;

namespace CatalogoDeJogos.Api.Entities
{
    public class Jogo
    {
        public Jogo()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }

    }
}
