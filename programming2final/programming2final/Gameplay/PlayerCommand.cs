using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class PlayerCommand : Game
    {
        public bool isBusy = false;
        public bool itemUsed = false;
        public bool isFeeding = false;
        public bool isExecutingAnEvent = false;

        public string[] behaviours = {"pet the animal", "send the animal to sleep", "play with the animal"};
        public PlayerCommand()
        {
        }

        public void read()
        {
        }

        public void move()
        {
            if (CurrentAnimal >= 3) { CurrentAnimal = 1; }
            else { CurrentAnimal = CurrentAnimal + 1; }
        }

        async public void Feed(int feedPoint, int cooldown)
        {
            isFeeding = true;

            if (AnimalSelected.TryGetValue(CurrentAnimal, out AnimaStruct animal)) { }
            if (AnimalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

            await Task.Delay(cooldown);
            animalStat[0] = animalStat[0] + feedPoint;
            Console.WriteLine($"You feed {animal.Type} and its hunger increased by {feedPoint}");
            isFeeding = false;
            isBusy = false;
        }

        async public void InventoryController(int numberInput)
        {
            if (AnimalSelected.TryGetValue(CurrentAnimal, out AnimaStruct animal)) { }
            if (AnimalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

            if (Inventory[numberInput - 1].CanBeUsedOn == animal.Type.ToLower()) 
            { 
                isFeeding = true;
                await Task.Delay(5000);
                animalStat[0] = animalStat[0] + Inventory[numberInput - 1].HungerIncrease;
                animalStat[1] = animalStat[1] + Inventory[numberInput - 1].SleepIncrease;
                animalStat[2] = animalStat[2] + Inventory[numberInput - 1].FunIncrease;
                isFeeding = false;
                isBusy = false;
            }
        }
        
        async public void EventController(int numberInput)
        {
            if (AnimalSelected.TryGetValue(CurrentAnimal, out AnimaStruct animal)) { }
            if (AnimalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

            switch (numberInput)
            {
                case 1:
                    EventHandler(2000, 0, -1, 5);
                    break;
                case 2:
                    EventHandler(12000, -5, 30, 0);
                    break;
                case 3:
                    EventHandler(5000, -4, -4, 15);
                    break;
            }

            async void EventHandler(int delay, int hungerIncrease, int sleepIncrease, int funIncrease)
            {
                isExecutingAnEvent = true;
                await Task.Delay(delay);
                
                animalStat[0] = animalStat[0] + hungerIncrease;
                animalStat[1] = animalStat[1] + sleepIncrease;
                animalStat[2] = animalStat[2] + funIncrease;

                isBusy = false;
                isExecutingAnEvent = false;
            }
        }

        public void PrintAnimals()
        {
            Console.WriteLine("");
            
            for (int i = 1; i <= 3; i = i + 1)
            {
                if (AnimalSelected.TryGetValue(i, out AnimaStruct _animal)) { Console.WriteLine(_animal.Type); }
            }
        }
    }
}
