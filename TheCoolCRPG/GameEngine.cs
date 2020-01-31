using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoolCRPG
{
    public static class GameEngine
    {
        public static string version = "0.0.1";

        public static void initialize()
        {
            Console.WriteLine("Initializing Game Engine Version {0}", version);
            Console.WriteLine("\n\nWelcome to the World of {0}", World.WorldName);
            Console.WriteLine();
            World.ListLocations();

        }
    }
}
