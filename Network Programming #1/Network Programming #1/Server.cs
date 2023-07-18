using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

int port = 8080;
IPAddress adress = IPAddress.Parse("127.0.0.1");

try
{
    TcpListener serverSocket = new(adress, port);
    serverSocket.Start();
    Console.WriteLine("Server Started. Waiting For A Request . . .");


    while (true)
    {
        TcpClient clientSocket = serverSocket.AcceptTcpClient();
        NetworkStream stream = clientSocket.GetStream();

        byte[] bytes = new byte[256];
        int length = stream.Read(bytes, 0, bytes.Length);
        string request = Encoding.UTF8.GetString(bytes, 0, length);
        Console.WriteLine("Got Request : " + request);

        string message = "Length Of Your Message : " + request.Length;
        bytes = Encoding.ASCII.GetBytes(message);
        stream.Write(bytes, 0, bytes.Length);
        stream.Flush();

        Console.WriteLine("The Sent Message İs : " + message);
        clientSocket.Close();
    }

    serverSocket.Stop();
    Console.WriteLine("Server Stopped .");
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}