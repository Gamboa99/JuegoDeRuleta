using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRuleta
{
    internal class Ruleta
    {
        private List<int> NumerosNegros;
        private List<int> NumerosRojos;
        private Random Aleatorio;
        public Ruleta()
        {
            NumerosNegros = new List<int> { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
            NumerosRojos = new List<int> { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
            Aleatorio = new Random();
        }
        public int Girar()
        {
            return Aleatorio.Next(1, 37);
        }
        public string ObtenerColor(int numero)
        {
            if (NumerosNegros.Contains(numero))
            {
                return "Negro";
            }
            else if (NumerosRojos.Contains(numero))
            {
                return "Rojo";
            }
            else
            {
                return "Sin color";
            }
        }
    }
}
