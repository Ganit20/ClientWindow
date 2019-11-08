using MultiClientClient.Model;
using MultiClientClient.Viewmodel;
using MultiClientWindow.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MultiClientWindow.Viewmodel
{
    class Login
    {
       public NetworkStream stream;
        public Dispatcher p;
        public void Connect(String Nickname, Form1 form1,Dispatcher d)
            
        {
            const int port = 8000;
            p = d;
            
                try
            {
                TcpClient c = new TcpClient("127.0.0.1", port);
                if (c.Connected)
                {
                    form1.listView2.Items.Add("Connected");
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
           Task.Factory.StartNew(() => {
               var rec = new Receiving();
               rec.Reading(st,form1,p);
               });
            


        }
    }
}

