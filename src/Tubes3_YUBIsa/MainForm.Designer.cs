namespace Tubes3_YUBIsa
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            PanelBiodata = new Panel();
            label4 = new Label();
            label1 = new Label();
            button1 = new Button();
            checkBox1 = new CheckBox();
            searchButton = new Button();
            label5 = new Label();
            label6 = new Label();
            waktulabel = new Label();
            persentaselabel = new Label();
            label2 = new Label();
            PanelMasukan = new Panel();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            PanelKeluaran = new Panel();
            LoadingPicture = new PictureBox();
            LoadingPanel = new Panel();
            LabelLoading = new Label();
            pictureBox2 = new PictureBox();
            PanelBiodata.SuspendLayout();
            PanelMasukan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelKeluaran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LoadingPicture).BeginInit();
            LoadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // PanelBiodata
            // 
            PanelBiodata.BackColor = SystemColors.ActiveBorder;
            PanelBiodata.BorderStyle = BorderStyle.FixedSingle;
            PanelBiodata.Controls.Add(label4);
            PanelBiodata.Location = new Point(872, 230);
            PanelBiodata.Name = "PanelBiodata";
            PanelBiodata.Size = new Size(285, 435);
            PanelBiodata.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(87, 193);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.MaximumSize = new Size(143, 0);
            label4.Name = "label4";
            label4.Size = new Size(115, 80);
            label4.TabIndex = 1;
            label4.Text = "List Biodata";
            label4.Click += label4_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BackColor = Color.FromArgb(128, 64, 0);
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI Historic", 27F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.MaximumSize = new Size(3000, 833);
            label1.Name = "label1";
            label1.Size = new Size(1279, 87);
            label1.TabIndex = 3;
            label1.Text = "YUBIsa Fingerprint Matcher";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(113, 159);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(107, 38);
            button1.TabIndex = 4;
            button1.Text = "Pilih Citra";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox1.Location = new Point(276, 161);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(61, 35);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "BM";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // searchButton
            // 
            searchButton.Enabled = false;
            searchButton.Location = new Point(652, 164);
            searchButton.Margin = new Padding(4, 5, 4, 5);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(107, 38);
            searchButton.TabIndex = 6;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchbutton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(872, 119);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(141, 25);
            label5.TabIndex = 7;
            label5.Text = "Waktu Pencarian";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(872, 163);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(185, 25);
            label6.TabIndex = 8;
            label6.Text = "Persentase Kecocokan";
            // 
            // waktulabel
            // 
            waktulabel.AutoSize = true;
            waktulabel.Location = new Point(1089, 119);
            waktulabel.Margin = new Padding(4, 0, 4, 0);
            waktulabel.Name = "waktulabel";
            waktulabel.Size = new Size(74, 25);
            waktulabel.TabIndex = 9;
            waktulabel.Text = ": xxx ms";
            waktulabel.Click += waktulabel_Click;
            // 
            // persentaselabel
            // 
            persentaselabel.AutoSize = true;
            persentaselabel.Location = new Point(1089, 163);
            persentaselabel.Margin = new Padding(4, 0, 4, 0);
            persentaselabel.Name = "persentaselabel";
            persentaselabel.Size = new Size(52, 25);
            persentaselabel.TabIndex = 10;
            persentaselabel.Text = ": xx%";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(74, 128);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.MaximumSize = new Size(143, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 80);
            label2.TabIndex = 0;
            label2.Text = "Sidik Jari Masukan";
            label2.Click += label2_Click;
            // 
            // PanelMasukan
            // 
            PanelMasukan.BackColor = SystemColors.ActiveBorder;
            PanelMasukan.BorderStyle = BorderStyle.FixedSingle;
            PanelMasukan.Controls.Add(label2);
            PanelMasukan.Controls.Add(pictureBox1);
            PanelMasukan.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PanelMasukan.Location = new Point(113, 230);
            PanelMasukan.Name = "PanelMasukan";
            PanelMasukan.Size = new Size(273, 342);
            PanelMasukan.TabIndex = 0;
            PanelMasukan.Paint += PanelMasukan_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-1, -2);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(274, 343);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(73, 128);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.MaximumSize = new Size(143, 0);
            label3.Name = "label3";
            label3.Size = new Size(135, 80);
            label3.TabIndex = 1;
            label3.Text = "Sidik Jari Cocok";
            label3.Click += label3_Click;
            // 
            // PanelKeluaran
            // 
            PanelKeluaran.BackColor = SystemColors.ActiveBorder;
            PanelKeluaran.BorderStyle = BorderStyle.FixedSingle;
            PanelKeluaran.Controls.Add(label3);
            PanelKeluaran.Controls.Add(pictureBox2);
            PanelKeluaran.Location = new Point(486, 230);
            PanelKeluaran.Name = "PanelKeluaran";
            PanelKeluaran.Size = new Size(273, 342);
            PanelKeluaran.TabIndex = 1;
            PanelKeluaran.Paint += PanelKeluaran_Paint;
            // 
            // LoadingPicture
            // 
            LoadingPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LoadingPicture.Image = (Image)resources.GetObject("LoadingPicture.Image");
            LoadingPicture.ImageLocation = "";
            LoadingPicture.Location = new Point(535, 191);
            LoadingPicture.Name = "LoadingPicture";
            LoadingPicture.Size = new Size(198, 198);
            LoadingPicture.TabIndex = 0;
            LoadingPicture.TabStop = false;
            LoadingPicture.Click += pictureBox2_Click_1;
            // 
            // LoadingPanel
            // 
            LoadingPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LoadingPanel.BackColor = Color.Transparent;
            LoadingPanel.Controls.Add(LabelLoading);
            LoadingPanel.Controls.Add(LoadingPicture);
            LoadingPanel.Location = new Point(0, 87);
            LoadingPanel.Name = "LoadingPanel";
            LoadingPanel.Size = new Size(1279, 648);
            LoadingPanel.TabIndex = 11;
            LoadingPanel.Visible = false;
            // 
            // LabelLoading
            // 
            LabelLoading.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelLoading.AutoSize = true;
            LabelLoading.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelLoading.Location = new Point(584, 397);
            LabelLoading.Name = "LabelLoading";
            LabelLoading.Size = new Size(106, 38);
            LabelLoading.TabIndex = 1;
            LabelLoading.Text = "Loading";
            LabelLoading.UseCompatibleTextRendering = true;
            LabelLoading.Click += label7_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(-1, -1);
            pictureBox2.Margin = new Padding(4, 5, 4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(274, 343);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(1279, 735);
            Controls.Add(persentaselabel);
            Controls.Add(waktulabel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(searchButton);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(PanelBiodata);
            Controls.Add(PanelKeluaran);
            Controls.Add(PanelMasukan);
            Controls.Add(LoadingPanel);
            Name = "MainForm";
            Text = "YUBIsa";
            Load += Form1_Load;
            PanelBiodata.ResumeLayout(false);
            PanelBiodata.PerformLayout();
            PanelMasukan.ResumeLayout(false);
            PanelMasukan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelKeluaran.ResumeLayout(false);
            PanelKeluaran.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LoadingPicture).EndInit();
            LoadingPanel.ResumeLayout(false);
            LoadingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel PanelBiodata;
        private Label label1;
        private Label label4;
        private Button button1;
        private CheckBox checkBox1;
        private Button searchButton;
        private Label label5;
        private Label label6;
        private Label waktulabel;
        private Label persentaselabel;
        private Label label2;
        private Panel PanelMasukan;
        private PictureBox pictureBox1;
        private Label label3;
        private Panel PanelKeluaran;
        private PictureBox LoadingPicture;
        private Panel LoadingPanel;
        private Label LabelLoading;
        private PictureBox pictureBox2;
    }
}
