namespace DotaHelper_Desktop
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
            this.MainPage = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.BRRefresh = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LBSelectFolder = new System.Windows.Forms.Label();
            this.BTSelectFolder = new System.Windows.Forms.Button();
            this.PBBanHero = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHero)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPage
            // 
            this.MainPage.CreationProperties = null;
            this.MainPage.DefaultBackgroundColor = System.Drawing.Color.White;
            this.MainPage.Location = new System.Drawing.Point(-2, 9);
            this.MainPage.Name = "MainPage";
            this.MainPage.Size = new System.Drawing.Size(1286, 614);
            this.MainPage.Source = new System.Uri("http://localhost:4200", System.UriKind.Absolute);
            this.MainPage.TabIndex = 0;
            this.MainPage.ZoomFactor = 1D;
            // 
            // BRRefresh
            // 
            this.BRRefresh.Location = new System.Drawing.Point(869, 594);
            this.BRRefresh.Name = "BRRefresh";
            this.BRRefresh.Size = new System.Drawing.Size(94, 29);
            this.BRRefresh.TabIndex = 1;
            this.BRRefresh.Text = "Refresh";
            this.BRRefresh.UseVisualStyleBackColor = true;
            this.BRRefresh.Click += new System.EventHandler(this.BRRefresh_Click);
            // 
            // LBSelectFolder
            // 
            this.LBSelectFolder.AutoSize = true;
            this.LBSelectFolder.Location = new System.Drawing.Point(859, 9);
            this.LBSelectFolder.Name = "LBSelectFolder";
            this.LBSelectFolder.Size = new System.Drawing.Size(173, 20);
            this.LBSelectFolder.TabIndex = 2;
            this.LBSelectFolder.Text = "Select your dota 2 folder";
            // 
            // BTSelectFolder
            // 
            this.BTSelectFolder.Location = new System.Drawing.Point(859, 32);
            this.BTSelectFolder.Name = "BTSelectFolder";
            this.BTSelectFolder.Size = new System.Drawing.Size(94, 29);
            this.BTSelectFolder.TabIndex = 3;
            this.BTSelectFolder.Text = "Select ...";
            this.BTSelectFolder.UseVisualStyleBackColor = true;
            this.BTSelectFolder.Click += new System.EventHandler(this.BTSelectFolder_Click);
            // 
            // PBBanHero
            // 
            this.PBBanHero.Location = new System.Drawing.Point(869, 201);
            this.PBBanHero.Name = "PBBanHero";
            this.PBBanHero.Size = new System.Drawing.Size(415, 297);
            this.PBBanHero.TabIndex = 4;
            this.PBBanHero.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 635);
            this.Controls.Add(this.PBBanHero);
            this.Controls.Add(this.BTSelectFolder);
            this.Controls.Add(this.LBSelectFolder);
            this.Controls.Add(this.BRRefresh);
            this.Controls.Add(this.MainPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBBanHero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 MainPage;
        private System.Windows.Forms.Button BRRefresh;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label LBSelectFolder;
        private System.Windows.Forms.Button BTSelectFolder;
        private System.Windows.Forms.PictureBox PBBanHero;
    }
}
