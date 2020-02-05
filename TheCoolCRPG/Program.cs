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
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));

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
                Console.WriteLine("cool tip 1) no \n");

            } else if (input.Contains("look"))
            {
                DisplayCurrentLocation();

            } else if (input.Contains("north"))
            {
                _player.MoveNorth();

            }else if (input.Contains("south"))
            {
                _player.MoveSouth();

            }else if (input.Contains("west"))
            {
                _player.MoveWest();

            }else if (input.Contains("east"))
            {
                _player.MoveEast();

            }

            else
            {
                Console.WriteLine("Ich verstehe nicht");

            }
        }
        private static void DisplayCurrentLocation()
        {
            Console.WriteLine("You are at: {0}", _player.CurrentLocation.Name);
            if (_player.CurrentLocation.Description != "")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description); 
            }
        }
    }
}
