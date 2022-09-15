using NetCoreServer;
using System.Diagnostics;

namespace Client
{
    class MainApp
    {
        public static bool bHasInitialized = false;
        public static float flOldTime;
        public static float flNewTime;
        public static float flFrameTime = 0.0f;

        // Engine Initialization
        public static void xEngine_Initialize()
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

            Renderer.Initialize();
        }

        // Engine Update, returning true to this function will stop the engine
        public static bool xEngine_Update()
        {
            flNewTime = DateTime.Now.Millisecond;
            /*
            // Console stuff, need to be moved somewhere else
            if (!Networking.bIsConnected)
            {
                Console.Write("\n>  ");
                string line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                    return true;

                switch (line)
                {
                    case "connect": Networking.ConnectToServer("127.0.0.1", 1111); break;
                    default: Console.WriteLine($"command {line} cannot be found"); break;
                }
            }
            */

            Networking.NetworkUpdate();
            Renderer.Draw();

            flFrameTime = flNewTime - flOldTime;
            flOldTime = flNewTime;
            return false;
        }

        // Engine Shutdown
        public static void xEngine_Shutdown()
        {
            
        }

        // Main Application Function
        public static void Main()
        {
            // Engine Initialization
            if (!bHasInitialized) 
                xEngine_Initialize();

            // forever loop, getting out from this loop meant exiting the application
            while (!xEngine_Update()) { }
      
            // Engine closing
            xEngine_Shutdown();

        }
    }
}