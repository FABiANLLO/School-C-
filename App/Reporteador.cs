using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using Etapa1.Entidades;

namespace CoreEscuela
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (dicObsEsc == null)
            {
                throw new ArgumentNullException(nameof(dicObsEsc));
            }
            _diccionario = dicObsEsc;

        }
        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }
        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();
            // return from Evaluacion ev in listaEvaluaciones where ev.Nota >= 3.0f  select ev.Asignatura;
            return (from Evaluacion ev in listaEvaluaciones select ev.Asignatura.Nombre).Distinct();
        }
        public Dictionary<string, IEnumerable<Evaluacion>> GetDiccionarioEvaluacionesAsignatura()
        {
            var dicEvAsing = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsignaturas = GetListaAsignaturas(out var listaEval);
            foreach (var asign in listaAsignaturas)
            {
                var evalAsign = from eval in listaEval where eval.Asignatura.Nombre == asign select eval;
                dicEvAsing.Add(asign, evalAsign);
            }
            return dicEvAsing;
        }
    }
}