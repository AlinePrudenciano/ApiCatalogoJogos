using CatalogoDeJogos.Api.Entities;
using CatalogoDeJogos.Api.Models;
using System;
using System.Collections.Generic;

namespace CatalogoDeJogos.Api.Interfaces.Services
{
    public interface IJogoService
    {
        
        List<JogoViewModel> Get(int page = 1, int quantity = 5);

        JogoViewModel Find(Guid id);

        JogoViewModel Add(JogoInputModel jogo);

        JogoViewModel Update(Guid id, JogoInputModel jogo);

        JogoViewModel UpdatePrice(Guid id, double preco);

        void Delete(Guid id);
    }
}
