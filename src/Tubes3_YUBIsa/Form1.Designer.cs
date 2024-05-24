namespace Tubes3_YUBIsa
{
    partial class Form1
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
            PanelMasukan = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            PanelKeluaran = new Panel();
            label3 = new Label();
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
            PanelMasukan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PanelKeluaran.SuspendLayout();
            PanelBiodata.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMasukan
            // 
            PanelMasukan.Anchor = AnchorStyles.Bottom;
            PanelMasukan.BackColor = SystemColors.ActiveBorder;
            PanelMasukan.BorderStyle = BorderStyle.FixedSingle;
            PanelMasukan.Controls.Add(label2);
            PanelMasukan.Controls.Add(pictureBox1);
            PanelMasukan.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PanelMasukan.Location = new Point(79, 138);
            PanelMasukan.Margin = new Padding(2);
            PanelMasukan.Name = "PanelMasukan";
            PanelMasukan.Size = new Size(192, 206);
            PanelMasukan.TabIndex = 0;
            PanelMasukan.Paint += PanelMasukan_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(52, 77);
            label2.MaximumSize = new Size(100, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 50);
            label2.TabIndex = 0;
            label2.Text = "Sidik Jari Masukan";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(192, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // PanelKeluaran
            // 
            PanelKeluaran.Anchor = AnchorStyles.Bottom;
            PanelKeluaran.BackColor = SystemColors.ActiveBorder;
            PanelKeluaran.BorderStyle = BorderStyle.FixedSingle;
            PanelKeluaran.Controls.Add(label3);
            PanelKeluaran.Location = new Point(340, 138);
            PanelKeluaran.Margin = new Padding(2);
            PanelKeluaran.Name = "PanelKeluaran";
            PanelKeluaran.Size = new Size(192, 206);
            PanelKeluaran.TabIndex = 1;
            PanelKeluaran.Paint += PanelKeluaran_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(51, 77);
            label3.MaximumSize = new Size(100, 0);
            label3.Name = "label3";
            label3.Size = new Size(91, 50);
            label3.TabIndex = 1;
            label3.Text = "Sidik Jari Cocok";
            label3.Click += label3_Click;
            // 
            // PanelBiodata
            // 
            PanelBiodata.Anchor = AnchorStyles.Bottom;
            PanelBiodata.BackColor = SystemColors.ActiveBorder;
            PanelBiodata.BorderStyle = BorderStyle.FixedSingle;
            PanelBiodata.Controls.Add(label4);
            PanelBiodata.Location = new Point(613, 99);
            PanelBiodata.Margin = new Padding(2);
            PanelBiodata.Name = "PanelBiodata";
            PanelBiodata.Size = new Size(200, 300);
            PanelBiodata.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(61, 116);
            label4.MaximumSize = new Size(100, 0);
            label4.Name = "label4";
            label4.Size = new Size(76, 50);
            label4.TabIndex = 1;
            label4.Text = "List Biodata";
            label4.Click += label4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(303, 9);
            label1.MaximumSize = new Size(1000, 500);
            label1.Name = "label1";
            label1.Size = new Size(325, 47);
            label1.TabIndex = 3;
            label1.Text = "FingerPrint Matcher";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(121, 429);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Pilih Citra";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(303, 427);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(35, 25);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "BM";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(478, 427);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 6;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchbutton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(640, 415);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 7;
            label5.Text = "Waktu Pencarian";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(640, 440);
            label6.Name = "label6";
            label6.Size = new Size(124, 15);
            label6.TabIndex = 8;
            label6.Text = "Persentase Kecocokan";
            // 
            // waktulabel
            // 
            waktulabel.AutoSize = true;
            waktulabel.Location = new Point(807, 415);
            waktulabel.Name = "waktulabel";
            waktulabel.Size = new Size(50, 15);
            waktulabel.TabIndex = 9;
            waktulabel.Text = ": xxx ms";
            // 
            // persentaselabel
            // 
            persentaselabel.AutoSize = true;
            persentaselabel.Location = new Point(807, 437);
            persentaselabel.Name = "persentaselabel";
            persentaselabel.Size = new Size(35, 15);
            persentaselabel.TabIndex = 10;
            persentaselabel.Text = ": xx%";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 464);
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
            Margin = new Padding(2);
            Name = "Form1";
            Text = "YUBIsa";
            PanelMasukan.ResumeLayout(false);
            PanelMasukan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PanelKeluaran.ResumeLayout(false);
            PanelKeluaran.PerformLayout();
            PanelBiodata.ResumeLayout(false);
            PanelBiodata.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PanelMasukan;
        private Panel PanelKeluaran;
        private Panel PanelBiodata;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private CheckBox checkBox1;
        private Button searchButton;
        private Label label5;
        private Label label6;
        private Label waktulabel;
        private Label persentaselabel;
        private PictureBox pictureBox1;
    }
}
