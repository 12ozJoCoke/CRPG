using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoolCRPG
{
    public class World
    {
        public static readonly string WorldName = "The Cool CRPG";
        public static readonly List<Location> Locations = new List<Location>();

        //Strat Providing IDs for Locations
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_FOREST_PATH = 2;
        public const int LOCATION_ID_LAB = 3;

        static World()
        {
            PopulateLocations();
        }

        private static void PopulateLocations()
        {
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your House is Very Clean");
            Location forestPath = new Location(LOCATION_ID_FOREST_PATH, "Forest Path", "A wooded path with lots of plants and trees.");
            Location lab = new Location(LOCATION_ID_LAB, "Lab", "A strange lab with lots of mysterious machines");

            //Link the Locations together

            home.LocationToNorth = forestPath;
            forestPath.LocationToEast = lab;
            lab.LocationToWest = forestPath;
            forestPath.LocationToSouth = home;

            //Create our list of locations
            Locations.Add(home);
            Locations.Add(forestPath);
            Locations.Add(lab);
            
        }

        public static Location LocationByID(int id)
        {
            foreach (Location loc in Locations)
            {
                if(loc.ID == id)
                {
                    return loc;
                }
            }
            return null;
        }

        public static void ListLocations()
        {
            Console.WriteLine("These are the locations in the world");
            foreach (Location loc in Locations)
            {
                Console.WriteLine("\t{0}", loc.Name);
            }
        }
    }
}
