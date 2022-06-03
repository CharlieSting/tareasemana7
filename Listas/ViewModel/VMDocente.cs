using Listas.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Listas.ViewModel
{
    public class VMDocente : INotifyPropertyChanged
    {
        public VMDocente()
        {

            DarClase = new Command(
                    () => {
                        HorasClaseAcumulada = HorasClaseAcumulada + HorasClase;
                        Reporte = "El docente " + Nombre + " Tiene por Salario: " + HorasClaseAcumulada * 300;
                    }
                );

            ResetHorasClase = new Command
                (

                    () => {
                        
                        HorasClaseAcumulada = 0;
                        Reporte = "El docente " + Nombre + " Tiene por Salario: " + HorasClaseAcumulada * 300;
                    }

                );

            GUARDAR2docen = new Command
                (
                    () =>
                    {
                        ModelDocente x = new ModelDocente()
                        {
                            nombre= Nombre,
                            horasacumuladas= HorasClaseAcumulada,
                            identidad = Identidad


                        };

                        bool existia = false;

                        for (int i = 0; i < ListGuardar.Count; i++)
                        {

                            if (ListGuardar[i].identidad == Identidad)
                            {
                                ListGuardar[i] = x;
                                existia = true;
                               
                            }


                        }

                        if (existia == false)
                        {
                            ListGuardar.Add(x);
                        

                        }

                        Reporte = "El docente " + Nombre + " Tiene por Salario: " + HorasClaseAcumulada * 300;
                    }

                );

            BUSCAR2docen = new Command(
                () =>
                {

                    ModelDocente temporal = new ModelDocente();

                    for (int i = 0; i < ListGuardar.Count; i++)
                    {

                        temporal = ListGuardar[i];

                        if (temporal.identidad == Identidad)
                        {

                            Nombre = temporal.nombre;

                            HorasClaseAcumulada = temporal.horasacumuladas;

                            Reporte = temporal.calculoSalario();

                           

                        }

                    }
                }

                );



        }

        public ObservableCollection<ModelDocente> ListGuardar { get; set; } = new ObservableCollection<ModelDocente>();
        String nombre;

        public String Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        String identidad;

        public String Identidad
        {
            get => identidad;
            set
            {

                identidad = value;
                var args = new PropertyChangedEventArgs(nameof(Identidad));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int horasClase = 0;
        public int HorasClase
        {

            get => horasClase;
            set
            {
                horasClase = value;
                var args = new PropertyChangedEventArgs(nameof(HorasClase));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int horasClaseAcumulada = 0;
        public int HorasClaseAcumulada {
            get => horasClaseAcumulada;
            set {

                horasClaseAcumulada = value;
                var args = new PropertyChangedEventArgs(nameof(HorasClaseAcumulada));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string reporte = "";
        public string Reporte
        {
            get => reporte;
            set
            {
                reporte = value;
                var args = new PropertyChangedEventArgs(nameof(Reporte));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command GUARDAR2docen { get; }

        public Command BUSCAR2docen { get; }
        public Command DarClase { get; }
        public Command ResetHorasClase { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
