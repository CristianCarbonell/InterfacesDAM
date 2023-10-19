using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    class Juego
    {
        private List<Jugador> jugadores = new List<Jugador>();
        private int turnoActual = 0;

        public void IniciarJuego()
        {
            Console.WriteLine("¡Bienvenido a Hundir la Flota!");

            Jugador jugador1 = new Jugador("Jugador 1");
            JugadorOrdenador jugador2 = new JugadorOrdenador(); // Usamos JugadorOrdenador

            jugador1.barcos.Add(new Barco());
            jugador2.barcos.Add(new Barco());

            jugadores.Add(jugador1);
            jugadores.Add(jugador2);

            jugador1.ColocarBarcos();
            jugador2.ColocarBarcos();

            Console.WriteLine("Comienza el juego.");

            while (!JuegoTerminado())
            {
                MostrarTableroActual();
                jugadores[turnoActual].RealizarDisparo(jugadores[(turnoActual + 1) % 2], ElegirCoordenada());
                turnoActual = (turnoActual + 1) % 2;
            }

            MostrarTableroActual();
            Console.WriteLine($"¡El jugador {jugadores[turnoActual].nombre} ha ganado!");
        }

        private void MostrarTableroActual()
        {
            Console.WriteLine("Tablero del Jugador 1:");
            jugadores[0].tableroOponente.DibujarTablero();
            Console.WriteLine("Tablero del Jugador 2:");
            jugadores[1].tableroOponente.DibujarTablero();
        }

        private bool JuegoTerminado()
        {
            return jugadores[0].barcos.Count == 0 || jugadores[1].barcos.Count == 0;
        }

        private Coordenada ElegirCoordenada()
        {
            Console.WriteLine($"{jugadores[turnoActual].nombre}, elige una coordenada para disparar:");

            while (true)
            {
                Console.Write("Coordenada Letra (a-j): ");
                char letra = Console.ReadLine().ToLower()[0];

                Console.Write("Coordenada Número (1-10): ");
                int numero = Convert.ToInt32(Console.ReadLine());

                if (numero >= 1 && numero <= 10)
                {
                    return new Coordenada(letra, numero);
                }
                else
                {
                    Console.WriteLine("Coordenada Número no válida. Inténtalo de nuevo.");
                }
            }
        }
    }
}
