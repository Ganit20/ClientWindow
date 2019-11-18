using MultiClientClient.Viewmodel;
using MultiClientWindow.Viewmodel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MultiClientWindow.View
{
    
    public partial class Register : Form
    {
        Dispatcher dispatcher;
        public Register(Dispatcher disp)
        {
            dispatcher = disp;
            InitializeComponent();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Close"))
            {
                this.Close();
            }
            else
            {
                 new Login().registerMe(textBox1.Text, textBox2.Text, textBox3.Text,this,dispatcher,textBox4.Text);
               
                    button1.Text = "Close";
               
            }

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
