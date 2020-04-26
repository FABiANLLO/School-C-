using System;

namespace CoreEscuela
{
    public class Alumno
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public Alumno()
        {
            this.UniqueId = Guid.NewGuid().ToString();
        }

    }

}