using MultiClientClient.Viewmodel;
using MultiClientWindow.Viewmodel;
using MultiServe.Net.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiClientWindow.View
{
    public partial class RoomPassword : Form
    {
        string select;
        public RoomPassword(string selected)
        {
            InitializeComponent();
            select = selected;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Sending(Form1.l).ChangeRoom(Login.nick, select, textBox1.Text);
            this.Close();
        }
    }
}
