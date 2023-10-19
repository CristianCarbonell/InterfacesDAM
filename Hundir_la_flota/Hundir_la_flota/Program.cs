using Hundir_la_flota;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego();
            juego.IniciarJuego();
        }
    }
}