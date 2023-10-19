using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
   class Tablero
{
    private Celda[,] celdas = new Celda[10, 10];

    private int letraAColumna(char letra)
    {
        return letra - 'a';
    }

    public Tablero()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                celdas[i, j] = new Celda();
            }
        }
    }

    public void DibujarTablero()
    {
        Console.WriteLine("   a b c d e f g h i j");
        for (int i = 0; i < 10; i++)
        {
            Console.Write((i + 1) + " ");
            for (int j = 0; j < 10; j++)
            {
                if (celdas[i, j].ocupada)
                {
                    Console.Write("X ");
                }
                else
                {
                    Console.Write("~ ");
                }
            }
            Console.WriteLine();
        }
    }

    public bool ColocarBarco(Barco barco, Coordenada coordenadaInicial)
    {
        if (barco == null || coordenadaInicial == null)
        {
            return false;
        }

        int x = coordenadaInicial.numero - 1;
        int y = letraAColumna(coordenadaInicial.letra);

        if (x < 0 || x >= 10 || y < 0 || y >= 10)
        {
            return false;
        }

        if (barco.orientacionHorizontal)
        {
            if (y + barco.tamaño > 10)
            {
                return false;
            }

            for (int i = 0; i < barco.tamaño; i++)
            {
                if (celdas[x, y + i].ocupada)
                {
                    return false;
                }
            }

            for (int i = 0; i < barco.tamaño; i++)
            {
                celdas[x, y + i].ocupada = true;
            }
        }
        else
        {
            if (x + barco.tamaño > 10)
            {
                return false;
            }

            for (int i = 0; i < barco.tamaño; i++)
            {
                if (celdas[x + i, y].ocupada)
                {
                    return false;
                }
            }

            for (int i = 0; i < barco.tamaño; i++)
            {
                celdas[x + i, y].ocupada = true;
            }
        }

        return true;
    }

    public bool RealizarDisparo(Coordenada coordenada)
    {
        int x = coordenada.numero - 1;
        int y = letraAColumna(coordenada.letra);

        if (x < 0 || x >= 10 || y < 0 || y >= 10)
        {
            return false;
        }

        if (celdas[x, y].ocupada)
        {
            celdas[x, y].ocupada = false;
            return true; // Hubo impacto (tocado).
        }

        return false; // No hubo impacto (agua).
    }
}
}
