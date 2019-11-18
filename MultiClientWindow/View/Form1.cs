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
using MultiClientWindow.View;

namespace MultiClientWindow
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            
        }
        public static Login l;
        private void Button1_Click(object sender, EventArgs e)
        {
            this.AcceptButton = button2;
            
            l = new Login();
            l.Connect(textBox5.Text,Nickname.Text,textBox4.Text,this, Dispatcher.CurrentDispatcher);
            
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox3.Text))
            new Sending(l).Send(textBox3.Text, Nickname.Text);
            textBox3.Text = String.Empty;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            RoomCreator room = new RoomCreator(l);
            room.ShowDialog();
            

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bool ispassword;
                if (Receiving.json[listBox1.SelectedItem.ToString()])
                {
                    RoomPassword password = new RoomPassword(listBox1.SelectedItem.ToString());
                    password.ShowDialog();
                
                }
                else
                {
                    var a = listBox1.SelectedItem.ToString();
                    if (a != "" || a != "Chat Rooms: ")
                    {
                        new Sending(l).ChangeRoom(Nickname.Text, a,"");

                    }
                }
            }
            catch(NullReferenceException)
            {}
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Register register = new Register(Dispatcher.CurrentDispatcher);
            new Register(Dispatcher.CurrentDispatcher).ShowDialog();
            
        }
    }
}
