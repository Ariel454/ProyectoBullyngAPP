namespace AppBullying;

public partial class InfoAcoso : ContentPage
{
	public InfoAcoso()
	{
		InitializeComponent();
	}

    private void OnRecursosClicked(object sender, EventArgs e)
    {

    }

    private async void OnComoTratarTemaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ComoTratarElTema());
    }
}