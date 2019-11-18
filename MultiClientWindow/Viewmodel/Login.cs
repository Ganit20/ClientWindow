using MultiClientClient.Model;
using MultiClientClient.Viewmodel;
using MultiClientWindow.Model;
using MultiClientWindow.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MultiClientWindow.Viewmodel
{
    public class Login
    {
        public NetworkStream stream;
        public Dispatcher p;
        public static Form1 form;
        public static TcpClient c;
        public static Register r;
        public static string nick;
        public void Connect(string IP, string Nickname, string Password, Form1 form1, Dispatcher d)

        {

            nick = Nickname;
            form = form1;
            const int port = 8000;
            string ip = IP;

            p = d;

            try
            {
                c = new TcpClient(ip, port);
                if (c.Connected)
                {

                    stream = c.GetStream();
                    LoginMe(Nickname, Password);
                    
                    form1.Nickname.Enabled = false;
                    form1.button1.Enabled = false;
                    form1.button4.Enabled = false;
                    form1.textBox4.Enabled = false;
                    form1.textBox5.Enabled = false;
                }
            }
            catch (TypeInitializationException r)
            {
                form.textBox1.Text += "Can not connect to the server";

            }
            catch (SocketException e)
            {
                form.textBox1.Text += "Can not connect to the server";
            }
        }
        public void registerMe(string Nick, string Password, string email,Register reg,Dispatcher disp,string IP)
        {
            r = reg;
            const int port = 8000;
            string ip = IP; 
            c = new TcpClient(ip, port);
            if (c.Connected)
            {
                var st = c.GetStream();
                var msg = JsonConvert.SerializeObject(new user() { Name = Nick, email = email, password = Password });
                msg = "REG?" + msg + "?END";
                byte[] g = System.Text.Encoding.ASCII.GetBytes(msg);
                st.Write(g, 0, g.Length);
                var rec = new Receiving();
                rec.Reading(st, reg, disp);
            }
        }
         void LoginMe(string Nickname, string Password)
            {

                NetworkStream st = stream;
                string From = Nickname;
                string IP = AddressFamily.InterNetwork.ToString();
                var info = new user() { Name = From, IP = IP, password = Password };
                string U_info = JsonConvert.SerializeObject(info);
                U_info = "LOG?" + U_info;
                var form1 = form;
                Byte[] b_info = new Byte[100];
                b_info = System.Text.Encoding.ASCII.GetBytes(U_info);
                st.Write(b_info, 0, b_info.Length);
                var disp = Dispatcher.CurrentDispatcher;
                Task.Factory.StartNew(() => {
                    var rec = new Receiving();
                    rec.Reading(st, form1, p);
                });



            }
        }
    } 

