using NetCoreServer;

namespace Client
{
    class MainApp
    {
        public static void Main()
        {
            Console.WriteLine("       ______             _            ");
            Console.WriteLine("      |  ____|           (_)           ");
            Console.WriteLine(" __  _| |__   _ __   __ _ _ _ __   ___ ");
            Console.WriteLine(" \\ \\/ /  __| | '_ \\ / _` | | '_ \\ / _ \\");
            Console.WriteLine("  >  <| |____| | | | (_| | | | | |  __/");
            Console.WriteLine(" /_/\\_\\______|_| |_|\\__, |_|_| |_|\\___|");
            Console.WriteLine("                     __/ |  ");
            Console.WriteLine("                    |___/        v0.0.1 [DEV BUILD]");
            Console.WriteLine("-------------------------------------------------------------------------");

            Console.Write("\nWelcome to xEngine Console!, start typing your commands in here:");

            // Perform text input
            for (; ; )
            {
                Console.Write("\n>  ");
                string line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                switch (line)
                {
                    case "connect": Networking.ConnectToServer("127.0.0.1", 1111); break;
                    default: Console.WriteLine($"command {line} cannot be found"); break;
                }



            }

        }
    }
}