using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRuleta
{
    internal class Jugador
    {
        public decimal DineroInicial {  get; set; }
        public decimal DineroActual { get; set;  }
        public Jugador(decimal dineroInicial)
        {
            DineroInicial = dineroInicial;
            DineroActual = dineroInicial;
        }
        public void Ganar(decimal monto)
        {
            DineroActual += monto;
        }
        public void Perder(decimal monto)
        {
            DineroActual -= monto;
        }
        public bool TieneDinero()
        {
            return DineroActual > 0;
        }

        public decimal ObtenerGananciaTotal()
        {
            return DineroActual - DineroInicial;
        }

        public override string ToString()
        {
            return $"Dinero actual: {DineroActual:C}";
        }
    }
}
