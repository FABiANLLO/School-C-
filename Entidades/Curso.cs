using System;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string Nombre { get; set; }
        public string UniqueId { get; private set; }
        public TiposJornada Jornada { get; set; }
        public Curso()
        {
            this.UniqueId = Guid.NewGuid().ToString();
        }
    }
}