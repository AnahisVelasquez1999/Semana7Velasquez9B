using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semana7Velasquez9B.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana7Velasquez9B
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Estudiante { Nombre = txtNombre.Text, Usurio = txtUsuario.Text, Contrasena = txtContrasena.Text };
                con.InsertAsync(DatosRegistro);
                limpiarFormulario();

            }
            catch (Exception)
            {

                throw;
            }
        }
           
            void limpiarFormulario()
            {
                txtNombre.Text = "";
                txtUsuario.Text = "";
                txtContrasena.Text = "";
                DisplayAlert("Alerta", "Dato ingresado correctamente", "Cerrar");
            }
        }
}