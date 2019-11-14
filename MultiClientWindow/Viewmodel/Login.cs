using MultiClientClient.Model;
using MultiClientClient.Viewmodel;
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
        public static string nick;
        public void Connect(String Nickname, Form1 form1,Dispatcher d)
            
        {

            nick = Nickname;
            form = form1;
            const int port = 8000;
            string ip = "127.0.0.1";
           
            p = d;
            
                try
            {
                 c = new TcpClient(ip, port);
                if (c.Connected)
                {
                   
                    stream = c.GetStream();
                    LoginMe(Nickname, stream, form1);
                }
            }
            catch (TypeInitializationException r)
            {
                Console.WriteLine("Can not connect to the server");

            }catch(SocketException e)
            {
                WindowPopup popup = new WindowPopup();
                popup.ShowDialog();
                form1.button1.Enabled = true;
            }
        }
         void LoginMe(String Nickname,Object stream, Form1 form1)
        {
            NetworkStream st = (NetworkStream)stream;
            String From = Nickname;
            String IP = AddressFamily.InterNetwork.ToString();
            var info = new Msg_Info() { From = From, IP = IP, MsgTime = DateTime.UtcNow.ToString() };
            String U_info = JsonConvert.SerializeObject(info);
            U_info = "user" + U_info;

            Byte[] b_info = new Byte[100];
            b_info = System.Text.Encoding.ASCII.GetBytes(U_info);
            st.Write(b_info, 0, b_info.Length);
            var disp = Dispatcher.CurrentDispatcher;
            form.textBox1.Text = "You are chatting at: Main";
           Task.Factory.StartNew(() => {
               var rec = new Receiving();
               rec.Reading(st,form1,p);
               });
            


        }
    }
}

