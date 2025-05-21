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
        public bool itemUsed = false;
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

        public async Task feed(int feedPoint, int cooldown)
        {
            if (animalSelected.TryGetValue(CurrentAnimal, out AnimaStruct animal)) { }
            if (animalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

            itemUsed = true;
            await Task.Delay(cooldown);
            animalStat[0] = animalStat[0] + feedPoint;
            Console.WriteLine($"You feed {animal.Type} and its hunger increased by {feedPoint}");
            itemUsed = false;
        }

        public void printAnimals()
        {
            Console.WriteLine("");
            
            for (int i = 1; i <= 3; i = i + 1)
            {
                if (animalSelected.TryGetValue(i, out AnimaStruct _animal)) { Console.WriteLine(_animal.Type); }
            }
        }
    }
}
