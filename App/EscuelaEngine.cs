using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using Etapa1.Entidades;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
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
            CargarEvaluaciones();
        }
        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic)
        {
            foreach (var obj in dic)
            {
                Printer.WriteTitle(obj.Key.ToString());
                Console.WriteLine(obj);
                foreach (var val in obj.Value)
                {
                    Console.WriteLine(val);
                }
            }
        }
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDictionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add(LlaveDiccionario.Escuela, new[] { Escuela });
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            var listatemp = new List<Evaluacion>();
            var listatempAs = new List<Asignatura>();
            var listatempAl = new List<Alumno>();
            foreach (var curso in Escuela.Cursos)
            {
                listatempAs.AddRange(curso.Asignaturas);
                listatempAl.AddRange(curso.Alumnos);
                foreach (var alumno in curso.Alumnos)
                {
                    listatemp.AddRange(alumno.Evaluaciones);
                }
            }
            diccionario.Add(LlaveDiccionario.Evaluacion, listatemp.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Asignatura, listatempAs.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listatempAl.Cast<ObjetoEscuelaBase>());

            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(bool traeEvaluaciones = true, bool traeAsignaturas = true, bool traeEstudiantes = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones, bool traeEvaluaciones = true, bool traeAsignaturas = true, bool traeEstudiantes = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones, out int conteoAlumnos, bool traeEvaluaciones = true, bool traeAsignaturas = true, bool traeEstudiantes = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones, out int conteoAlumnos, out int conteoAsignaturas, bool traeAsignaturas = true, bool traeEstudiantes = true, bool traeCursos = true)
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(out int conteoEvaluaciones, out int conteoAlumnos, out int conteoAsignaturas, out int conteoCursos, bool traeEvaluaciones = true, bool traeAsignaturas = true, bool traeEstudiantes = true, bool traeCursos = true)
        {
            conteoAlumnos = conteoAsignaturas = conteoEvaluaciones = conteoCursos = 0;
            var listObj = new List<ObjetoEscuelaBase>();

            listObj.Add(Escuela);
            if (traeCursos)
            {
                listObj.AddRange(Escuela.Cursos);
                conteoCursos += Escuela.Cursos.Count;
                foreach (var curso in Escuela.Cursos)
                {
                    conteoAsignaturas += curso.Asignaturas.Count;
                    conteoAlumnos += curso.Alumnos.Count;
                    if (traeAsignaturas)
                    {
                        listObj.AddRange(curso.Asignaturas);
                        if (traeEstudiantes)
                        {
                            listObj.AddRange(curso.Alumnos);
                            if (traeEvaluaciones)
                            {
                                foreach (var alumno in curso.Alumnos)
                                {
                                    listObj.AddRange(alumno.Evaluaciones);
                                    conteoEvaluaciones += alumno.Evaluaciones.Count;
                                }
                            }
                        }
                    }
                }
            }
            return (listObj.AsReadOnly());
        }

        #region Metodos de Carga
        private void CargarEvaluaciones()
        {
            // var lista = new List<Evaluacion>();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Educacion Fisica"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAzar(int cant)
        {
            string[] nombre1 = { "Fabian", "Andres", "Alexander", "Camilo", "Felipe", "Nicolas", "Jose" };
            string[] nombre2 = { "Freddy", "David", "Leonidas", "Raul", "Carlos", "Diego", "Oscar" };
            string[] apellido = { "Llanos", "Osorio", "Segura", "Hernandez", "Vega", "Granda", "Barajas" };
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cant).ToList();
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
            Random rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAzar(cantRandom);
            }
        }
        #endregion
    }
}