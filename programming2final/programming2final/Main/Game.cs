﻿using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Game
    {
        public static bool isProgramRunning = true;
        
        public static Write wr = new Write();
        public static Render render = new Render();

        public static int CurrentAnimal;
        public static Dictionary<int, AnimaStruct> animalSelected;
        public static Dictionary<int, float[]> animalStatus = new Dictionary<int, float[]>();

        public static List<ItemStruct> Inventory = new List<ItemStruct>();
        public Game()
        {
            
            // render.logicFlow(true);
        }
    }
}
