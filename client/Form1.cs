using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace client
{
    public partial class Form1 : Form
    {
        Thread receiver;
        UdpClient udp;
        Random random;
        IPEndPoint server;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            udp = new UdpClient(32768 + random.Next() % 32768);
            receiver = new Thread(threadReceiver);
            server = null;
        }

        private void threadReceiver()
        {
            IPEndPoint endip = null;
            byte[] message;
            while (true)
            {
                try
                {
                    message = udp.Receive(ref endip);
                    if (server.Equals(endip))
                    {
                        appendChat(Encoding.Default.GetString(message) + Environment.NewLine);
                    }
                }
                catch(SocketException ex)
                {
                    appendChat(ex.Message + Environment.NewLine);
                }
            }
        }

        private void btUse_Click(object sender, EventArgs e)
        {
            string[] ipPort = txIP.Text.Split(new char[1] { ':' }, 2);
            server = new IPEndPoint(IPAddress.Parse(ipPort[0]),
                ipPort.Length > 1 ? Convert.ToInt32(ipPort[1]) : 24152);
            if (!receiver.IsAlive)
            {
                receiver.Start();
            }
        }

        private void appendChat(String text)
        {
            if (txChat.InvokeRequired)
            {
                Invoke(new Action(() => { txChat.Text += text; }));
            }
            else
            {
                txChat.Text += text;
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            byte[] message = Encoding.Default.GetBytes(txMessage.Text);
            appendChat(txMessage.Text + Environment.NewLine);
            udp.Send(message, message.Length, server);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            receiver.Abort();
            udp.Close();
        }
    }
}
