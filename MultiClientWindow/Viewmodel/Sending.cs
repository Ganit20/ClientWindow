using MultiClientClient.Model;
using MultiClientWindow;
using MultiClientWindow.View;
using MultiClientWindow.Viewmodel;
using MultiServe.Net.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MultiClientClient.Viewmodel
{
    class Sending
    {
        public Sending(Login l) { login = l; }
        Login login;
        NetworkStream st;

        public  void Send(String msg, String nick)
        {

            st = login.stream;
            String From = nick;
                String IP = AddressFamily.InterNetwork.ToString();
                var m = new Msg_Info() { Message = msg, From = From , IP = IP, MsgTime = "[" +DateTime.UtcNow+"]" };
                var msgJson = JsonConvert.SerializeObject(m);
                var g = msgJson.Length + "?";
                while (g.Length < 4)
                {
                    g = "0" + g;
                }
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(g + msgJson);
            try
            {
                st.Write(data, 0, data.Length);
            }
            catch (IOException)
            {
                WindowPopup popup = new WindowPopup();

                popup.ShowDialog();
            }
        }

        public void CreateRoom(string Name,string creator,bool checkpass,string password) {
            st = login.stream;
            var msg = JsonConvert.SerializeObject(new Room_info() { name = Name, roomCreatorName = creator,isPassword=checkpass,password=password });
            byte[] bmsg = System.Text.Encoding.ASCII.GetBytes("CRC?" + msg);
           st.Write(bmsg,0,bmsg.Length);
        }
        public void ChangeRoom(string Name, string Room,string password)
        {
            st = login.stream;
            var msg = JsonConvert.SerializeObject(new Room_info() { name = Name, NewRoom = Room, password= password});
            byte[] bmsg = System.Text.Encoding.ASCII.GetBytes("URC?" + msg);
            st.Write(bmsg, 0, bmsg.Length);
        }

    }
}
