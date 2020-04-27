using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }
        public EscuelaEngine()
        {
        }

        public void Inicializar()
        {
            this.Escuela = new Escuela("ITI", 2020, TiposEscuela.Primaria, pais: "Colombia", ciudad: "Bogota");
            CargarCursos();
            CargarAsignaturas();
            foreach (var curso in Escuela.Cursos)
            {
                curso.Alumnos.AddRange(CargarAlumnos());

            }
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Educacion Fisica"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas.AddRange(listaAsignaturas);
            }
        }

        private void CargarAsignaturas()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Alumno> CargarAlumnos()
        {
            string[] nombre1 = { "Fabian", "Andres", "Alexander", "Camilo", "Felipe", "Nicolas", "Jose" };
            string[] nombre2 = { "Freddy", "David", "Leonidas", "Raul", "Carlos", "Diego", "Oscar" };
            string[] apellido = { "Llanos", "Osorio", "Segura", "Hernandez", "Vega", "Granda", "Barajas" };
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos;
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre = "101", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre = "301", Jornada=TiposJornada.Mañana},
                new Curso(){Nombre = "401", Jornada=TiposJornada.Tarde},
                new Curso(){Nombre = "501", Jornada=TiposJornada.Tarde}
            };
        }
    }
}