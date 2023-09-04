using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace AppBullying
{
    public partial class Comunicarse : ContentPage
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>
        {
            new Contact { Name = "Contacto 1" },
            new Contact { Name = "Contacto 2" },
            new Contact { Name = "Contacto 3" }
        };

        public Comunicarse()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnContactClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Mensajeria());
            foreach (var contact in Contacts)
            {
                if (contact.IsSelected)
                {
                    // Aquí podrías realizar alguna acción para contactar al usuario seleccionado
                }
            }
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
