
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MainPage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPage
            // 
            this.MainPage.CreationProperties = null;
            this.MainPage.DefaultBackgroundColor = System.Drawing.Color.White;
            this.MainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPage.Location = new System.Drawing.Point(0, 0);
            this.MainPage.Name = "MainPage";
            this.MainPage.Size = new System.Drawing.Size(1012, 673);
            this.MainPage.Source = new System.Uri("http://localhost:4200", System.UriKind.Absolute);
            this.MainPage.TabIndex = 1;
            this.MainPage.ZoomFactor = 1D;
            this.MainPage.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.MainPage_NavigationCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.labelClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 103);
            this.panel1.TabIndex = 10;
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelClose.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelClose.Location = new System.Drawing.Point(976, -8);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(47, 58);
            this.labelClose.TabIndex = 11;
            this.labelClose.Text = "x";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(216)))), ((int)(((byte)(235)))));
            this.label1.Location = new System.Drawing.Point(-24, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "Draft Tool";
            // 
            // Drafts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainPage);
            this.Name = "Drafts";
            this.Text = "Drafts";
            ((System.ComponentModel.ISupportInitialize)(this.MainPage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 MainPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelClose;
    }
}