using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonTocando_Click(object sender, EventArgs e)
        {
            labelTocando.Text = GetSpotifyTrackInfo();
        }

        static string GetSpotifyTrackInfo()
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

        private void ButtonCarregar_Click(object sender, EventArgs e)
        {
            string track = labelTocando.Text;
            try
            {
                string artist = track.Split('-')[0];
                string music = track.Split('-')[1];
                string key = ""; // Sua key da API do Vagalume
                var json = new WebClient().DownloadString(
                    "https://api.vagalume.com.br/search.php"
                    + "?art=" + artist
                    + "&mus=" + music
                    + "&apikey=" + key);

                RootObject result = JsonConvert.DeserializeObject<RootObject>(json);
                textBoxLetra.Text = result.mus[0].text.Replace("\n", Environment.NewLine);
            }
            catch
            {
                textBoxLetra.Text = "Ocorreu algum erro! Música não reconhecida.";
            }
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
