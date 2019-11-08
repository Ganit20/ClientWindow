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
        private void Button1_Click(object sender, EventArgs e)
        {
            listView2.Items.Add("Connecting to server...");
            l = new Login();
            l.Connect(Nickname.Text,this, Dispatcher.CurrentDispatcher);
            button1.Enabled = false;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox3.Text))
            new Sending(l).Send(textBox3.Text, Nickname.Text);
            textBox3.Text = String.Empty;
        }

    }
}
