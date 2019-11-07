using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiClientWindow.Viewmodel;
using System.Windows.Forms;
using MultiClientClient.Viewmodel;
using System.Windows.Threading;

namespace MultiClientWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        Login l;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            l = new Login();
            l.Connect(Nickname.Text,this, Dispatcher.CurrentDispatcher);
            button1.Enabled = false;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox3.Text))
            new Sending(l).Send(textBox3.Text);
            textBox3.Text = String.Empty;
           

        }

        private void ListView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
