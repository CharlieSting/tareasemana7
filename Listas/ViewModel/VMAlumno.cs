using System;
using System.ComponentModel;
using Xamarin.Forms;
using Listas.Model;
using System.Collections.ObjectModel;

namespace Listas.ViewModel
{
    public class VMAlumno : INotifyPropertyChanged
    {
        public VMAlumno()
        {
            FaltarClase = new Command(
                     () => {
                         Faltas = Faltas + 1;
                     }
                );

            Guardar = new Command(
                    () => {


                        ModelAlumno x = new ModelAlumno() {
                            nombre = Nombre,
                            identidad = Identidad,
                            cantidadFaltas = Faltas
                        };

                        // Esta variable me ayudara a saber si existia el registro
                        // por lo tanto si es falsa debo asumir que adicionare el registro a la lista
                        // si esl verdera es por que lo encontre en el ciclo for y por lo tanto
                        // lo actualice.
                        bool existia = false;

                        for (int i = 0; i < listaGuardar.Count; i++) {

                                if (listaGuardar[i].identidad == Identidad) {
                                    listaGuardar[i] = x;
                                    existia = true;
                                }


                        }

                        if (existia == false) {
                            listaGuardar.Add(x);
                        }
  

                    }

                );

            Buscar = new Command(
                    () => {

                        ModelAlumno temporal = new ModelAlumno();

                        for (int i = 0; i < listaGuardar.Count; i++) {

                            temporal = listaGuardar[i];

                            if (temporal.identidad == Identidad) {

                                Nombre = temporal.nombre;
                                Faltas = temporal.cantidadFaltas;
                                Reporte = temporal.calculoFaltas();

                            }

                        }

                    }
                );

        }

        public ObservableCollection<ModelAlumno> listaGuardar { get; set; } = new ObservableCollection<ModelAlumno>();

        String nombre;

        public String Nombre { get => nombre;
            set {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        String identidad;

        public String Identidad {
            get => identidad;
            set {

                identidad = value;
                var args = new PropertyChangedEventArgs(nameof(Identidad));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int faltas = 0;
        public int Faltas {

            get => faltas;
            set {

                faltas = value;
                var args = new PropertyChangedEventArgs(nameof(Faltas));
                PropertyChanged?.Invoke(this, args);

            }

        }

        string reporte = "";
        public string Reporte {
            get => reporte;
            set {
                reporte = value;
                var args = new PropertyChangedEventArgs(nameof(Reporte));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command Guardar { get; }


        public Command Buscar { get; }

        public Command FaltarClase { get;  }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}

// MVVM:
// Model(Clases: Primer Parcial)
// View(Front END)
// ViewModel(Son Clases para Manejar el Front END)