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
        private float decreaseRate = 0.05f;

        private bool GPressed = false;
        private PlayerCommand playerCommand = new PlayerCommand();
        private ConsoleKey _keyPressed;

        public Render()
        {

        }

        async public Task flow()
        {
            isProgramRunning = true;
            var updateScreen = Task.Run(print);
            
            applyStatus();
            checkInput();
            await updateScreen;
        }
        
        private void checkInput()
        {
            while (isProgramRunning)
            {
                if (Console.KeyAvailable) // In this part I got some help from "claude.ai"
                {
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;

                    if (keyPressed == ConsoleKey.F && playerCommand.itemUsed == false) { playerCommand.feed(20, 2000); }
                    if (keyPressed == ConsoleKey.V) { playerCommand.move(); }
                    if (keyPressed == ConsoleKey.G) { GPressed = true; } else { GPressed = false; }
                }
                Task.Delay(1);
            }
           
        }

        async private Task print()
        {
            while (isProgramRunning)
            {
                if (animalSelected.TryGetValue(CurrentAnimal, out AnimaStruct _animal)) { }
                if (animalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

                Console.Clear();
                Console.Write($"{_animal.Colour} {_animal.Type} Hunger:{(int)animalStat[0]}| Sleep:{(int)animalStat[1]}| Fun:{(int)animalStat[2]}\n");
                Console.WriteLine("");
                Console.WriteLine("Press F to feed the animal");
                Console.WriteLine("Press G to see inventory");
                Console.WriteLine("Press E to select behaviour");
                Console.WriteLine("Press V to switch to another animal");
                Console.WriteLine("");

                if (GPressed)
                {
                    for (int i = 0; i < Inventory.Count; i = i + 1)
                    {
                        Console.WriteLine(Inventory[i].Name);
                    }
                }
                if (playerCommand.itemUsed == true) { Console.WriteLine("An Item is currently in use"); }
                await Task.Delay(flowDelay);
            }

        }

        private void applyStatus()
        {
            for (int i = 0; i < 3; i = i + 1)
            {
                if (animalStatus.TryGetValue(1, out float[] stats1)) { stats1[i] = stats1[i] - 0.1f; }
                if (animalStatus.TryGetValue(2, out float[] stats2)) { stats2[i] = stats2[i] - 0.1f; }
                if (animalStatus.TryGetValue(3, out float[] stats3)) { stats3[i] = stats3[i] - 0.1f; }
            }
            Thread.Sleep(flowDelay);
        }
    }
}
