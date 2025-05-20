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
        public PlayerCommand()
        {
        }

        public void read()
        {
            string q1 = "";
            q1 = Console.ReadLine();

            switch (q1)
            {
                case "move":
                    move();
                    break;
                case "use":
                    break;
                case "pet":
                    break;
                case "feed":
                    feed(20);
                    break;
                default:
                    break;
            }
        }

        public void move()
        {
            Console.WriteLine("Which animal you want to move to");
            printAnimals();
        }

        public void feed(int feedPoint)
        {
            if (animalSelected.TryGetValue(CurrentAnimal, out AnimaStruct animal)) { }
            if (animalStatus.TryGetValue(CurrentAnimal, out float[] animalStat)) { }

            animalStat[0] = animalStat[0] + feedPoint;
            Console.WriteLine($"You feed {animal.Type} and its hunger increased by {feedPoint}");
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
