using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using static System.Console;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("ITI", 2020, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");
            escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };

            ImprimirCursosEscuela(escuela);

            bool rta = 10 == 10;
            int cant = 10;
            if (rta == false)
            {
                WriteLine("Se cumplio la condicion 1 ");
            }
            else if (cant > 15)
            {
                WriteLine("Se cumplio la condicion 2 ");

            }
            else
            {
                WriteLine("No se cumplio ninguna condicion");

            }
            if (cant > 5 && rta == false)
            {
                WriteLine("Se cumplio la condicion 3 ");
            }

            if (cant > 5 && rta)
            {
                WriteLine("Se cumplio la condicion 4 ");
            }
            cant = 10;
            if ((cant > 15 || !rta) && (cant % 5 == 0))
            {
                WriteLine("Se cumplio la condicion 5 ");
            }

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("====================");
            WriteLine("Cursos de la Escuela");
            WriteLine("====================");
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



        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var @as in arregloCursos)
            {
                WriteLine($"Nombre {@as.Nombre}, Id {@as.UniqueId}");
            }
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                WriteLine($"Nombre {arregloCursos[i].Nombre}, Id {arregloCursos[i].UniqueId}");
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int count = 0;
            do
            {
                WriteLine($"Nombre {arregloCursos[count].Nombre}, Id {arregloCursos[count].UniqueId}");
                count++;
            }
            while (count < arregloCursos.Length);
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int count = 0;
            while (count < arregloCursos.Length)
            {
                WriteLine($"Nombre {arregloCursos[count].Nombre}, Id {arregloCursos[count].UniqueId}");
                count++;
            }
        }
    }
}
