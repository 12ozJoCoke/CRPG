﻿using System;
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
        private static Player _player = new Player("Fred the Fearless", 10, 10, 20, 0, 1, 0);
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
                int helpvalue = RandomNumberGenerator.NumberBetween(1, 10);
                if (helpvalue == 1)
                {
                    Console.WriteLine("Cool Tip 1: No");
                }
                if (helpvalue == 2)
                {
                    Console.WriteLine("Cool Tip 2: I don't wanna");
                }
                if (helpvalue == 3)
                {
                    Console.WriteLine("Cool Tip 3: Help is for the weak");
                }
                if (helpvalue == 4)
                {
                    Console.WriteLine("Cool Tip 4: See The Gospel According To Zork for More Information");
                }
                if (helpvalue == 5)
                {
                    Console.WriteLine("Cool Tip 5: AAAAAAAAAAAAAAAAAAAAAAA");
                }
                if (helpvalue == 6)
                {
                    Console.WriteLine("Cool Tip 6: You're playing the Cool CRPG! How neat!");
                }
                if (helpvalue == 7)
                {
                    Console.WriteLine("Cool Tip 7: This isn't Jim's Bjork. Don't make that mistake.");
                }
                if (helpvalue == 8)
                {
                    Console.WriteLine("Cool Tip 8: I hope this is helpful.");
                }
                if (helpvalue == 9)
                {
                    Console.WriteLine("Cool Tip 9: Heehoo Peanut");
                }
                if (helpvalue == 10)
                {
                    Console.WriteLine("Cool Tip 10: ");
                }

            } else if (input.Contains("look"))
            {
                DisplayCurrentLocation();

            } else if (input.Contains("north") || input == "n")
            {
                _player.MoveNorth();
                if (_player.CurrentLocation.MonsterLivingHere != null)
                {
                    Console.WriteLine("There is a monster here");
                    _player.CheckForMonsterDeath(_player.PassiveAttackStat);

                }else
                {
                    Console.WriteLine("There is not a monster here");
                }
            }else if (input.Contains("south") || input == "s")
            {
                _player.MoveSouth();
                if (_player.CurrentLocation.MonsterLivingHere != null)
                {
                    Console.WriteLine("There is a monster here");
                    _player.CheckForMonsterDeath(_player.PassiveAttackStat);
                }
                else
                {
                    Console.WriteLine("There is not a monster here");
                }
            }
            else if (input.Contains("west") || input == "w")
            {
                _player.MoveWest();
                if (_player.CurrentLocation.MonsterLivingHere != null)
                {
                    Console.WriteLine("There is a monster here");
                    _player.CheckForMonsterDeath(_player.PassiveAttackStat);
                }
                else
                {
                    Console.WriteLine("There is not a monster here");
                }
            }
            else if (input.Contains("east") || input == "e")
            {
                _player.MoveEast();
                if (_player.CurrentLocation.MonsterLivingHere != null)
                {
                    Console.WriteLine("There is a monster here");
                    _player.CheckForMonsterDeath(_player.PassiveAttackStat);
                }
                else
                {
                    Console.WriteLine("There is not a monster here");
                }
            }
            else if (input.Contains("take the derivative"))
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
            }else if (input == "quests")
            {
                if (_player.Quests.Count == 0)
                {
                    Console.WriteLine("No Quests Available");
                }else
                {
                    foreach (PlayerQuest playerQuests in _player.Quests)
                    {
                        Console.WriteLine("{0}: {1}", playerQuests.Details.Name, playerQuests.IsCompleted ? "Completed" : "Incomplete");
                    }
                }
            }else if (input == "hey it works")
            {
                Console.WriteLine("For now.");
            }else if (input == "it broke")
            {
                Console.WriteLine("You shouldn't have said anything about it working. I warned you.");
            }else if (input.Contains("attack"))
            {
                if (_player.CurrentLocation.MonsterLivingHere == null)
                {
                    Console.WriteLine("No monsters here dingdong");
                }else
                {
                    if (_player.CurrentWeapon == null)
                    {
                        Console.WriteLine("You fool, you have no weapon, you are sure to die.");
                    }else
                    {
                        if (_player.CurrentWeapon.Name == "Hot Dog")
                        {
                            _player.PassiveAttackStat = 5;
                            Console.WriteLine("From now on, you will passively do 5 damage to any enemy you meet!");
                        }
                        _player.UseWeapon(_player.CurrentWeapon);
                    }
                }
            }else if (input.StartsWith("equip "))
            {
                _player.UpdateWeapons();
                string inputWeaponName = input.Substring(6).Trim();
                if (string.IsNullOrEmpty(inputWeaponName))
                {
                    Console.WriteLine("That's not a real weapon, for all I know it may be rather phallic.");

                } else
                {
                    Weapon weaponToEquip = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == inputWeaponName
                    || x.NamePlural.ToLower() == inputWeaponName);

                    if (weaponToEquip == null)
                    {
                        Console.WriteLine("You have no weapons called {0}, You are truly screwed now.", inputWeaponName);
                    }
                    else
                    {
                        if (input.Substring(6).Trim() == "hot dog")
                        {
                            _player.CurrentWeapon = weaponToEquip;
                            Console.WriteLine("You equip your {0}, also please don't take that out of context.", _player.CurrentWeapon.Name);
                        }
                        else
                        {
                            _player.CurrentWeapon = weaponToEquip;
                            Console.WriteLine("You equip your {0}", _player.CurrentWeapon.Name);
                        }
                    }
                }
            }else if (input == "weapons")
            {
                _player.UpdateWeapons();
                Console.WriteLine("List of weapons (because you couldn't remember the weapons you had): ");
                foreach (Weapon w in _player.Weapons)
                {
                    Console.WriteLine("\n{0}", w.Name);
                }
            }else if (input == "give me hot dog")
            {
                InventoryItem hotdog = new InventoryItem(World.ItemByID(World.ITEM_ID_HOT_DOG), 1);
                _player.Inventory.Add(hotdog);
                Console.WriteLine("You have found a hot dog, topped with Ketchup, Mustard, and diced Onions, and all in a Whole Wheat bun. This is a weapon.");
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
