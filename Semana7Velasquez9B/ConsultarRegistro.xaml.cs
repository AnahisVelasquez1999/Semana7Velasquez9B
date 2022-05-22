using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semana7Velasquez9B.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Semana7Velasquez9B
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> _TablaEstudiante;

        public ConsultarRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var ResulRegistros = await con.Table<Estudiante>().ToListAsync();
            _TablaEstudiante = new ObservableCollection<Estudiante>(ResulRegistros);
            lsEstudiante.ItemsSource = _TablaEstudiante;
            base.OnAppearing();

        }

        private void lsEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            var nombre = obj.Nombre.ToString();
            string nombre1 = nombre.ToString();
            try
            {
                Navigation.PushAsync(new Elemento(ID, nombre1));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}