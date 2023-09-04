using AppBullying.Data;
using AppBullying.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace AppBullying;

public partial class Login : ContentPage
{
    private ApplicationDbContext context;
    public ObservableCollection<string> Instituciones { get; set; }
    public static List<Institucion> listaInstituciones = new List<Institucion>(); 
    public static List<Curso> listaCursos = new List<Curso>();    

    public Login()
    {
        InitializeComponent();
        context = new ApplicationDbContext();
        Instituciones = new ObservableCollection<string>();
        BindingContext = this;
        cargarInstituciones();
        cargarCursos();
        //Instituciones.Insert(0, "Selecciona tu institución: ");
        //InstitucionPicker.ItemsSource = Instituciones;
    }


    public async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string user = UserNameEntry.Text;
        string pass = passwordEntry.Text;
        

        using (var client = new HttpClient())
        {
            var url = "https://localhost:7184/Usuarios/ListarUsuarios";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);
                Usuario usuario = listaUsuarios.FirstOrDefault(u => u.nombreUsuario == user && u.contrasenia == pass);

                if (usuario != null)
                {

                    Institucion institucionSeleccionada = listaInstituciones.FirstOrDefault(ins => ins.nombre == InstitucionPicker.SelectedItem.ToString());
                    Curso cursoBuscar = listaCursos.FirstOrDefault(cu => cu.idInstitucionF == institucionSeleccionada.idInstitucion);
                    if (cursoBuscar != null) {
                        if (usuario.idCursoF == cursoBuscar.idCurso)
                        {
                            await Navigation.PushAsync(new MenuEstudiante(usuario));
                            await Task.Delay(1000); // Esperar un momento
                            await DisplayAlert("Error", "Ingreso exitoso", "OK");
                        }
                        else
                        {
                            // Credenciales inválidas, mostrar mensaje de error
                            await DisplayAlert("Error", "Usuario no autorizado", "OK");
                        }
                    }
                    else
                    {
                        // Credenciales inválidas, mostrar mensaje de error
                        await DisplayAlert("Error", "Verifique las credenciales", "OK");
                    }


                    /* if (usuario.rol == 1)
                     {

                     }
                     else if (usuario.rol == 0)
                     {

                     }
                     else
                     {
                         // Credenciales inválidas, mostrar mensaje de error
                         await DisplayAlert("Error", "Usuario no autorizado", "OK");
                     }
                    */

                }
                else
                {
                    // Credenciales inválidas, mostrar mensaje de error
                    await DisplayAlert("Error", "Credenciales inválidas", "OK");
                }
            }
        }
    }

    //public async void OnLoginButton2Clicked(object sender, EventArgs e)
    //{
    //    string user = UserNameEntry.Text;
    //    string pass = passwordEntry.Text;


    //    using (var client = new HttpClient())
    //    {
    //        //var url = "https://localhost:7184/Usuarios/ListarUsuarios";
    //        var url = "https://192.168.10.199:7184/Usuarios/ListarUsuarios";
    //        var response = await client.GetAsync(url);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            var content = await response.Content.ReadAsStringAsync();
    //            var listaUsuarios = JsonConvert.DeserializeObject<List<Usuario>>(content);
    //            Usuario usuario = listaUsuarios.FirstOrDefault(u => u.nombreUsuario == user && u.contrasenia == pass);

    //            if (usuario != null)
    //            {

    //                        await Navigation.PushAsync(new MenuEstudiante(usuario));
    //                        await Task.Delay(1000); // Esperar un momento
    //                        await DisplayAlert("Error", "Ingreso exitoso", "OK");
    //            }
    //            else
    //            {
    //                    // Credenciales inválidas, mostrar mensaje de error
    //                    await DisplayAlert("Error", "Verifique las credenciales", "OK");
    //             }


    //            }
    //            else
    //            {
    //                // Credenciales inválidas, mostrar mensaje de error
    //                await DisplayAlert("Error", "Credenciales inválidas", "OK");
    //            }
    //        }
    // }


    public async void cargarInstituciones() {

        using (var client = new HttpClient()) {

            var url = "https://localhost:7184/Institucions/ListarInstituciones";
            var response = await client.GetAsync(url);

            Instituciones.Clear();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listaInstituciones = JsonConvert.DeserializeObject<List<Institucion>>(content);

                foreach (var institucion in listaInstituciones) {
                    Instituciones.Add(institucion.nombre);
                }
            }
            else {

                await DisplayAlert("Error", "No se cargaron las instituciones", "OK");
            }


        }

    }

    public async void cargarCursos()
    {

        using (var client = new HttpClient())
        {

            var url = "https://localhost:7184/Cursos/ListarCursos";
            var response = await client.GetAsync(url);

            Instituciones.Clear();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                listaCursos = JsonConvert.DeserializeObject<List<Curso>>(content);

            }
            else
            {

                await DisplayAlert("Error", "No se cargaron las instituciones", "OK");
            }


        }

    }

    /*async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        // Navega a la página de registro (RegisterPage) y espera a que se complete la navegación.
        // E* código aquí se ejecutará después de que se complete la navegación.
    }*/

}