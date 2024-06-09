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
            } else
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
            // Create a new instance of the OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Set the initial directory (optional)


                // Set the filter for file types (optional)
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*",
                FilterIndex = 1,

                // Set the title of the dialog (optional)
                Title = "Open a file"
            };

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string selectedFilePath = openFileDialog.FileName;

                if (Controls.Find("pictureBox1", true)[0] is PictureBox pictureBox)
                {
                    pictureBox.Image = Image.FromFile(selectedFilePath);
                    if (Controls.Find("label2", true)[0] is Label label)
                    {
                        label.Text = selectedFilePath;
                    }
                    pictureBox.BringToFront(); // Bring the PictureBox to the front
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
                // Perform actions for the "On" state
            }
            else
            {
                checkBox1.Text = "BM";
                // Perform actions for the "Off" state
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
            DatabaseConnector db = new DatabaseConnector(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            List<FingerprintEntry>fingers = db.GetAllFingerprints();
            Stopwatch stopwatch = new();
            stopwatch.Start();

            if (Controls.Find("label2", true)[0] is Label label)
            {
                string pathori = label.Text;
                //string relativePath = @"SOCOFing\Real";
                //string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../../", relativePath);
                //Debug.Write(directoryPath);

                // Check if the directory exists
                //if (!Directory.Exists(directoryPath))
                //{
                //    Console.WriteLine($"Directory not found: {directoryPath}");
                 //   MessageBox.Show("Directory not found");

                //    return;
                //}
                string ascii1 = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinary(pathori));
                string ascii1c = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinaryCenter(pathori));
                // Get all image files from the directory
                //string[] imageFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly)
                                               //.Where(file => file.ToLower().EndsWith("jpg") ||
                                                              //file.ToLower().EndsWith("jpeg") ||
                                                              //file.ToLower().EndsWith("png") ||
                                                              //file.ToLower().EndsWith("bmp") ||
                                                             // file.ToLower().EndsWith("gif")).ToArray();
                bool kmp = false;
                if (Controls.Find("checkBox1", true)[0] is CheckBox check)
                {
                    if (check.Checked)
                    {
                        kmp = true;
                    }
                }
                foreach (var entry in fingers)
                {
                    try
                    {
                        string nama = entry.Nama;
                        Debug.WriteLine(1);
                        // Process each image
                        string ascii2 = entry.BerkasCitra;
                        if (ascii2 == null)
                        {
                            continue;
                        }
                        int index;
                        if (kmp)
                        {
                            index = KMPAlgorithm.KMPSearch(ascii2, ascii1c);
                        }
                        else
                        {
                            index = BoyerMooreAlgorithm.BoyerMooreSearch(ascii2, ascii1c);
                        }
                        Debug.WriteLine(index);
                        if (index != -1)
                        {
                            stopwatch.Stop();
                            if (Controls.Find("waktulabel", true)[0] is Label waktulabeltemp)
                            {
                                waktulabeltemp.Invoke((MethodInvoker)delegate
                                {
                                    waktulabeltemp.Text = ": " + stopwatch.Elapsed.ToString();
                                });
                            }
                            if (Controls.Find("persentaselabel", true)[0] is Label persentaselabeltemp)
                            {
                                persentaselabeltemp.Invoke((MethodInvoker)delegate
                                {
                                    persentaselabeltemp.Text = ": 100%";
                                });
                            }
                            if (Controls.Find("pictureBox2", true)[0] is PictureBox picture2)
                            {
                                picture2.Invoke(new Action(() => picture2.Image = FingerprintProcessor.BinaryToBitmap(BinaryToAsciiConverter.AsciiToBinary(ascii2, 103, 96))));
                                //pictures.Image = Image.FromFile(bestMatchImagePath);
                                if (Controls.Find("label3", true)[0] is Label labela)
                                {
                                    labela.Invoke(new Action(() => labela.Text = ascii2));
                                    //labela.Text = bestMatchImagePath;
                                }
                                //pictures.BringToFront();
                                picture2.Invoke(new Action(() => picture2.BringToFront()));
                            }
                            if (Controls.Find("label4", true)[0] is Label laa4)
                            {
                                laa4.Invoke(new Action(() => laa4.Text = db.GetBiodata(nama)));
                                Debug.WriteLine(db.GetBiodata(nama));
                            }
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
     
                        Console.WriteLine($"Error processing image  {ex.Message}");
                    }
                }
                string? bestMatchname = null;
                double similarity = double.MinValue;
                string? best = null;
                foreach (var entry in fingers)
                {
                    string name = entry.Nama;
                    string ascii2 = entry.BerkasCitra;
                    //string ascii2 = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinaryCenter(imagePath));
                    double sim = LCSC.CalculateSimilarity(ascii1, ascii2);
                    if (sim > similarity)
                    {
                        similarity = sim;
                        bestMatchname = name;
                        best = ascii2;
                    }
                }
                stopwatch.Stop();
                if (Controls.Find("waktulabel", true)[0] is Label waktulabel)
                {
                    waktulabel.Invoke(new Action(() => waktulabel.Text = ": " + stopwatch.Elapsed.ToString()));
                    //waktulabel.Text = ": " + stopwatch.Elapsed.ToString();
                }
                similarity *= 100;
                if (Controls.Find("persentaselabel", true)[0] is Label persentaselabel)
                {
                    persentaselabel.Invoke(new Action(() => persentaselabel.Text = ": " + $"{similarity:F2}%"));
                    //persentaselabel.Text = ": " + $"{similarity:F2}%";
                }
                if (Controls.Find("pictureBox2", true)[0] is PictureBox pictures)
                {
                    pictures.Invoke(new Action(() => pictures.Image = FingerprintProcessor.BinaryToBitmap(BinaryToAsciiConverter.AsciiToBinary(best, 103, 96))));
                    //pictures.Image = Image.FromFile(bestMatchImagePath);
                    if (Controls.Find("label3", true)[0] is Label labela)
                    {
                        labela.Invoke(new Action(() => labela.Text = bestMatchname));
                        //labela.Text = bestMatchImagePath;
                    }
                    //pictures.BringToFront();
                    pictures.Invoke(new Action(()=> pictures.BringToFront()));
                }
                if (Controls.Find("label4", true)[0] is Label la4)
                {
                    la4.Invoke(new Action(() => la4.Text = db.GetBiodata(bestMatchname)));
                    Debug.WriteLine(db.GetBiodata(bestMatchname));
                }

            }
            else
            {
                Debug.Write("Error");
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
    }
}
