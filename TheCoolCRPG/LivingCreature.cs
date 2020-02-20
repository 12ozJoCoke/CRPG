using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoolCRPG
{
    public class LivingCreature
    {
        public int CurrentHitPoints;
        public int MaxHitPoints;

        public LivingCreature(int currentHitPoints, int maxHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaxHitPoints = maxHitPoints;
        }

        public LivingCreature() { }
    }
}
