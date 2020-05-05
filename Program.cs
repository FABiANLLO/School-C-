using System;
using System.Collections.Generic;
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
            ImprimirCursosEscuela(engine.Escuela);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");
            var alumnoTest = new Alumno { Nombre = "Claire UnderWood" };
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");
            Printer.WriteTitle("Objeto Escuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var evaluacion = new Evaluacion { Nombre = "Evaluacion de Mate", Nota = 4.5f };
            Printer.WriteTitle("Objeto Evaluacion");
            WriteLine($"Evaluacion: {evaluacion.Nombre}");
            WriteLine($"Evaluacion: {evaluacion.UniqueId}");
            WriteLine($"Evaluacion: {evaluacion.Nota}");
            WriteLine($"Evaluacion: {evaluacion.GetType()}");

            // ob = evaluacion;

            if (ob is Alumno)
            {
                Alumno alumnoRecuperado = (Alumno)ob;
            }

            Alumno alumnoRecuperado2 = ob as Alumno;


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
