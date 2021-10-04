using CatalogoDeJogos.Api.Entities;
using System;
using System.Collections.Generic;

namespace CatalogoDeJogos.Api.Repositories
{
    public interface IJogoRepository
    {
        List<Jogo> Get();

        Jogo Find(Guid id);

        void Add(Jogo jogo);

        void Update(Jogo jogo);

        void Delete(Jogo jogo);
    }
}
