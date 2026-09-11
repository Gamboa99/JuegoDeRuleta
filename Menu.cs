using System;

namespace JuegoRuleta
{
    internal class Menu
    {
        private readonly string Titulo;
        private readonly string[] Opciones;
        public ManejadorRuleta Manejador { get; set; }

        public Menu(string titulo, string[] opciones)
        {
            Titulo = titulo;
            Opciones = opciones;
            Manejador = new ManejadorRuleta();
        }

        public void MostrarMenu()
        {
            bool continuar = true;
            while (continuar && !Manejador.JuegoTerminado())
            {
                Console.Clear();
                Console.WriteLine(Titulo);
                Console.WriteLine(new string('=', Titulo.Length));
                Console.WriteLine(Manejador.Jugador.ToString());
                Console.WriteLine();
                for (int i = 0; i < Opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Opciones[i]}");
                }
                Console.WriteLine("0. Retirarse");
                string opcion = Console.ReadLine() ?? "";
                switch (opcion)
                {
                    case "1":
                        MostrarApostar();
                        break;
                    case "2":
                        MostrarHistorial();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción Inválida.");
                        Console.ReadLine();
                        break;
                }
            }

            MostrarResultadoFinal();
        }

        public void MostrarApostar()
        {
            Console.Clear();
            Console.WriteLine("Realizar Apuesta");
            Console.WriteLine("=================");
            Console.WriteLine();
            Console.WriteLine("¿A qué quieres apostar?");
            Console.WriteLine("1. Número específico (0-36) - paga x10");
            Console.WriteLine("2. Color (Rojo/Negro) - paga x5");
            Console.WriteLine("3. Par/Impar - paga x2");
            string opcion = Console.ReadLine() ?? "";

            string tipo;
            string valor;
            int multiplicador;

            switch (opcion)
            {
                case "1":
                    tipo = "Numero";
                    multiplicador = 10;
                    int numero = PedirValorEntero("Número (0-36)");
                    if (numero < 0 || numero > 36)
                    {
                        Console.WriteLine("Número inválido.");
                        Console.ReadLine();
                        return;
                    }
                    valor = numero.ToString();
                    break;
                case "2":
                    tipo = "Color";
                    multiplicador = 5;
                    Console.Write("Color (Rojo/Negro): ");
                    valor = Console.ReadLine() ?? "";
                    if (!valor.Equals("Rojo", StringComparison.OrdinalIgnoreCase) && !valor.Equals("Negro", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Color inválido.");
                        Console.ReadLine();
                        return;
                    }
                    valor = char.ToUpper(valor[0]) + valor.Substring(1).ToLower();
                    break;
                case "3":
                    tipo = "Pares";
                    multiplicador = 2;
                    Console.Write("Par o Impar: ");
                    valor = Console.ReadLine() ?? "";
                    if (!valor.Equals("Par", StringComparison.OrdinalIgnoreCase) && !valor.Equals("Impar", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Valor inválido.");
                        Console.ReadLine();
                        return;
                    }
                    valor = char.ToUpper(valor[0]) + valor.Substring(1).ToLower();
                    break;
                default:
                    Console.WriteLine("Opción Inválida.");
                    Console.ReadLine();
                    return;
            }

            Console.Write("Monto a apostar (múltiplos de 10): ");
            decimal monto = decimal.TryParse(Console.ReadLine(), out decimal valorMonto) ? valorMonto : 0;

            if (!Manejador.ApuestaValida(monto))
            {
                Console.WriteLine("Monto inválido. Debe ser múltiplo de 10 y no superar tu dinero actual.");
                Console.ReadLine();
                return;
            }

            Apuesta apuesta = new Apuesta(tipo, valor, monto, multiplicador);
            Giro giro = Manejador.RealizarApuesta(apuesta);

            Console.WriteLine();
            Console.WriteLine(giro.ToString());
            Console.WriteLine(Manejador.Jugador.ToString());
            Console.ReadLine();
        }

        public void MostrarHistorial()
        {
            Console.Clear();
            Console.WriteLine("Historial de Giros");
            Console.WriteLine("===================");
            Manejador.MostrarHistorial();
            Console.ReadLine();
        }

        public void MostrarResultadoFinal()
        {
            Console.Clear();
            Console.WriteLine("Fin del Juego");
            Console.WriteLine("=============");

            if (Manejador.JuegoTerminado())
            {
                Console.WriteLine("Te has quedado sin dinero.");
            }

            decimal ganancia = Manejador.Jugador.ObtenerGananciaTotal();
            if (ganancia >= 0)
            {
                Console.WriteLine($"¡Felicidades! Ganaste {ganancia:C}");
            }
            else
            {
                Console.WriteLine($"Perdiste {Math.Abs(ganancia):C}");
            }
            Console.ReadLine();
        }

        public int PedirValorEntero(string v)
        {
            Console.Write($"{v}: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor no válido. Ingresa nuevamente");
                }
            }
        }
    }
}
