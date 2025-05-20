using programming2final;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Render : Game 
    {
        private int flowDelay = 200;
        private PlayerCommand playerCommand = new PlayerCommand();

        public Render()
        {

        }

        public void print()
        {
            bool SWITCH = true;
            while (SWITCH)
            {
                if (animalSelected.TryGetValue(CurrentAnimal, out AnimaStruct _animal)) { }
                if (animalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

                Console.Clear();
                Console.Write($"{_animal.Colour} {_animal.Type} Hunger:{animalStat[0]}| Sleep:{animalStat[1]}| Fun:{animalStat[2]}\n");
                Console.WriteLine("");
                Console.WriteLine("Press F to feed the animal");
                Console.WriteLine("Press M to switch to another animal");
                
                
                Thread.Sleep(flowDelay);
                if (Console.ReadKey().Key == ConsoleKey.F) { playerCommand.feed(20); }
                if (Console.ReadKey().Key == ConsoleKey.M) { playerCommand.move(); }

            }
        }
    }
}
