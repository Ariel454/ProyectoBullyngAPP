using System;
using Microsoft.Maui.Controls;


namespace AppBullying
{
    public partial class Mensajeria : ContentPage
    {
        private string selectedImagePath; // Almacena la ruta de la imagen seleccionada
        private string selectedVideoPath;

        public Mensajeria()
        {
            InitializeComponent();
        }

        private async void OnAttachPhotoClicked(object sender, EventArgs e)
        {
            try
            {

                var result = await MediaPicker.PickPhotoAsync();

                if (result != null)
                {

                    selectedImagePath = result.FullPath; //Almacena la direccion de la foto

                    PreviewImage.Source = ImageSource.FromFile(selectedImagePath);

                }
            }
            catch (Exception ex) { 
            
            }


            // Aquí puedes implementar la lógica para adjuntar una foto
        }
        private async void OnAttachVideoClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickVideoAsync();

                if (result != null)
                {
                    selectedVideoPath = result.FullPath; // Almacena la ruta del video

                    // Genera la URL de la vista previa de video
                    string videoPreviewUrl = $"file://{selectedVideoPath}";
                    PreviewVideo.Source = new HtmlWebViewSource { Html = $"<video controls><source src='{videoPreviewUrl}' type='video/mp4'></video>" };

                    PreviewVideo.IsVisible = true; // Hace visible el WebView
                    PreviewImage.IsVisible = false; // Oculta la vista previa de imagen si estaba visible
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores si algo sale mal al elegir el video
            }
        }


        private void OnSendMessageClicked(object sender, EventArgs e)
        {
            // Lógica para enviar el mensaje, incluyendo la imagen seleccionada
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                // Aquí puedes usar la ruta selectedImagePath para enviar la imagen junto con el mensaje
            }
        }
    }
}
