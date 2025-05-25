using programming2final;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Render : Game 
    {
        private int flowDelay = 200;
        private float decreaseRate = 1f;
        private int counter = 0;
        
        private bool GPressed = false;
        private int numberPressed;
        private PlayerCommand playerCommand = new PlayerCommand();

        public Render()
        {

        }

        async public Task Flow()
        {
            IsProgramRunning = true;
            var updateScreen = Task.Run(mainFlow);

            CheckInput();
            await updateScreen;
        }
        
        private void CheckInput()
        {
            numberPressed = 0;
            while (IsProgramRunning)
            {
                if (Console.KeyAvailable) // In this part I got some help from "claude.ai"
                {
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;

                    if (keyPressed == ConsoleKey.F && playerCommand.isFeeding == false) { playerCommand.Feed(20, 5000); }
                    if (keyPressed == ConsoleKey.V) { playerCommand.move(); }
                    if (keyPressed == ConsoleKey.G) { GPressed = true; }
                    if (keyPressed == ConsoleKey.E && playerCommand.isBusy == false) { }
                    
                    if (keyPressed == ConsoleKey.D1) { numberPressed = 1; }
                    if (keyPressed == ConsoleKey.D2) { numberPressed = 2; }
                    if (keyPressed == ConsoleKey.D3) { numberPressed = 3; }
                    if (keyPressed == ConsoleKey.D4) { numberPressed = 4; }
                    if (keyPressed == ConsoleKey.D5) { numberPressed = 5; }
                    if (keyPressed == ConsoleKey.D6) { numberPressed = 6; }
                    if (keyPressed == ConsoleKey.D7) { numberPressed = 7; }
                    if (keyPressed == ConsoleKey.D8) { numberPressed = 8; }
                    if (keyPressed == ConsoleKey.D9) { numberPressed = 9; }
                }
            }
           
        }

        async private Task mainFlow()
        {
            while (IsProgramRunning)
            {
                if (AnimalSelected.TryGetValue(CurrentAnimal, out AnimaStruct _animal)) { }
                if (AnimalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

                Console.Clear();
                Console.Write($"{_animal.Colour} {_animal.Type} Hunger:{(int)animalStat[0]}| Sleep:{(int)animalStat[1]}| Fun:{(int)animalStat[2]}\n");

                PrintInputs();

                if (playerCommand.isFeeding == true) { Console.WriteLine($"You are currently feeding an animal"); }

                PrintInventory();
                ApplyStatus();
                await Task.Delay(flowDelay);
            }

        }

        async private void PrintInventory()
        {
            if (GPressed)
            {
                for (int i = 0; i < Inventory.Count; i = i + 1)
                {
                    Console.WriteLine($"{i + 1}) {Inventory[i].Name}");
                }
                while (counter < 50)
                {
                    if (numberPressed != 0)
                    {
                        counter = 0;
                        playerCommand.InventoryController(numberPressed);
                        GPressed = false;
                    }
                    counter = counter + 1;
                    await Task.Delay(flowDelay);
                }
                if (numberPressed != 0) { playerCommand.InventoryController(numberPressed); GPressed = false; counter = 0; }
                else { GPressed = false; counter = 0; }
            }
        }

        private void PrintInputs()
        {
            Console.WriteLine("");
            Console.WriteLine("Press F to feed the animal");
            Console.WriteLine("Press G to see inventory");
            Console.WriteLine("Press E to select behaviour");
            Console.WriteLine("Press V to switch to another animal");
            Console.WriteLine("");
        }
        
        private void ApplyStatus()
        {
            for (int i = 0; i < 3; i = i + 1)
            {
                if (AnimalStatus.TryGetValue(1, out float[] stats1)) { stats1[i] = stats1[i] - decreaseRate; }
                if (AnimalStatus.TryGetValue(2, out float[] stats2)) { stats2[i] = stats2[i] - decreaseRate; }
                if (AnimalStatus.TryGetValue(3, out float[] stats3)) { stats3[i] = stats3[i] - decreaseRate; }
            }
            Thread.Sleep(flowDelay);
        }
    }
}
