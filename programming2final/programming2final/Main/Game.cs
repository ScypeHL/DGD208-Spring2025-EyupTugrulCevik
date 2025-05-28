using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Game
    {
        public static bool IsProgramRunning = true;
        
        public static Render Render = new Render();
        public static Printer Printer = new Printer();

        public static int CurrentAnimal;
        public static float DifficultyMultiplier = 1f;

        public static Dictionary<int, AnimaStruct> AnimalSelected;
        public static Dictionary<int, float[]> AnimalStatus = new Dictionary<int, float[]>();

        public static List<ItemStruct> Inventory = new List<ItemStruct>();

        public static int FlowDelay = 200;
        public Game()
        {
            
            // render.logicFlow(true);
        }
    }
}
