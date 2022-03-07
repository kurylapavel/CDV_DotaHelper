using DataModel;
using DataModel.OpenDota;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaHelper_Desktop
{
    public partial class MainForm : Form
    {
        private Button currentButton;
        private Form activeForm;
        Point myPoint;

        public MainForm()
        {
            InitializeComponent();
            StartForm(new Forms.Drafts());
            
        }

        

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if(currentButton != (Button) btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(205, 85, 84);
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void DisableButton()
        {
            foreach(Control btn in panelNavBot.Controls)
            {
                btn.BackColor = Color.FromArgb(51, 51, 76);
                btn.ForeColor = Color.Silver;
            }
        }

        private void StartForm (Form form)
        {
            ActivateButton(buttonDraft);
            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panelBans.Controls.Add(form);
            this.panelBans.Tag = form;
            form.BringToFront();
            form.Show();
            changePanel(form);
        }


        private void OpenForm(Form form, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panelBans.Controls.Add(form);
            this.panelBans.Tag = form;
            form.BringToFront();
            form.Show();
            changePanel(form);
            
        }

        private void changePanel(Form form)
        {
            if(form.Text == "Drafts")
            {
                labelTitle.ForeColor = Color.FromArgb(0, 216, 235);
                labelTitle.Text = "Draft Tool";
            }

            if(form.Text == "Bans")
            {
                labelTitle.ForeColor = Color.FromArgb(205, 85, 84);
                labelTitle.Text = "Ban Tool";
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void buttonDraft_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Drafts(), sender);
        }

        private void buttonBans_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Bans(), sender);
        }



        private void panelLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - myPoint.X;
                this.Top += e.Y - myPoint.Y;
            }
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            myPoint = new Point(e.X, e.Y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - myPoint.X;
                this.Top += e.Y - myPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            myPoint = new Point(e.X, e.Y);
        }

        private void labelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - myPoint.X;
                this.Top += e.Y - myPoint.Y;
            }
        }

        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            myPoint = new Point(e.X, e.Y);
        }



        private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
