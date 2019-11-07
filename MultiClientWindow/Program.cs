using MultiClientClient.Model;
using MultiClientClient.Viewmodel;
using MultiClientWindow;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiClientClient
{
    //[STAThread]
    class StartServer
    {

  
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            // Connect();
        }

    }
}
