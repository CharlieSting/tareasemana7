using System;
namespace Listas.Model
{
    public class ModelAlumno : ModelPersona
    {
        public int cantidadFaltas { get; set; } = 0;

        public void faltarClase() {

            cantidadFaltas = cantidadFaltas + 1;

        }
        public string calculoFaltas() {

            string mensaje = "";

            if (cantidadFaltas <= 8)
            {

                mensaje = "El alumno(a) " + nombre + " tiene derecho a examen";
            }
            else {

                mensaje = "El alumno(a) " + nombre + " no tiene derecho a examen";

            }


            return mensaje;

        }
    }
}
