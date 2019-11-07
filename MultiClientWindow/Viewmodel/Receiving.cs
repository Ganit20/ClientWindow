using MultiClientClient.Model;
using MultiClientWindow;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace MultiClientClient.Viewmodel
{
    public class Receiving
    {
        ObservableCollection<String> MSG = new ObservableCollection<string>();

        public void Reading(object obj,Form1 form,Dispatcher dispatcher)
        {
           
              NetworkStream stream = (NetworkStream)obj;
            while (true)
            {
                try
                {

                    String response = String.Empty;
                    Byte[] ByteLength = new byte[4];
                    Int32 bytes = stream.Read(ByteLength, 0, 4);

                    if (stream.DataAvailable)
                    {
                        String v = System.Text.Encoding.ASCII.GetString(ByteLength, 0, 4);
                        String d = v.Substring(0, v.IndexOf('?', 0, 4));

                        try
                        {
                            int bl = int.Parse(d);

                            Byte[] data = new Byte[bl];
                            Int32 msg = stream.Read(data, 0, bl);

                            response = System.Text.Encoding.ASCII.GetString(data, 0, bl);
                            var rec = JsonConvert.DeserializeObject<Msg_Info>(response);


                            dispatcher.Invoke(() => { //form.textBox1.Text += ($"{rec.MsgTime} {rec.From}  {rec.Message} \n\r");
                               
                                form.listView3.Items.Add($"{rec.MsgTime} {rec.From}  {rec.Message} \n\r");
                              
                            });



                        }
                        //Task.Factory.StartNew(() =>
                        //{

                        //});
                        catch (FormatException e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.Write("Connection Error");

                }
            }
        }

     
        }
 

    }

