using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    class Jugador
    {
        public string nombre { get; }
        public List<Barco> barcos { get; } = new List<Barco>();
        public Tablero tableroPropio { get; } = new Tablero();
        public Tablero tableroOponente { get; } = new Tablero();

        public Jugador(string nombre)
        {
            this.nombre = nombre;
        }

        public virtual void ColocarBarcos()
        {
            for (int i = 0; i < 5; i++) // El jugador coloca 5 barcos
            {
                Console.WriteLine($"{nombre}, coloca tu barco de tamaño 3:");
                Barco barco = new Barco();

                while (true)
                {
                    Console.Write("Coordenada Letra (a-j): ");
                    char letra = Console.ReadLine().ToLower()[0];

                    Console.Write("Coordenada Número (1-10): ");
                    int numero = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Orientación (H para horizontal, V para vertical): ");
                    char orientacionInput = Console.ReadLine().ToLower()[0];
                    bool orientacionHorizontal = orientacionInput == 'h';

                    barco.orientacionHorizontal = orientacionHorizontal;
                    barco.AgregarPosicion(letra, numero);

                    if (tableroPropio.ColocarBarco(barco, new Coordenada(letra, numero)))
                    {
                        Console.WriteLine("Barco colocado con éxito.");
                        tableroPropio.DibujarTablero();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No se pudo colocar el barco en esa posición. Inténtalo de nuevo.");
                    }
                }

                barcos.Add(barco);
            }
        }

        public virtual bool RealizarDisparo(Jugador oponente, Coordenada coordenada)
        {
            bool impacto = oponente.tableroPropio.RealizarDisparo(coordenada);

            if (impacto)
            {
                Console.WriteLine("Tocado.");
            }
            else
            {
                Console.WriteLine("Agua.");
            }

            return impacto;
        }
    }
}
