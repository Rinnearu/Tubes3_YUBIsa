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
            PanelKeluaran = new Panel();
            PanelBiodata = new Panel();
            SuspendLayout();
            // 
            // PanelMasukan
            // 
            PanelMasukan.Anchor = AnchorStyles.Bottom;
            PanelMasukan.BackColor = SystemColors.ControlLight;
            PanelMasukan.BorderStyle = BorderStyle.FixedSingle;
            PanelMasukan.Location = new Point(92, 192);
            PanelMasukan.Name = "PanelMasukan";
            PanelMasukan.Size = new Size(307, 362);
            PanelMasukan.TabIndex = 0;
            PanelMasukan.Paint += PanelMasukan_Paint;
            // 
            // PanelKeluaran
            // 
            PanelKeluaran.Anchor = AnchorStyles.Bottom;
            PanelKeluaran.BackColor = SystemColors.ControlLight;
            PanelKeluaran.BorderStyle = BorderStyle.FixedSingle;
            PanelKeluaran.Location = new Point(494, 192);
            PanelKeluaran.Name = "PanelKeluaran";
            PanelKeluaran.Size = new Size(307, 362);
            PanelKeluaran.TabIndex = 1;
            PanelKeluaran.Paint += PanelKeluaran_Paint;
            // 
            // PanelBiodata
            // 
            PanelBiodata.Anchor = AnchorStyles.Bottom;
            PanelBiodata.BackColor = SystemColors.ControlLight;
            PanelBiodata.BorderStyle = BorderStyle.FixedSingle;
            PanelBiodata.Location = new Point(881, 192);
            PanelBiodata.Name = "PanelBiodata";
            PanelBiodata.Size = new Size(307, 362);
            PanelBiodata.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(PanelBiodata);
            Controls.Add(PanelKeluaran);
            Controls.Add(PanelMasukan);
            Name = "YUBIsa";
            Text = "YUBIsa";
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMasukan;
        private Panel PanelKeluaran;
        private Panel PanelBiodata;
    }
}
