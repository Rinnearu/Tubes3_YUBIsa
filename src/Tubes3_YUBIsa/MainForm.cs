using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;
using System.Text;

namespace Tubes3_YUBIsa
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            if (connectionString != null)
            {
                DatabaseConnector dbConnector = new DatabaseConnector(connectionString);
                dbConnector.InitializeDatabase();
            }
            else
            {
                MessageBox.Show("Didn't found connection string");
            }
        }

        private void PanelMasukan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelKeluaran_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*",
                FilterIndex = 1,

                Title = "Open a file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                if (Controls.Find("pictureBox1", true)[0] is PictureBox pictureBox)
                {
                    pictureBox.Image = Image.FromFile(selectedFilePath);
                    if (Controls.Find("label2", true)[0] is Label label)
                    {
                        label.Text = selectedFilePath;
                    }
                    pictureBox.BringToFront();
                    searchButton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("PictureBox not found.");
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "KMP";
            }
            else
            {
                checkBox1.Text = "BM";
            }
        }

        private async void searchbutton_Click(object sender, EventArgs e)
        {
            ShowLoadingPanel();

            await Task.Run(() => SearchMatching());

            CloseLoadingPanel();
        }

        private void ShowLoadingPanel()
        {
            LoadingPanel.BackColor = Color.White;
            LoadingPanel.BringToFront();
            LoadingPanel.Visible = true;
        }

        private void CloseLoadingPanel()
        {
            LoadingPanel.Visible = false;
            LoadingPanel.BackColor = Color.Transparent;
            LoadingPanel.SendToBack();
        }

        private void SearchMatching()
        {
            DatabaseConnector db = new(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            List<FingerprintEntry> fingers = db.GetAllFingerprints();

            Stopwatch stopwatch = new();
            stopwatch.Start();

            if (Controls.Find("label2", true)[0] is Label label)
            {
                string pathori = label.Text;

                string ascii1 = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinary(pathori));
                string ascii1c = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinaryCenter(pathori));

                bool kmp = false;
                if (Controls.Find("checkBox1", true)[0] is CheckBox check)
                {
                    if (check.Checked)
                    {
                        kmp = true;
                    }
                }

                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
                bool found = false;

                Parallel.ForEach(fingers, parallelOptions, (entry, loopState) =>
                {
                    if (found)
                    {
                        return;
                    }

                    try
                    {
                        string? ascii2 = entry.BerkasCitra;

                        if (ascii2 == null)
                        {
                            return;
                        }

                        int index = kmp ? KMPAlgorithm.KMPSearch(ascii2, ascii1c) : BoyerMooreAlgorithm.BoyerMooreSearch(ascii2, ascii1c);

                        if (index != -1)
                        {
                            stopwatch.Stop();
                            UpdateUI(ascii2, stopwatch.Elapsed, 100.0, entry.Nama, db.GetBiodata(entry.Nama));
                            found = true;
                            loopState.Stop();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing image  {ex.Message}");
                    }
                });

                if (!found)
                {
                    string? bestMatchname = null;
                    double similarity = double.MinValue;
                    string? best = null;

                    Parallel.ForEach(fingers, parallelOptions, entry =>
                    {
                        string? name = entry.Nama;
                        string? ascii2 = entry.BerkasCitra;

                        double sim = LCSC.CalculateSimilarity(ascii1, ascii2);
                        lock (this)
                        {
                            if (sim > similarity)
                            {
                                similarity = sim;
                                bestMatchname = name;
                                best = ascii2;
                            }
                        }
                    });

                    stopwatch.Stop();

                    UpdateUI(best, stopwatch.Elapsed, similarity * 100, bestMatchname, db.GetBiodata(bestMatchname));
                } else
                {
                    stopwatch.Stop();
                }
            }
            else
            {
                Debug.Write("Error");
            }
        }

        private void UpdateUI(string ascii2, TimeSpan elapsed, double similarity, string bestMatchname, string bioResult)
        {
            similarity = 23;
            if (Controls.Find("waktulabel", true)[0] is Label waktulabel)
            {
                waktulabel.Invoke(new Action(() => waktulabel.Text = ": " + elapsed.ToString()));
            }

            if (Controls.Find("persentaselabel", true)[0] is Label persentaselabel)
            {
                if (similarity < 65)
                {
                    persentaselabel.Invoke(new Action(() => persentaselabel.Text = ": " + "xx%"));
                }
                else
                {
                    persentaselabel.Invoke(new Action(() => persentaselabel.Text = ": " + $"{similarity:F2}%"));
                }
                
            }

            if (Controls.Find("pictureBox2", true)[0] is PictureBox pictures)
            {
                if (Controls.Find("label3", true)[0] is Label labela)
                {
                    labela.Invoke(new Action(() => labela.Text = "Tidak ada sidik jari cocok"));
                    if (Controls.Find("PanelKeluaran", true)[0] is Panel panelk)
                    {
                        panelk.Invoke(new Action(()=> panelk.BringToFront()));
                    }
                    labela.Invoke(new Action(() => labela.BringToFront()));
                }
                if (similarity >= 65)
                {
                    pictures.Invoke(new Action(() => pictures.Image = FingerprintProcessor.BinaryToBitmap(BinaryToAsciiConverter.AsciiToBinary(ascii2, 103, 96))));
                    pictures.Invoke(new Action(() => pictures.BringToFront()));
                }
                
            }

            if (Controls.Find("label8", true)[0] is Label la8)
            {
                if (similarity < 65)
                {
                    la8.Invoke(new Action(() => la8.Text = "Sidik jari tidak ditemukan"));
                }
                else
                {
                    la8.Invoke(new Action(() => la8.Text = bioResult));
                }
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void waktulabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void LoadingPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
