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
        public void Reading(object obj, Form1 form, Dispatcher dispatcher)
        {
            System.Timers.Timer timer = new System.Timers.Timer(10000);
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
                            if (vstrmsg.Equals("USE"))
                            {
                                strmsg = strmsg.Substring(strmsg.IndexOf('?') + 1, strmsg.IndexOf("?", strmsg.IndexOf('?') + 1) - 4);
                                Task.Factory.StartNew(() =>
                                {
                                    string[] room = strmsg.Split('~');
                                    dispatcher.Invoke(() =>
                                    {
                                        int number = 1;
                                        form.textBox2.Clear();
                                        foreach (var item in room)
                                        {
                                            if (item != "")
                                                form.textBox2.Text += number + ". " + item + "\r\n";
                                            number++;
                                        }
                                    });
                                });
                            }
                            else if (vstrmsg.Equals("RCC"))
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    strmsg = strmsg.Substring(strmsg.IndexOf('?') + 1, strmsg.IndexOf("?", strmsg.IndexOf('?') + 1) - 4);
                                    json = JsonConvert.DeserializeObject<Dictionary<string, bool>>(strmsg);

                                    dispatcher.Invoke(() =>
                                    {
                                        form.listBox1.Items.Clear();
                                        foreach (KeyValuePair<string, bool> e in json)
                                        {
                                            form.listBox1.Items.Add(e.Key);
                                        }
                                    });
                                });
                            }
                            else if (vstrmsg.Equals("MSG"))
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    try
                                    {
                                        strmsg = strmsg.Substring(strmsg.IndexOf('?', 0, 4) + 1, strmsg.IndexOf("?END") - 4);
                                        var rec = JsonConvert.DeserializeObject<Msg_Info>(strmsg);
                                        dispatcher.Invoke(() =>
                                        {
                                            form.textBox1.Text += ($"\r\n{rec.MsgTime} {rec.From}  {rec.Message} ");
                                        });
                                    }
                                    catch (FormatException e) { }
                                    catch (JsonReaderException) { }
                                    catch (JsonSerializationException) { }
                                });
                            }
                            else if (vstrmsg.Equals("SSG"))
                            {
                                Task.Factory.StartNew(() =>
                                {
                                    try
                                    {
                                        strmsg = strmsg.Substring(strmsg.IndexOf('?', 0, 4) + 1, strmsg.IndexOf("?END") - 4);
                                        dispatcher.Invoke(() =>
                                        {
                                            form.textBox1.Text += ($"\r\n {strmsg}");
                                        });
                                    }
                                    catch (FormatException e) { }
                                    catch (JsonReaderException) { }
                                    catch (JsonSerializationException) { }
                                });
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
        void CheckConnection(Object src, ElapsedEventArgs e)    
        {
            if(!Login.c.Connected)
            {
                WindowPopup popup = new WindowPopup();
                popup.ShowDialog();
                Application.Exit();
            }
        }
   }       
}

        
