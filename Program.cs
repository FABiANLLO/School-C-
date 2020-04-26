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
                new Curso(){Nombre = "101", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada=TiposJornada.Mañana}
            };
            escuela.Cursos.Add(new Curso() { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso() { Nombre = "202", Jornada = TiposJornada.Tarde });

            var otraColeccion = new List<Curso>(){
                new Curso(){Nombre = "401", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre = "501", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre = "502", Jornada=TiposJornada.Tarde}
            };
            // Curso temp = new Curso { Nombre = "101 Vacacional", Jornada = TiposJornada.Noche };

            // otraColeccion.Clear(); //Remueve TODO
            escuela.Cursos.AddRange(otraColeccion);
            // escuela.Cursos.Add(temp);
            ImprimirCursosEscuela(escuela);
            // WriteLine("Curso.Hash" + temp.GetHashCode());
            Predicate<Curso> miAlgoritmo = Predicado;
            escuela.Cursos.RemoveAll(miAlgoritmo);
            // escuela.Cursos.Remove(temp);
            ImprimirCursosEscuela(escuela);
        }

        private static bool Predicado(Curso cursoobj)
        {
            return cursoobj.Nombre == "301";
        }
        private static int PredicadoMalHecho(Curso cursoobj)
        {
            return 301;
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
