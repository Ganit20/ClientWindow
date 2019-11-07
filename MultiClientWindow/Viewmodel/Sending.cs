using MultiClientClient.Model;
using MultiClientWindow;
using MultiClientWindow.Viewmodel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MultiClientClient.Viewmodel
{
    class Sending
    {
        public Sending(Login l) { login = l; }
        public  Form1 f = new Form1();
        Login login;
        public  void Send(String msg)
        {
            
            NetworkStream st = login.stream;
            String From = f.Nickname.Text;
                String IP = AddressFamily.InterNetwork.ToString();
                var m = new Msg_Info() { Message = msg, From = From, IP = IP, MsgTime = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() };
                var msgJson = JsonConvert.SerializeObject(m);
                var g = msgJson.Length + "?";
                while (g.Length < 4)
                {
                    g = "0" + g;
                }
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(g + msgJson);
                st.Write(data, 0, data.Length);
        }
    }
}
