using System;
using Xamarin.Forms;

namespace AplicacionDBP1.miApp
{
    public partial class CV : ContentPage
    {
        public CV()
        {
            InitializeComponent();
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
            string habilidades = habilidadesEditor.Text;

            // Crear contenido del CV
            string cvContent = $"Nombre: {nombre}\n" +
                               $"Apellido: {apellido}\n" +
                               $"Descripción: {descripcion}\n" +
                               $"Estudios: {estudio}\n" +
                               $"Contacto: {contacto}\n" +
                               $"Idiomas: {idiomas}\n" +
                               $"Habilidades: {habilidades}\n";

            // Navigate to CVDisplayPage and pass the CV content
            await Navigation.PushAsync(new CVDisplayPage(cvContent));
        }
    }
}
