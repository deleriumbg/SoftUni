using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Web_Server
{
    class Program
    {
        private const string LocalhostIpAddress = "127.0.0.1";
        private const int Port = 1300;
        private const int BufferSize = 1024;

        static void Main(string[] args)
        {
            IPAddress address = IPAddress.Parse(LocalhostIpAddress);
            TcpListener listener = new TcpListener(address, Port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at {LocalhostIpAddress}:{Port}");

            Task task = Task.Run(() => ConnectWithTcpClient(listener));
            task.Wait();
        }

        private static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected.");

                byte[] buffer = new byte[BufferSize];
                client.GetStream().Read(buffer, 0, buffer.Length);

                var message = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(message);

                byte[] data = Encoding.ASCII.GetBytes("Hello from server!");
                client.GetStream().Write(data, 0, data.Length);

                Console.WriteLine("Closing connection.");
                client.GetStream().Dispose();
            }
        }
    }
}
