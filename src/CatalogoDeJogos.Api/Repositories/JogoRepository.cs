using CatalogoDeJogos.Api.Entities;
using CatalogoDeJogos.Api.Repositories;
using CatalogoDeJogos.Api.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoDeJogos.Api.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        CatalogoDeJogosContext context;
        public JogoRepository(CatalogoDeJogosContext context)
        {
            this.context = context;
        }
        public void Add(Jogo jogo)
        {
            context.Set<Jogo>().Add(jogo);
            context.SaveChanges();
        }

        public void Delete(Jogo jogo)
        {
            context.Jogos.Remove(jogo);
            context.SaveChanges();
        }

        public List<Jogo> Get()
        {
            return context.Jogos.ToList();
        }
        
        public Jogo Find(Guid id)
        {
            return context.Jogos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Jogo jogo)
        {
            context.Entry(jogo).State = EntityState.Modified;
            context.Jogos.Update(jogo);
            context.SaveChanges();
        }
    }
}
