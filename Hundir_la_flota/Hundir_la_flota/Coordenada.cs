using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    class Coordenada
    {
        public char letra { get; }
        public int numero { get; }

        public Coordenada(char letra, int numero)
        {
            this.letra = letra;
            this.numero = numero;
        }
    }
}
