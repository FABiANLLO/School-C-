using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); }
        }

        public int AnioDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int anioDeCreacion) => (Nombre, AnioDeCreacion) = (nombre, anioDeCreacion);
        public Escuela(string nombre, int anioDeCreacion, TiposEscuela tipo, string pais = "", string ciudad = "")
        {
            (Nombre, AnioDeCreacion) = (nombre, anioDeCreacion);
            this.Pais = pais;
            this.Ciudad = ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine}Pais: {Pais}, Ciudad: {Ciudad}, Año de Creacion: {AnioDeCreacion}";
        }
    }
}