using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Api.Exceptions
{
    public class JogoNaoExisteException : Exception
    {
        public JogoNaoExisteException() : base("Este jogo não existe.")
        {

        }
    }
}
