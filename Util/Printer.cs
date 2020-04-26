using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
            WriteLine("".PadLeft(tam, '='));
        }
        public static void WriteTitle(string titulo)
        {
            var tam = titulo.Length + 4;
            DibujarLinea(tam);
            WriteLine($"| {titulo} |");
            DibujarLinea(tam);
        }
        public static void Beep(int hz = 2000, int time = 500, int cant = 1)
        {
            while (cant-- > 0)
            {
                System.Console.Beep(hz, time);
            }
        }
    }
}