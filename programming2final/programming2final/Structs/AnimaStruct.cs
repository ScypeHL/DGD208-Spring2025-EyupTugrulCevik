﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programming2final
{
    internal struct AnimaStruct
    {
        public string Type;
        public string Colour;
        public int HungerScaling;
        public int SleepScaling;
        public int FunScaling;
        public float Hunger;
        public float Sleep;
        public float Fun;

        public AnimaStruct(string type, string colour, int hungerScaling, int sleepScaling, int funScaling)
        {
            Type = type;
            Colour = colour;
            HungerScaling = hungerScaling;
            SleepScaling = sleepScaling;
            FunScaling = funScaling;
            Hunger = 50;
            Sleep = 50;
            Fun = 50;
        }

    }
}
