using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    class Barco
    {
        public int tamaño { get; } = 3;
        public List<Coordenada> posiciones { get; } = new List<Coordenada>();
        public bool orientacionHorizontal { get; set; }

        public Barco()
        {
            orientacionHorizontal = true; // Por defecto, establecemos la orientación como horizontal.
        }

        public Barco(bool orientacionHorizontal)
        {
            this.orientacionHorizontal = orientacionHorizontal;
        }

        public void AgregarPosicion(char letra, int numero)
        {
            posiciones.Add(new Coordenada(letra, numero));
        }
    }
}
