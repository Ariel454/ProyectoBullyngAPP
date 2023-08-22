using AppBullying.Models;
using Microsoft.Identity.Client;
using System.ComponentModel;

namespace AppBullying;

public partial class MenuEstudiante : ContentPage, INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;


    public Usuario _usuario { get; }
    public string NombreUser => _usuario.nombre;

    private string _logoURL;
    public string LogoURL
    {
        get => _logoURL;
        set
        {
            if (_logoURL != value)
            {
                _logoURL = value;
                OnPropertyChanged(nameof(LogoURL));
            }
        }
    }

    private string _colegio;
    public string Colegio
    {
        get => _colegio;
        set
        {
            if (_colegio != value)
            {
                _colegio = value;
                OnPropertyChanged(nameof(Colegio));
            }
        }
    }

    public List<Curso> cursos = new List<Curso>();
    public List<Institucion> instituciones = new List<Institucion>();

    public MenuEstudiante(Usuario usuario)
	{
		InitializeComponent();
		_usuario = usuario;

        cursos = Login.listaCursos;
        instituciones = Login.listaInstituciones;
        
        BindingContext = this;
        cargarElementos();

    }

    public void cargarElementos() {
        Curso cursoP = cursos.FirstOrDefault(cu => cu.idCurso == _usuario.idCursoF);
        Institucion institucionP = instituciones.FirstOrDefault(ins => ins.idInstitucion == cursoP.idInstitucionF);

        LogoURL = institucionP.logo;
        Colegio = institucionP.nombre;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private async void OnTestsDisponiblesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Tests());
    }

    private void OnInformacionAcosoClicked(object sender, EventArgs e)
    {

    }


    private void OnCuentoInteractivoClicked(object sender, EventArgs e)
    {

    }

    private void OnComoTratarTemaClicked(object sender, EventArgs e)
    {

    }

    private void OnFormularioApoyoClicked(object sender, EventArgs e)
    {

    }

    private void OnComunicarseClicked(object sender, EventArgs e)
    {

    }


}