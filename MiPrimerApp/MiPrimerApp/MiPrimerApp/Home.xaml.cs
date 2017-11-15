using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiPrimerApp
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
            ObservableCollection<Persona> listaPersona = new ObservableCollection<Persona>(new ServicioPersona().ConsultarPersona());
            lstpersonas.ItemsSource = listaPersona;
            lstpersonas.ItemSelected += Lstpersonas_ItemSelected;
        }

        private void Lstpersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var element = e.SelectedItem as Persona;
                DisplayAlert("Listas", element.nombre.ToString(), "Aceptar");
            }
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    ListaElementos elementos = new ListaElementos();
        //    ListElements.ItemsSource = elementos._elementos;
        //}
    }
}