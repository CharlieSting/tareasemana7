using System;
namespace Listas.Model
{
    public class ModelDocente : ModelPersona
    {

        public int horasacumuladas { get; set; } = 0;

        public void impartirClase(int horas) {

            horasacumuladas = horasacumuladas + horas;
        }

        public string calculoSalario() {

            return "El docente " + nombre + " ganara un salario de: " + horasacumuladas * 250;

        }

        public void resetHoras() {
            horasacumuladas = 0;
        }
        
    }
}