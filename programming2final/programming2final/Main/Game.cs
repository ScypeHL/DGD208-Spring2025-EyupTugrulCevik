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
        
        public static Write wr = new Write();
        public static Render Render = new Render();
        public static GetInput GetInput = new GetInput();

        public static int CurrentAnimal;
        public static Dictionary<int, AnimaStruct> AnimalSelected;
        public static Dictionary<int, float[]> AnimalStatus = new Dictionary<int, float[]>();

        public static List<ItemStruct> Inventory = new List<ItemStruct>();
        public Game()
        {
            
            // render.logicFlow(true);
        }
    }
}
