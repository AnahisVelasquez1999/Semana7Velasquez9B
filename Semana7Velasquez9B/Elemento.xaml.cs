using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int id, string nombre)
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            IdSeleccionado = id;
            Nombre.Text = nombre;
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usurio = ?, " + "Contrasena = ? where Id = ?", nombre, usuario, contrasena, id);
        }

        private void btn_Actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, Contrasena.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se Actualizo Correctamente", "OK");

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", "ERROR" + ex.Message, "OK");
            }
        }

        private void btn_Eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se Elimino Correctamente", "OK");

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", "ERROR" + ex.Message, "OK");
            }
        }
    }
}