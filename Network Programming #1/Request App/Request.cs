using System.Net;
using System.Net.Sockets;
using System.Text;

int port = 8080;
string adress = "127.0.0.1";

try
{
    TcpClient client = new(adress, port);
    Console.WriteLine("Client Connected !");

    NetworkStream stream = client.GetStream();

    string request = "I Have An Question";
    byte[]bytesWrite = Encoding.ASCII.GetBytes(request);
    stream.Write(bytesWrite, 0, bytesWrite.Length);
    stream.Flush();
    Console.WriteLine("Client Sent Request");

    byte[]bytesRead = new byte[256];
    int length = stream.Read(bytesRead, 0, bytesRead.Length);
    string answer = Encoding.ASCII.GetString(bytesRead, 0, length);
    Console.WriteLine(answer);

    client.Close();
    Console.WriteLine("Client Disconnected !");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}