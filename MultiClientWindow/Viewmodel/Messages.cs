using MultiClientClient.Model;
using MultiClientClient.Viewmodel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MultiClientWindow.Viewmodel
{
    class Messages
    {

        public void login(string strmsg, Dispatcher dispatcher, Form1 f)
        {
            strmsg = strmsg.Substring(strmsg.IndexOf('?') + 1, strmsg.IndexOf("?", strmsg.IndexOf('?') + 1) - 4);
            if (strmsg.Equals("TRUE"))
            {
                dispatcher.Invoke(() =>
                {
                    f.textBox1.Text += "You Are Logged in. \r\n You are chatting at: Main";
                });
            }
            else if (strmsg.Equals("WRONG"))
            {

                dispatcher.Invoke(() =>
                {
                    f.textBox1.Text += ("Wrong nickname or password.");
                    f.button1.Enabled = true;
                    f.Nickname.Enabled = true;
                });
            }
        }
        public void UserList(string strmsg, Dispatcher dispatcher, Form1 f)
        {
            strmsg = strmsg.Substring(strmsg.IndexOf('?') + 1, strmsg.IndexOf("?", strmsg.IndexOf('?') + 1) - 4);
            Task.Factory.StartNew(() =>
            {
                string[] room = strmsg.Split('~');
                dispatcher.Invoke(() =>
                {
                    int number = 1;
                    f.textBox2.Clear();
                    foreach (var item in room)
                    {
                        if (item != "")
                            f.textBox2.Text += number + ". " + item + "\r\n";
                        number++;
                    }
                });
            });
        }
        public void RoomList(string strmsg, Dispatcher dispatcher, Form1 f)
        {
            Task.Factory.StartNew(() =>
            {
                strmsg = strmsg.Substring(strmsg.IndexOf('?') + 1, strmsg.IndexOf("?", strmsg.IndexOf('?') + 1) - 4);
                Receiving.json = JsonConvert.DeserializeObject<Dictionary<string, bool>>(strmsg);

                dispatcher.Invoke(() =>
                {
                    f.listBox1.Items.Clear();
                    foreach (KeyValuePair<string, bool> e in Receiving.json)
                    {
                        f.listBox1.Items.Add(e.Key);
                    }
                });
            });
        }
        public void Message(string strmsg, Dispatcher dispatcher, Form1 f)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    strmsg = strmsg.Substring(strmsg.IndexOf('?', 0, 4) + 1, strmsg.IndexOf("?END") - 4);
                    var rec = JsonConvert.DeserializeObject<Msg_Info>(strmsg);
                    dispatcher.Invoke(() =>
                    {
                        f.textBox1.Text += ($"\r\n{rec.MsgTime} {rec.From}:  {rec.Message} ");
                    });
                }
                catch (FormatException e) { }
                catch (JsonReaderException) { }
                catch (JsonSerializationException) { }
            });
        }
        public void ChangeRoom(string strmsg, Dispatcher dispatcher, Form1 f)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    strmsg = strmsg.Substring(strmsg.IndexOf('?', 0, 4) + 1, strmsg.IndexOf("?END") - 4);
                    dispatcher.Invoke(() =>
                    {
                        f.textBox1.Text += ($"\r\n {strmsg}");
                    });
                }
                catch (FormatException e) { }
                catch (JsonReaderException) { }
                catch (JsonSerializationException) { }
            });
        }
    }
}
