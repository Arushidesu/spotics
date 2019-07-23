using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotics
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ButtonTocando_Click(object sender, EventArgs e)
        {
            labelTocando.Text = GetSpotifyTrackInfo();
        }

        private static string GetSpotifyTrackInfo()
        {
            var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));

            if (proc == null)
            {
                return "Spotify não está rodando!";
            }

            if (string.Equals(proc.MainWindowTitle, "Spotify", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Pausado";
            }
            return proc.MainWindowTitle;
        }

        private async void ButtonCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                await DownloadDetails().ConfigureAwait(true);
            }
            catch (Exception err)
            {
                textBoxLetra.Text = "Ocorreu algum erro! Música não reconhecida.";
            }
        }

        private async Task DownloadDetails()
        {
            string track = labelTocando.Text;
            string artist = track.Split('-')[0];
            string music = track.Split('-')[1];
            string key = ""; // Sua key da API do Vagalume

            using (var wc = new WebClient())
            {
                var uri = new Uri($"https://api.vagalume.com.br/search.php?art={artist}&mus={music}&apikey={key}");
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(uri);
            }
        }

        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var json = e.Result;
            SongDetails result = JsonConvert.DeserializeObject<SongDetails>(json);
            textBoxLetra.Text = result.mus[0].text.Replace("\n", Environment.NewLine);
        }

        private void ButtonMais_Click(object sender, EventArgs e)
        {
            float len = textBoxLetra.Font.Size;
            Font font = new Font(textBoxLetra.Font.FontFamily, len + 1);
            textBoxLetra.Font = font;
        }

        private void ButtonMenos_Click(object sender, EventArgs e)
        {
            float len = textBoxLetra.Font.Size;
            Font font = new Font(textBoxLetra.Font.FontFamily, len - 1);
            textBoxLetra.Font = font;
        }
    }
}