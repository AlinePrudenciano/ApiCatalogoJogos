using CatalogoDeJogos.Api.Entities;
using CatalogoDeJogos.Api.Exceptions;
using CatalogoDeJogos.Api.Interfaces.Services;
using CatalogoDeJogos.Api.Models;
using CatalogoDeJogos.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoDeJogos.Api.Services
{
    public class JogoService : IJogoService
    {
        private IJogoRepository repository;

        public JogoService(IJogoRepository repository)
        {
            this.repository = repository;
        }

        public JogoViewModel Add(JogoInputModel jogo)
        {
            var jogoEntity = repository.Get().FirstOrDefault(x => x.Nome == jogo.Nome && x.Produtora == jogo.Produtora);

            if (jogoEntity != null)
                throw new JogoJaExisteException();

            jogoEntity = new Jogo()
            {
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            repository.Add(jogoEntity);

            return new JogoViewModel()
            {
                Id = jogoEntity.Id,
                Nome = jogoEntity.Nome,
                Preco = jogoEntity.Preco,
                Produtora = jogoEntity.Produtora
            };
        }

        public void Delete(Guid id)
        {
            var jogoEntity = repository.Find(id);

            if (jogoEntity == null)
                throw new JogoNaoExisteException();

            repository.Delete(jogoEntity);
        }

        public List<JogoViewModel> Get(int page, int quantity)
        {
            return repository.Get().Skip((page - 1) * quantity).Take(quantity).Select(x => new JogoViewModel()
            {
                Id = x.Id,
                Nome = x.Nome,
                Preco = x.Preco,
                Produtora = x.Produtora
            }).ToList();
        }

        public JogoViewModel Find(Guid id)
        {
            var jogo = repository.Find(id);

            if (jogo == null)
                return null;

            return new JogoViewModel()
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Produtora = jogo.Produtora
            };
        }

        public JogoViewModel Update(Guid id, JogoInputModel jogo)
        {
            var jogoEntity = repository.Find(id);

            if (jogoEntity == null)
                throw new JogoNaoExisteException();

            jogoEntity.Nome = jogo.Nome;
            jogoEntity.Preco = jogo.Preco;
            jogoEntity.Produtora = jogo.Produtora;

            repository.Update(jogoEntity);

            return new JogoViewModel()
            {
                Id = jogoEntity.Id,
                Nome = jogoEntity.Nome,
                Preco = jogoEntity.Preco,
                Produtora = jogoEntity.Produtora
            };
        }

        public JogoViewModel UpdatePrice(Guid id, double preco)
        {
            var jogoEntity = repository.Find(id);

            if (jogoEntity == null)
                throw new JogoNaoExisteException();

            jogoEntity.Preco = preco;

            repository.Update(jogoEntity);

            return new JogoViewModel()
            {
                Id = jogoEntity.Id,
                Nome = jogoEntity.Nome,
                Preco = jogoEntity.Preco,
                Produtora = jogoEntity.Produtora
            };
        }
    }
}
