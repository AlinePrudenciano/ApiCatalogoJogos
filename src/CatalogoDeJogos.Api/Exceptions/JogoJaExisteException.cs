using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Api.Exceptions
{
    public class JogoJaExisteException : Exception
    {
        public JogoJaExisteException() : base("Este jogo já existe.")
        {

        }
    }
}
