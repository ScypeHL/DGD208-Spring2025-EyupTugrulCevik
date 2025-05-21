using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    struct ItemStruct
    {
        public string Name;
        public string Description;
        public int HungerIncrease;
        public int SleepIncrease;
        public int FunIncrease;
        public string CanBeUsedOn;

        public ItemStruct(string name, string description, int hungerIncrease, int sleepIncrease, int funIncrease, string canBeUsedOn)
        {
            Name = name;
            Description = description;
            HungerIncrease = hungerIncrease;
            SleepIncrease = sleepIncrease;
            FunIncrease = funIncrease;
            CanBeUsedOn = canBeUsedOn;
        }
    }
}
