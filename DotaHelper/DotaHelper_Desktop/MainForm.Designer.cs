namespace DotaHelper_Desktop
{
    partial class MainForm
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
            this.panelNav = new System.Windows.Forms.Panel();
            this.panelNavBot = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBans = new System.Windows.Forms.Button();
            this.buttonDraft = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelBans = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelNav.SuspendLayout();
            this.panelNavBot.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNav
            // 
            this.panelNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelNav.Controls.Add(this.panelNavBot);
            this.panelNav.Controls.Add(this.panelLogo);
            this.panelNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNav.Location = new System.Drawing.Point(0, 0);
            this.panelNav.Name = "panelNav";
            this.panelNav.Size = new System.Drawing.Size(250, 720);
            this.panelNav.TabIndex = 5;
            // 
            // panelNavBot
            // 
            this.panelNavBot.Controls.Add(this.label1);
            this.panelNavBot.Controls.Add(this.buttonBans);
            this.panelNavBot.Controls.Add(this.buttonDraft);
            this.panelNavBot.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavBot.Location = new System.Drawing.Point(0, 103);
            this.panelNavBot.Name = "panelNavBot";
            this.panelNavBot.Size = new System.Drawing.Size(250, 617);
            this.panelNavBot.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(56, 591);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "DotaHelper © 2022";
            // 
            // buttonBans
            // 
            this.buttonBans.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBans.FlatAppearance.BorderSize = 0;
            this.buttonBans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBans.ForeColor = System.Drawing.Color.Silver;
            this.buttonBans.Image = global::DotaHelper_Desktop.Properties.Resources.str_trans;
            this.buttonBans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBans.Location = new System.Drawing.Point(0, 69);
            this.buttonBans.Name = "buttonBans";
            this.buttonBans.Size = new System.Drawing.Size(250, 69);
            this.buttonBans.TabIndex = 4;
            this.buttonBans.Text = "Ban Tool";
            this.buttonBans.UseVisualStyleBackColor = true;
            this.buttonBans.Click += new System.EventHandler(this.buttonBans_Click);
            // 
            // buttonDraft
            // 
            this.buttonDraft.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDraft.FlatAppearance.BorderSize = 0;
            this.buttonDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDraft.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonDraft.Image = global::DotaHelper_Desktop.Properties.Resources.int_trans;
            this.buttonDraft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDraft.Location = new System.Drawing.Point(0, 0);
            this.buttonDraft.Name = "buttonDraft";
            this.buttonDraft.Size = new System.Drawing.Size(250, 69);
            this.buttonDraft.TabIndex = 3;
            this.buttonDraft.Text = "Draft Tool";
            this.buttonDraft.UseVisualStyleBackColor = true;
            this.buttonDraft.Click += new System.EventHandler(this.buttonDraft_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 103);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panelLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLogo_MouseDown);
            this.panelLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLogo_MouseMove);
            // 
            // panelBans
            // 
            this.panelBans.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelBans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBans.Location = new System.Drawing.Point(250, 104);
            this.panelBans.Name = "panelBans";
            this.panelBans.Size = new System.Drawing.Size(1030, 616);
            this.panelBans.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.labelClose);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(250, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 104);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
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
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.Silver;
            this.labelTitle.Location = new System.Drawing.Point(-23, 24);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(220, 97);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelBans);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelNav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DotaHelper";
            this.panelNav.ResumeLayout(false);
            this.panelNavBot.ResumeLayout(false);
            this.panelNavBot.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelBans;
        private System.Windows.Forms.Panel panelNavBot;
        private System.Windows.Forms.Button buttonBans;
        private System.Windows.Forms.Button buttonDraft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelTitle;
    }
}
