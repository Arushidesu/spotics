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
        private readonly Timer _tmr = new Timer();
        private static string _currentSong = "";
        private bool _darkMode = true;

        public frmMain()
        {
            InitializeComponent();

            _tmr.Interval = 5000;
            _tmr.Tick += AutoRefresh;
        }

        private void AutoRefresh(object sender, EventArgs e)
        {
            try
            {
                RefreshAndUpdate();
            }
            catch
            {
                textBoxLetra.Text = string.Empty;
                _tmr.Stop();
                _tmr.Enabled = false;
                chkAutoUpdate.Checked = false;
            }
        }

        private void RefreshAndUpdate()
        {
            labelTocando.Text = GetSpotifyTrackInfo();

            if (labelTocando.Text != _currentSong)
            {
                _currentSong = labelTocando.Text;
                DownloadDetails();
            }
        }

        private void ButtonTocando_Click(object sender, EventArgs e)
        {
            RefreshAndUpdate();
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

        private void DownloadDetails()
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
            try
            {
                var json = e.Result;
                SongDetails result = JsonConvert.DeserializeObject<SongDetails>(json);

                if (!result.type.Contains("notfound"))
                {
                    textBoxLetra.Text = result.mus[0].text.Replace("\n", Environment.NewLine);
                    linkLabelVagalume.Text = result.mus[0].url;
                    linkLabelVagalume.Visible = true;
                }
                else
                {
                    textBoxLetra.Text = "Ocorreu algum erro! Música não reconhecida.";
                }

                if (result.mus.Any() && result.mus[0].translate.Any())
                    textBoxTraducao.Text = result.mus[0].translate[0].text.Replace("\n", Environment.NewLine);
                else
                    textBoxTraducao.Text = "Ocorreu algum erro! Tradução não encontrada.";
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

        private void ChkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoUpdate.Checked)
            {
                _tmr.Start();
                _tmr.Enabled = true;
            }
            else
            {
                _tmr.Stop();
                _tmr.Enabled = false;
            }
        }

        private void S_Click(object sender, EventArgs e)
        {
            if (!_darkMode)
            {
                this.BackColor = SystemColors.Control;

                foreach (Control child in this.Controls)
                {
                    child.ForeColor = Color.Black;
                    textBoxLetra.BackColor = SystemColors.Control;
                }

                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.BackColor = SystemColors.Control;
                }
            }
            else
            {
                this.BackColor = Color.FromArgb(41, 41, 41);

                foreach (Control child in this.Controls)
                {
                    child.ForeColor = Color.WhiteSmoke;
                    textBoxLetra.BackColor = Color.FromArgb(41, 41, 41);
                }

                foreach (var button in this.Controls.OfType<Button>())
                {
                    button.BackColor = Color.FromArgb(100, 100, 100);
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderColor = Color.DarkGray;
                }
            }

            btnChangeTheme.Text = _darkMode ? "White mode" : "Dark mode";
            _darkMode = !_darkMode;
        }
    }
}