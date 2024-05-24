using System.Diagnostics;

namespace Tubes3_YUBIsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

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

                PictureBox pictureBox = this.Controls.Find("pictureBox1", true)[0] as PictureBox;
                if (pictureBox != null)
                {
                    pictureBox.Image = Image.FromFile(selectedFilePath);
                    Label label = this.Controls.Find("label2", true)[0] as Label;
                    if (label != null)
                    {
                        label.Text = selectedFilePath;
                    }
                    pictureBox.BringToFront(); // Bring the PictureBox to the front
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

        private void searchbutton_Click(object sender, EventArgs e)
        {
            searchButton.Text = "loading";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Label label = this.Controls.Find("label2", true)[0] as Label;
            if (label != null)
            {
                string pathori = label.Text;
                string relativePath = @"SOCOFing\Real"; // Assuming there is an 'images' directory in the same directory as the executable
                string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", relativePath);

                // Check if the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine($"Directory not found: {directoryPath}");
                    return;
                }
                string ascii1 = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinary(pathori));
                // Get all image files from the directory
                string[] imageFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly)
                                               .Where(file => file.ToLower().EndsWith("jpg") ||
                                                              file.ToLower().EndsWith("jpeg") ||
                                                              file.ToLower().EndsWith("png") ||
                                                              file.ToLower().EndsWith("bmp") ||
                                                              file.ToLower().EndsWith("gif")).ToArray();
                bool kmp = false;
                CheckBox check = this.Controls.Find("checkBox1", true)[0] as CheckBox;
                if (check != null)
                {
                    if (check.Checked)
                    {
                        kmp = true;
                    }
                }
                foreach (string imagePath in imageFiles)
                {
                    try
                    {
                        Debug.WriteLine(1);
                        // Process each image
                        string ascii2 = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinary(imagePath));
                        int index;
                        if (kmp)
                        {
                            index = KMPAlgorithm.KMPSearch(ascii2, ascii1);
                        }
                        else
                        {
                            index = BoyerMooreAlgorithm.BoyerMooreSearch(ascii2, ascii1);
                        }
                        if (index != -1)
                        {
                            searchButton.Text = "Ketemu";
                            stopwatch.Stop();
                            Label waaktulabel = this.Controls.Find("waktulabel", true)[0] as Label;
                            if (waaktulabel != null)
                            {
                                waaktulabel.Text = ": " + stopwatch.Elapsed.ToString();
                            }
                            Label peresentaselabel = this.Controls.Find("persentaselabel", true)[0] as Label;
                            if (peresentaselabel != null)
                            {
                                peresentaselabel.Text = ": 100%";
                            }
                            return;
                        }
                        // Do something with the binary image, e.g., save it, display it, etc.
                        // For demonstration, we'll just print the dimensions of the binary image

                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during image processing
                        Console.WriteLine($"Error processing image {Path.GetFileName(imagePath)}: {ex.Message}");
                    }
                }
                string bestMatchImagePath = null;
                int minDistance = int.MaxValue;
                foreach (string imagePath in imageFiles)
                {
                    string ascii2 = BinaryToAsciiConverter.ConvertToAscii(FingerprintProcessor.ConvertImageToBinary(imagePath));
                    int distance = HammingDistanceCalculator.ComputeHammingDistance(ascii1, ascii2);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        bestMatchImagePath = imagePath;
                    }
                }
                stopwatch.Stop();
                Label waktulabel = this.Controls.Find("waktulabel", true)[0] as Label;
                if (waktulabel != null)
                {
                    waktulabel.Text = ": " + stopwatch.Elapsed.ToString();
                }
                Label persentaselabel = this.Controls.Find("persentaselabel", true)[0] as Label;
                float result1 = (float)1 - (minDistance/ascii1.Length);

                if (persentaselabel != null)
                {
                    persentaselabel.Text = ": " + $"{result1:F2}%";
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
    }
}
