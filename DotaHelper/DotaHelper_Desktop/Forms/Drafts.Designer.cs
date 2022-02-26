
namespace DotaHelper_Desktop.Forms
{
    partial class Drafts
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
            this.MainPage = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.MainPage)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPage
            // 
            this.MainPage.CreationProperties = null;
            this.MainPage.DefaultBackgroundColor = System.Drawing.Color.White;
            this.MainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPage.Location = new System.Drawing.Point(0, 0);
            this.MainPage.Name = "MainPage";
            this.MainPage.Size = new System.Drawing.Size(1012, 569);
            this.MainPage.Source = new System.Uri("http://localhost:4200", System.UriKind.Absolute);
            this.MainPage.TabIndex = 1;
            this.MainPage.ZoomFactor = 1D;
            this.MainPage.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.MainPage_NavigationCompleted);
            // 
            // Drafts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 569);
            this.Controls.Add(this.MainPage);
            this.Name = "Drafts";
            this.Text = "Drafts";
            ((System.ComponentModel.ISupportInitialize)(this.MainPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 MainPage;
    }
}