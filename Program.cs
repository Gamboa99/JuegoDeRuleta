using System.ComponentModel.Design;

namespace JuegoRuleta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titulo = "Juego de ruleta";
            string[] opciones = ["Apostar", "Ver historial"];
            Menu menu = new Menu(titulo, opciones);
            menu.MostrarMenu();

        }
    }
}
