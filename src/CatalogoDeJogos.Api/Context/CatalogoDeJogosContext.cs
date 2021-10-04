using CatalogoDeJogos.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogoDeJogos.Api.Context
{
    public class CatalogoDeJogosContext : DbContext
    {
        public CatalogoDeJogosContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Jogo> Jogos { get; set; }
    }
}
