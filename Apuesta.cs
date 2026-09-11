using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRuleta
{
    internal class Apuesta
    {
        public string Tipo {  get; set; }
        public string Valor { get; set; }
        public decimal Monto { get; set; }
        public int Multiplicador { get; set; }
        public Apuesta(String tipo, string valor, decimal monto, int multiplicador)
        {
            Tipo = tipo;
            Valor = valor;
            Monto = monto;
            Multiplicador = multiplicador;
        }
        public override string ToString()
        {
            return $"Tipo: {Tipo}, Valor: {Valor}, Monto: {Monto:C}, Multiplicador: x{Multiplicador}";
        }
    }
}
