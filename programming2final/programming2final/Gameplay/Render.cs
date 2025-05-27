using programming2final;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Render : Game 
    {
        private int flowDelay = 200;
        private float decreaseRate = 0.1f;
        private int counter = 0;
        
        private bool GPressed = false;
        private bool EPressed = false;
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

                    if (playerCommand.isBusy == false)
                    {
                        // if (keyPressed == ConsoleKey.F && playerCommand.isFeeding == false) { playerCommand.Feed(20, 5000); }
                        if (keyPressed == ConsoleKey.G && GPressed == false) { GPressed = true; }
                        if (keyPressed == ConsoleKey.E && EPressed == false) { EPressed = true; }
                    }                  

                    if (keyPressed == ConsoleKey.V) { playerCommand.move(); }
                    
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
                if (AnimalSelected.TryGetValue(CurrentAnimal, out AnimaStruct animal)) { }
                if (AnimalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

                Console.Clear();
                Console.Write($"{animal.Colour} {animal.Type} Hunger:{(int)animalStat[0]}| Sleep:{(int)animalStat[1]}| Fun:{(int)animalStat[2]}\n");
                // Console.WriteLine(animal.HungerScaling + " " +  animal.SleepScaling + " " + animal.FunScaling);
                // Console.WriteLine(GPressed + " " + EPressed + " " + counter);

                PrintInputs();

                if (playerCommand.isFeeding == true) { Console.WriteLine($"You are currently feeding an animal"); }
                if (playerCommand.isExecutingAnEvent == true) { Console.WriteLine($"You are currently executing an event"); }
                if (GPressed || EPressed == true) { Console.WriteLine($"Game stopped"); }
                Console.WriteLine("");

                PrintInventory();
                PrintBehaviours();
                
                GPressedCounterManager();
                EPressedCounterManager();
                
                ApplyStatus();
                await Task.Delay(flowDelay);
            }

        }

        private void PrintInventory() // not async for now // inputs are not working properly 
        {
            if (GPressed)
            {
                for (int i = 0; i < Inventory.Count; i = i + 1)
                {
                    Console.WriteLine($"{i + 1}) {Inventory[i].Name}");
                }
                while (counter < 10)
                {
                    if (numberPressed != 0)
                    {
                        counter = 0;
                        playerCommand.InventoryController(numberPressed);
                        numberPressed = 0;
                        playerCommand.isBusy = true;
                        GPressed = false;
                        break;
                    }
                    Task.Delay(10);
                }
                GPressed = false;
            }
        }

        private void PrintBehaviours() // not async for now // inputs are not working properly 
        {
            if (EPressed)
            {
                for (int i = 0; i < playerCommand.behaviours.Count(); i = i + 1)
                {
                    Console.WriteLine($"{i + 1}) {playerCommand.behaviours[i]}");
                }
                while (counter < 10)
                {
                    if (numberPressed != 0)
                    {
                        counter = 0;
                        playerCommand.EventController(numberPressed);
                        numberPressed = 0;
                        playerCommand.isBusy = true;
                        EPressed = false;
                        break;
                    }
                    Task.Delay(10);
                }
                EPressed = false;
            }
        }

        async private void EPressedCounterManager()
        {
            if (EPressed) { counter = counter + 1; }
            else { counter = 0; numberPressed = 0; }
        }

        private void GPressedCounterManager()
        {
            if (GPressed) { counter = counter + 1; }
            else { counter = 0; numberPressed = 0; }
        }

        private void PrintInputs()
        {
            Console.WriteLine("");
            // Console.WriteLine("Press F to feed the animal");
            Console.WriteLine("Press G to see inventory");
            Console.WriteLine("Press E to select behaviour");
            Console.WriteLine("Press V to switch to another animal");
            Console.WriteLine("");
        }
        
        private void ApplyStatus()
        {
            int divideBy = 80;
            
            if (AnimalSelected.TryGetValue(1, out AnimaStruct animal1)) { }
            if (AnimalSelected.TryGetValue(2, out AnimaStruct animal2)) { }
            if (AnimalSelected.TryGetValue(3, out AnimaStruct animal3)) { }

            if (AnimalStatus.TryGetValue(1, out float[] statsOfFirstAnimal)) { }
            if (AnimalStatus.TryGetValue(2, out float[] statsOfSecondAnimal)) { }
            if (AnimalStatus.TryGetValue(3, out float[] statsOfThirdAnimal)) { }
            
            statsOfFirstAnimal[0] = statsOfFirstAnimal[0] - decreaseRate * animal1.HungerScaling * DifficultyMultiplier / divideBy;
            statsOfFirstAnimal[1] = statsOfFirstAnimal[1] - decreaseRate * animal1.SleepScaling * DifficultyMultiplier / divideBy;
            statsOfFirstAnimal[2] = statsOfFirstAnimal[2] - decreaseRate * animal1.FunScaling * DifficultyMultiplier / divideBy;

            statsOfSecondAnimal[0] = statsOfSecondAnimal[0] - decreaseRate * animal2.HungerScaling * DifficultyMultiplier / divideBy;
            statsOfSecondAnimal[1] = statsOfSecondAnimal[1] - decreaseRate * animal2.SleepScaling * DifficultyMultiplier / divideBy;
            statsOfSecondAnimal[2] = statsOfSecondAnimal[2] - decreaseRate * animal2.FunScaling * DifficultyMultiplier / divideBy;

            statsOfThirdAnimal[0] = statsOfThirdAnimal[0] - decreaseRate * animal3.HungerScaling * DifficultyMultiplier / divideBy;
            statsOfThirdAnimal[1] = statsOfThirdAnimal[1] - decreaseRate * animal3.SleepScaling * DifficultyMultiplier / divideBy;
            statsOfThirdAnimal[2] = statsOfThirdAnimal[2] - decreaseRate * animal3.FunScaling * DifficultyMultiplier / divideBy;

            Thread.Sleep(flowDelay);
        }
    }
}
