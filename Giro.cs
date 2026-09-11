using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRuleta
{
    internal class Giro
    {
        public int Numero {  get; set; }
        public string Color { get; set; }
        public Apuesta ApuestaRealizada { get; set;}
        public bool Gano {  get; set; }
        public decimal MontoGanado { get; set; }

        public Giro(int numero, string color, Apuesta apuestaRealizada, bool gano, decimal montoGanado)
        {
            Numero = numero;
            Color = color;
            ApuestaRealizada = apuestaRealizada;
            Gano = gano;
            MontoGanado = montoGanado;
        }

        public override string ToString()
        {
            string resultado = Gano ? $"Ganó {MontoGanado:C}" : "Perdio";
            return $"Salio {Numero} ({Color}) | Aposto a {ApuestaRealizada.Tipo}: {ApuestaRealizada.Valor} | {resultado}";
        }
    }
}
