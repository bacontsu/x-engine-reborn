using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TcpClient = NetCoreServer.TcpClient;

namespace Client
{
    class ChatClient : TcpClient
    {
        public ChatClient(string address, int port) : base(address, port) { }

        public void DisconnectAndStop()
        {
            _stop = true;
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        protected override void OnConnected()
        {
            Console.WriteLine($"Connected With Server! ID: {Id}");
        }

        protected override void OnDisconnected()
        {
            Console.WriteLine($"Dropped from server");
            /*
            // Wait for a while...
            Thread.Sleep(1000);

            // Try to connect again
            if (!_stop)
                ConnectAsync();
            */
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            //Console.WriteLine(Encoding.UTF8.GetString(buffer, (int)offset, (int)size));
            Networking.ParseMessage(Encoding.UTF8.GetString(buffer, (int)offset, (int)size));
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"[ERROR]: {error}");
        }

        private bool _stop;
    }

    class Networking
    {
        public static ChatClient client;
        public static bool bIsConnected;

        public static void ConnectToServer(string address, int port)
        {
            Console.WriteLine($"TCP server address: {address}");
            Console.WriteLine($"TCP server port: {port}");

            Console.WriteLine();

            // Create a new TCP chat client
            client = new ChatClient(address, port);

            // Connect the client
            Console.Write("Client connecting...");
            bIsConnected = client.ConnectAsync();
            if (bIsConnected)
            {
                Console.WriteLine("Done!");
                Console.WriteLine("Press Enter to stop the client or '!' to reconnect the client...");
            }
            else
            Console.WriteLine("Unable to connect to server!");
        }

        public static void DisconnectFromServer()
        {
            // Disconnect the client
            Console.Write("Client disconnecting...");
            client.DisconnectAndStop();
            Console.WriteLine("Done!");
        }

        public static void NetworkUpdate()
        {
            if (!bIsConnected) return;

            string line = Console.ReadLine();

            if (string.IsNullOrEmpty(line))
                DisconnectFromServer();

            // Disconnect the client
            if (line == "!")
            {
                Console.Write("Client disconnecting...");
                client.DisconnectAsync();
                Console.WriteLine("Done!");
            }
            else if (line == "soundcheck")
            {
                Console.WriteLine("Playing Sound!");
                AudioManager.PlayStereoSound("test.mp3", 1.0f);
            }

            // Send the entered text to the chat server
            client.SendAsync($"[{client.Id}] " + line);
        }

        // Parse Information sent from the server in here, I'm not sure the best way to design it but hey. it works
        public static void ParseMessage(string message)
        {
            // if it starts with "[" that means its a message, do not parse this
            if (message.StartsWith("[")) 
            {
                Console.WriteLine(message);
                return;
            }

            // Parse commands in here
            if(message.StartsWith("playsound"))
            {
                // unfinished stuff....
            }
        }
    }
}