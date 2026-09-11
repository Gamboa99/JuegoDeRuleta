using System;
using System.Collections.Generic;
using System.Text;

namespace JuegoRuleta
{
    internal class ManejadorRuleta
    {
        private Ruleta Ruleta;
        private List<Giro> Historial;
        public Jugador Jugador { get; set; }
        
        public ManejadorRuleta()
        {
            Ruleta = new Ruleta();
            Historial = new List<Giro>();
            Jugador = new Jugador(300);
        }
        public bool ApuestaValida(decimal monto)
        {
            return monto > 0 && monto % 10 == 0 && monto <= Jugador.DineroActual;
        }
        public Giro RealizarApuesta(Apuesta apuesta)
        {
            Jugador.Perder(apuesta.Monto);
            int numero = Ruleta.Girar();
            string color = Ruleta.ObtenerColor(numero);
            bool gano = EvaluarApuesta(apuesta, numero, color);
            decimal montoGanado = 0;
            if (gano)
            {
                montoGanado = apuesta.Monto * apuesta.Multiplicador;
                Jugador.Ganar(montoGanado);
            }
            Giro giro = new Giro(numero, color, apuesta, gano, montoGanado);
            Historial.Add(giro);
            return giro;
        }

        private bool EvaluarApuesta(Apuesta apuesta, int numero, string color)
        {
            switch (apuesta.Tipo)
            {
                case "Numero":
                    return numero.ToString() == apuesta.Valor;
                case "Color":
                    return color == apuesta.Valor;
                case "Pares": 
                    if (numero == 0)
                    {
                        return false;
                    }
                    string pares = numero % 2 == 0 ? "Par" : "Impar";
                    return pares == apuesta.Valor;
                default:
                    return false;

            }
        }

        public void MostrarHistorial()
        {
            if(Historial.Count == 0)
            {
                Console.WriteLine("Aun no tienes giros");
                return;
            }
            foreach (Giro item in Historial)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public bool JuegoTerminado()
        {
            return !Jugador.TieneDinero();
        }
    }
}
