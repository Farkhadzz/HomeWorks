using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace UDPGroupChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ipAdress = "239.0.0.1";
        private const int port = 8080;
        private UdpClient udpClient;
        private Thread receiveThread;
        public MainWindow()
        {
            InitializeComponent();
            StartListening();
        }

        private void StartListening()
        {
            udpClient = new UdpClient();

            IPAddress multicastAdress = IPAddress.Parse(ipAdress);
            udpClient.JoinMulticastGroup(multicastAdress);

            IPEndPoint endPoint = new(IPAddress.Any, port);

            receiveThread = new Thread(ReceiveMessage);
        }

        private void ReceiveMessage()
        {
            try
            {
                while (true)
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                    string message = Encoding.UTF8.GetString(receivedData);

                    Dispatcher.Invoke(() =>
                    {
                        listBoxChat.Items.Add(nickTextBox.Text + " : " + message);
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, ipAdress, port);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            Send(message);
            Dispatcher.Invoke(() =>
            {
                listBoxChat.Items.Add(nickTextBox.Text + " : " + message);
            });

            txtMessage.Clear();
        }
    }
}