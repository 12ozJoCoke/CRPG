using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoolCRPG
{
    public class LootItem
    {
        public Item Details;
        public int DropPercentage;
        public bool IsDefaultItem;

        public LootItem(Item details, int dropPrecentage, bool isDefaultItem)
        {
            Details = details;
            DropPercentage = dropPrecentage;
            IsDefaultItem = isDefaultItem;
        }
    }
}
