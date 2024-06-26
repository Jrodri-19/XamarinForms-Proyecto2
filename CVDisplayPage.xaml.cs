using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AplicacionDBP1.miApp
{
    public partial class CVDisplayPage : ContentPage
    {
        public CVDisplayPage(string cvContent)
        {
            InitializeComponent();
            cvContentLabel.Text = cvContent;
        }

        private async void OnExportClicked(object sender, EventArgs e)
        {
            // Capturar el contenido del CV
            string cvContent = cvContentLabel.Text;

            // Guardar el contenido en un archivo .txt
            string filePath = Path.Combine(FileSystem.CacheDirectory, "CV.txt");
            File.WriteAllText(filePath, cvContent);

            // Compartir el archivo .txt
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Curriculum Vitae",
                File = new ShareFile(filePath, "text/plain")
            });
        }
    }
}
