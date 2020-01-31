using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ben Martinson 2020 VGD-AM
namespace TheCoolCRPG
{
    //egg
    class Program
    {
        private static Player _player = new Player();
        static void Main(string[] args)
        {
            GameEngine.initialize();
            _player.Name = "Fred the Fearless";

            while (true)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    continue;
                }
                string cleanedInput = userInput.ToLower();

                if(cleanedInput == "exit")
                {
                    break;
                }
                ParseInput(cleanedInput);

            } //while
            
            Console.ReadLine();
        }//Main

        public static void ParseInput(string input)
        {
            if (input.Contains("help"))
            {
                Console.WriteLine("Help is coming later... stay tuned.");

            } else if (input.Contains("look")) {
                //DisplayCurrentLocation
            } else
            {
                Console.WriteLine("Ich verstehe nicht");
            }
        }
    }
}
