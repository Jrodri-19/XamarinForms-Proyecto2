using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AplicacionDBP1.miApp
{
    public partial class CV : ContentPage
    {
        public ObservableCollection<string> Habilidades { get; set; }

        public CV()
        {
            InitializeComponent();
            Habilidades = new ObservableCollection<string>();
            habilidadesListView.ItemsSource = Habilidades;
        }

        private async void OnGenerateClicked(object sender, EventArgs e)
        {
            // Capturar los datos del formulario
            string nombre = nombreEditor.Text;
            string apellido = apellidoEditor.Text;
            string descripcion = descripcionEditor.Text;
            string estudio = estudioEditor.Text;
            string contacto = contactoEntry.Text;
            string idiomas = idiomasEditor.Text;
            string habilidades = string.Join(", ", Habilidades);

            // Crear contenido del CV
            string cvContent = $"Nombre: {nombre}\n" +
                               $"Apellido: {apellido}\n" +
                               $"Descripción: {descripcion}\n" +
                               $"Estudios: {estudio}\n" +
                               $"Contacto: {contacto}\n" +
                               $"Idiomas: {idiomas}\n" +
                               $"Habilidades: {habilidades}\n";

            // Navegar a la página de visualización del CV
            await Navigation.PushAsync(new CVDisplayPage(cvContent));
        }

        private void OnAddSkillClicked(object sender, EventArgs e)
        {
            string newSkill = habilidadesEntry.Text;
            if (!string.IsNullOrWhiteSpace(newSkill))
            {
                Habilidades.Add(newSkill);
                habilidadesEntry.Text = string.Empty;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Clear all input fields when returning to this page
            nombreEditor.Text = string.Empty;
            apellidoEditor.Text = string.Empty;
            descripcionEditor.Text = string.Empty;
            estudioEditor.Text = string.Empty;
            contactoEntry.Text = string.Empty;
            idiomasEditor.Text = string.Empty;
            habilidadesEntry.Text = string.Empty;
            Habilidades.Clear();
        }
    }
}
