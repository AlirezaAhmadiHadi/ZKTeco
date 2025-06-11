using System;

namespace ZKTecoUserImage
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "192.168.70.39";
            int port = 4370;

            ZKManager zkManager = new ZKManager(ip, port);

            if (zkManager.Connect())
            {
                Console.WriteLine("Connected to device!");
                zkManager.RegisterEvents();

                Console.WriteLine("Listening for AttTransactions. Press Enter to exit...");
                Console.ReadLine();

                zkManager.Disconnect();
            }
            else
            {
                Console.WriteLine("Failed to connect to device.");
            }
        }
    }
}