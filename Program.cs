using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;
namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();

            Printer.WriteTitle("Bienvenidos a la Escuela");
            // Printer.Beep(cant: 10);
            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "Fabian");
            diccionario.Add(11, "Andres");
            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }
            Printer.WriteTitle("Acceso a Diccionario");
            diccionario[0] = "Julieth";
            WriteLine(diccionario[0]);

            var dic = new Dictionary<string, string>();
            Printer.WriteTitle("Diccionario Nuevo");


        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre}, Id {curso.UniqueId}");
                }
            }
            else
            {
                return;
            }
        }
    }
}
