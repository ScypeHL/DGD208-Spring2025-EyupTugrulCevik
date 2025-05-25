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
        public PlayerCommand()
        {
        }

        public void read()
        {
        }

        public void move()
        {
            switch (CurrentAnimal)
            {
                case 1:
                    CurrentAnimal = 2;
                    break;
                case 2:
                    CurrentAnimal = 3;
                    break;
                case 3:
                    CurrentAnimal = 1;
                    break;
            }

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
        }

        async public void InventoryController(int numberInput)
        {
            if (AnimalSelected.TryGetValue(CurrentAnimal, out AnimaStruct animal)) { }

            if (Inventory[numberInput].CanBeUsedOn == animal.Type) 
            { 
                animal.Hunger = animal.Hunger + Inventory[numberInput].HungerIncrease;
                animal.Sleep = animal.Sleep + Inventory[numberInput].SleepIncrease;
                animal.Fun = animal.Fun + Inventory[numberInput].FunIncrease;
                await Task.Delay(5000);
            }
        }
        
        public void events()
        {

        }

        public void printAnimals()
        {
            Console.WriteLine("");
            
            for (int i = 1; i <= 3; i = i + 1)
            {
                if (AnimalSelected.TryGetValue(i, out AnimaStruct _animal)) { Console.WriteLine(_animal.Type); }
            }
        }
    }
}
