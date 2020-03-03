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
        private static Player _player = new Player("Fred the Fearless", 10, 10, 20, 0, 1);
        static void Main(string[] args)
        {
            GameEngine.initialize();
            _player.Name = "Fred the Fearless";
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            //Console.WriteLine(RandomNumberGenerator.NumberBetween(1, 10));
            InventoryItem sword = new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1);
            InventoryItem club = new InventoryItem(World.ItemByID(World.ITEM_ID_CLUB), 1);
            _player.Inventory.Add(sword);
            //_player.Inventory.Add(club);


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

            } else if (input.Contains("north") || input == "n")
            {
                _player.MoveNorth();

            }else if (input.Contains("south") || input == "s")
            {
                _player.MoveSouth();

            }else if (input.Contains("west") || input == "w")
            {
                _player.MoveWest();

            }else if (input.Contains("east") || input == "e")
            {
                _player.MoveEast();

            }else if (input.Contains("take the derivative"))
            {
                GameEngine.DebugInfo();
            }else if (input == "inventory" || input == "i")
            {
                foreach (InventoryItem invItem in _player.Inventory)
                {
                    Console.WriteLine("\nCurrent Inventory: ");
                    Console.WriteLine("\t{0} : {1}", invItem.Details.Name, invItem.Quantity);
                }
            }else if (input == "stats")
            {
                Console.WriteLine("\nStats for {0}", _player.Name);
                Console.WriteLine("\tCurrent HP: \t{0}", _player.CurrentHitPoints);
                Console.WriteLine("\tMaximum HP: \t{0}", _player.MaxHitPoints);
                Console.WriteLine("\tXP:\t\t{0}", _player.ExperiencePoints);
                Console.WriteLine("\tLevel:\t\t{0}", _player.Level);
                Console.WriteLine("\tGold:\t\t{0}", _player.Gold);
            }

            else
            {
                Console.WriteLine("Ich verstehe nicht");

            }
        }
        public static void DisplayCurrentLocation()
        {
            Console.WriteLine("\nYou are at: {0}", _player.CurrentLocation.Name);
            if (_player.CurrentLocation.Description != "")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description); 
            }
        }
    }
}
