
namespace DotaHelper_Desktop.Forms
{
    partial class Bans
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBBanHero = new System.Windows.Forms.PictureBox();
            this.BTSelectFolder = new System.Windows.Forms.Button();
            this.LBSelectFolder = new System.Windows.Forms.Label();
            this.BRRefresh = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureSettings = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PBBanHeroS4 = new System.Windows.Forms.PictureBox();
            this.PBBanHeroS3 = new System.Windows.Forms.PictureBox();
            this.PBBanHeroS2 = new System.Windows.Forms.PictureBox();
            this.PBBanHeroS1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHero)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettings)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS1)).BeginInit();
            this.SuspendLayout();
            // 
            // PBBanHero
            // 
            this.PBBanHero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.PBBanHero.Location = new System.Drawing.Point(93, 59);
            this.PBBanHero.Name = "PBBanHero";
            this.PBBanHero.Size = new System.Drawing.Size(256, 144);
            this.PBBanHero.TabIndex = 8;
            this.PBBanHero.TabStop = false;
            // 
            // BTSelectFolder
            // 
            this.BTSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSelectFolder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTSelectFolder.Location = new System.Drawing.Point(252, 409);
            this.BTSelectFolder.Name = "BTSelectFolder";
            this.BTSelectFolder.Size = new System.Drawing.Size(94, 29);
            this.BTSelectFolder.TabIndex = 7;
            this.BTSelectFolder.Text = "Browse";
            this.BTSelectFolder.UseVisualStyleBackColor = true;
            this.BTSelectFolder.Click += new System.EventHandler(this.BTSelectFolder_Click_1);
            // 
            // LBSelectFolder
            // 
            this.LBSelectFolder.AutoSize = true;
            this.LBSelectFolder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LBSelectFolder.Location = new System.Drawing.Point(102, 370);
            this.LBSelectFolder.Name = "LBSelectFolder";
            this.LBSelectFolder.Size = new System.Drawing.Size(244, 20);
            this.LBSelectFolder.TabIndex = 6;
            this.LBSelectFolder.Text = "Browse your Dota 2 folder location:";
            // 
            // BRRefresh
            // 
            this.BRRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRRefresh.ForeColor = System.Drawing.Color.Silver;
            this.BRRefresh.Location = new System.Drawing.Point(105, 444);
            this.BRRefresh.Name = "BRRefresh";
            this.BRRefresh.Size = new System.Drawing.Size(211, 73);
            this.BRRefresh.TabIndex = 5;
            this.BRRefresh.Text = "Suggest";
            this.BRRefresh.UseVisualStyleBackColor = true;
            this.BRRefresh.Click += new System.EventHandler(this.BRRefresh_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.labelClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 104);
            this.panel1.TabIndex = 9;
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelClose.Location = new System.Drawing.Point(976, -8);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(47, 58);
            this.labelClose.TabIndex = 1;
            this.labelClose.Text = "x";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(85)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(-23, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ban Tool";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(252, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "You need only configurate it once.";
            // 
            // pictureSettings
            // 
            this.pictureSettings.BackgroundImage = global::DotaHelper_Desktop.Properties.Resources.settings;
            this.pictureSettings.InitialImage = null;
            this.pictureSettings.Location = new System.Drawing.Point(252, 59);
            this.pictureSettings.Name = "pictureSettings";
            this.pictureSettings.Size = new System.Drawing.Size(89, 69);
            this.pictureSettings.TabIndex = 11;
            this.pictureSettings.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(111, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(373, 97);
            this.label3.TabIndex = 12;
            this.label3.Text = "Settings";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(140)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.LBSelectFolder);
            this.panel2.Controls.Add(this.pictureSettings);
            this.panel2.Controls.Add(this.BTSelectFolder);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(441, 104);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 569);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.PBBanHeroS4);
            this.panel3.Controls.Add(this.PBBanHeroS3);
            this.panel3.Controls.Add(this.PBBanHeroS2);
            this.panel3.Controls.Add(this.PBBanHeroS1);
            this.panel3.Controls.Add(this.PBBanHero);
            this.panel3.Controls.Add(this.BRRefresh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(441, 569);
            this.panel3.TabIndex = 14;
            // 
            // PBBanHeroS4
            // 
            this.PBBanHeroS4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.PBBanHeroS4.Location = new System.Drawing.Point(244, 316);
            this.PBBanHeroS4.Name = "PBBanHeroS4";
            this.PBBanHeroS4.Size = new System.Drawing.Size(128, 72);
            this.PBBanHeroS4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBBanHeroS4.TabIndex = 12;
            this.PBBanHeroS4.TabStop = false;
            // 
            // PBBanHeroS3
            // 
            this.PBBanHeroS3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.PBBanHeroS3.Location = new System.Drawing.Point(68, 316);
            this.PBBanHeroS3.Name = "PBBanHeroS3";
            this.PBBanHeroS3.Size = new System.Drawing.Size(128, 72);
            this.PBBanHeroS3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBBanHeroS3.TabIndex = 11;
            this.PBBanHeroS3.TabStop = false;
            // 
            // PBBanHeroS2
            // 
            this.PBBanHeroS2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.PBBanHeroS2.Location = new System.Drawing.Point(244, 222);
            this.PBBanHeroS2.Name = "PBBanHeroS2";
            this.PBBanHeroS2.Size = new System.Drawing.Size(128, 72);
            this.PBBanHeroS2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBBanHeroS2.TabIndex = 10;
            this.PBBanHeroS2.TabStop = false;
            // 
            // PBBanHeroS1
            // 
            this.PBBanHeroS1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(41)))), ((int)(((byte)(42)))));
            this.PBBanHeroS1.Location = new System.Drawing.Point(68, 222);
            this.PBBanHeroS1.Name = "PBBanHeroS1";
            this.PBBanHeroS1.Size = new System.Drawing.Size(128, 72);
            this.PBBanHeroS1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBBanHeroS1.TabIndex = 9;
            this.PBBanHeroS1.TabStop = false;
            // 
            // Bans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(38)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1012, 673);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Bans";
            this.Text = "Bans";
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHero)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettings)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHeroS1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBBanHero;
        private System.Windows.Forms.Button BTSelectFolder;
        private System.Windows.Forms.Label LBSelectFolder;
        private System.Windows.Forms.Button BRRefresh;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox PBBanHeroS4;
        private System.Windows.Forms.PictureBox PBBanHeroS3;
        private System.Windows.Forms.PictureBox PBBanHeroS2;
        private System.Windows.Forms.PictureBox PBBanHeroS1;
        private System.Windows.Forms.Label labelClose;
    }
}