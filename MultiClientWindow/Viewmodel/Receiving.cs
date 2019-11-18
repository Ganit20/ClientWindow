using MultiClientClient.Model;
using MultiClientWindow;
using MultiServe.Net.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Timers;
using MultiClientWindow.Viewmodel;
using MultiClientWindow.View;

namespace MultiClientClient.Viewmodel
{
    public class Receiving
    {
        public static Dictionary<string, bool> json;
        public static Form1 f;
        public static Dispatcher disp;
        public void Reading(object obj, object form, Dispatcher dispatcher)
        {
            disp = dispatcher;
            System.Timers.Timer timer = new System.Timers.Timer(3000);
            timer.Elapsed += CheckConnection;
            timer.AutoReset = true;
            
            timer.Start();
            NetworkStream stream = (NetworkStream)obj;
            while (true)
            {
                try
                {
                    String response = String.Empty;
                    Byte[] ByteLength = new byte[4];
                    Array.Clear(ByteLength, 0, ByteLength.Length);
                    Int32 bytes = stream.Read(ByteLength, 0, 4);

                    if (stream.DataAvailable)
                    {
                        try
                        {
                            String v = System.Text.Encoding.ASCII.GetString(ByteLength, 0, 4);
                            String d = v.Substring(0, v.IndexOf('?', 0, 4));
                            int bl = int.Parse(d);
                            Byte[] data = new Byte[bl];
                            Int32 msg = stream.Read(data, 0, bl);
                            string strmsg = System.Text.Encoding.ASCII.GetString(data);
                            string vstrmsg = strmsg.Substring(0, strmsg.IndexOf('?'));
                            if(vstrmsg.Equals("RDC"))
                            {
                                Register r = (Register)form;
                                Register(strmsg, dispatcher, r);
                            }else f = (Form1)form;
                            switch (vstrmsg)
                            {
                                case "LOG":
                                    new Messages().login(strmsg, dispatcher, f);
                                    break;
                                case "USE":
                                    new Messages().UserList(strmsg, dispatcher, f);
                                    break;
                                case "RCC":
                                    new Messages().RoomList(strmsg, dispatcher, f);
                                    break;
                                case "MSG":
                                    new Messages().Message(strmsg, dispatcher, f);
                                    break;
                                case "SSG":
                                    new Messages().ChangeRoom(strmsg, dispatcher, f);
                                    break;

                            }
                        }
                        catch (System.ArgumentOutOfRangeException) { }
                    }
                }
                catch (IOException e)
                {
                    Console.Write("Connection Error");
                }
            }
        }
        void Register(string strmsg, Dispatcher dispatcher, Register r)
        {
            strmsg = strmsg.Substring(strmsg.IndexOf('?') + 1, strmsg.IndexOf("?", strmsg.IndexOf('?') + 1) - 4);
            if (strmsg.Equals("Confirmed"))
            {
                dispatcher.Invoke(() =>
                {
                    r.label4.Text = "You are registered";
                    
                });
            }
            else if (strmsg.Equals("Nope"))
            {
                dispatcher.Invoke(() =>
                {
                    r.label4.Text = "Nickname or E-mail is in use try again or log in";
                });
            }
        }
        void CheckConnection(Object src, ElapsedEventArgs e)    
        {
            if(!Login.c.Connected)
            {
                disp.Invoke(() =>
                {
                    f.Nickname.Enabled = true;
                    f.button1.Enabled = true;
                    f.button4.Enabled = true;
                    f.textBox4.Enabled = true;
                    f.textBox5.Enabled = true;
                    f.textBox1.Text += "\r\n Can't connect to server";
                });
            }
        }
   }       
}

        
