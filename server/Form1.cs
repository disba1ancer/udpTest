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

namespace server
{
    public partial class Form1 : Form
    {
        Thread receiver;
        UdpClient udp;
        IPEndPoint client;

        public Form1()
        {
            InitializeComponent();
            receiver = new Thread(threadReceiver);
            udp = new UdpClient(25565);
            client = null;
            receiver.Start();
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
                    if (client == null)
                    {
                        client = endip;
                        appendChat(client.ToString() + Environment.NewLine);
                    }
                    if (client.Equals(endip))
                    {
                        appendChat(Encoding.Default.GetString(message) + Environment.NewLine);
                    }
                }
                catch (SocketException ex)
                {
                    appendChat(ex.Message + Environment.NewLine);
                }
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
            if (client != null)
            {
                byte[] message = Encoding.Default.GetBytes(txMessage.Text);
                appendChat(txMessage.Text + Environment.NewLine);
                udp.Send(message, message.Length, client);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            receiver.Abort();
            udp.Close();
        }
    }
}
