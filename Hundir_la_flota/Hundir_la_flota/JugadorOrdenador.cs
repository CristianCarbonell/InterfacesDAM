using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    class JugadorOrdenador : Jugador
    {
        private Random random = new Random();

        public JugadorOrdenador() : base("Ordenador")
        {
        }

        public override void ColocarBarcos()
        {
            foreach (Barco barco in barcos)
            {
                bool barcoColocado = false;

                while (!barcoColocado)
                {
                    char letra = (char)('a' + random.Next(10));
                    int numero = random.Next(1, 11);

                    // El ordenador selecciona una orientación al azar
                    bool orientacionHorizontal = random.Next(2) == 0;
                    barco.orientacionHorizontal = orientacionHorizontal;

                    barco.AgregarPosicion(letra, numero);

                    if (tableroPropio.ColocarBarco(barco, new Coordenada(letra, numero)))
                    {
                        barcoColocado = true;
                    }
                }
            }

            Console.WriteLine("El ordenador ha colocado sus barcos.");
        }

        public override bool RealizarDisparo(Jugador oponente, Coordenada coordenada)
        {
            char letra = (char)('a' + random.Next(10));
            int numero = random.Next(1, 11);
            coordenada = new Coordenada(letra, numero);

            bool impacto = oponente.tableroPropio.RealizarDisparo(coordenada);

            Console.WriteLine($"El ordenador dispara a {letra}{numero}...");

            if (impacto)
            {
                Console.WriteLine("¡Tocado!");
            }
            else
            {
                Console.WriteLine("Agua.");
            }

            return impacto;
        }
    }
}
