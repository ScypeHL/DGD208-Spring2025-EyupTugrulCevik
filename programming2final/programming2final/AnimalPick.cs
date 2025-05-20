using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class AnimalPick : Game
    {
        private Dictionary<string, AnimaStruct> animaDict;
        
        private Gameplay gp;
        private Random rng = new Random();
        
        private List<AnimaStruct> animals;
        private List<string> animalsType;
        
        private ListSortBy sortby;
        public event Func<List<AnimaStruct>> sortOption;

        private T RandomColour<T>()
        {
            var v = Colours.GetValues(typeof(T));
            return (T)v.GetValue(rng.Next(0, v.Length));
        }
        public AnimalPick()
        {
            animals = new List<AnimaStruct>();
            animalsType = new List<string>();
            animaDict = new Dictionary<string, AnimaStruct>();
            animalSelected = new Dictionary<int, AnimaStruct>();
        }

        public void start()
        {
            createList();
            sortby = new ListSortBy(animals, this);

            Console.WriteLine("Those are the animals in hand:");
            printList(animals);
            menu();
            
            
            // pickAnimal();
        }

        private void menu()
        {           
            Console.WriteLine("What do you want to do: [Sort, Choose]");
            switch (Console.ReadLine().ToLower())
            {
                case "sort":
                    sortList();
                    menu();
                    break;
                case "choose":
                    pickAnimal();
                    break;
                default:
                    Console.WriteLine("Invalid command or input");
                    Console.WriteLine("");
                    menu();
                    break;
            }
        }

        void createList()
        {
            AnimaStruct Parrot = new AnimaStruct("Parrot", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["parrot"] = Parrot;
            animals.Add(Parrot);
            AnimaStruct Dog = new AnimaStruct("Dog", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["dog"] = Dog;
            animals.Add(Dog);
            AnimaStruct Cat = new AnimaStruct("Cat", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["cat"] = Cat;
            animals.Add(Cat);
            AnimaStruct Fish = new AnimaStruct("Fish", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["fish"] = Fish;
            animals.Add(Fish);
            AnimaStruct Bunny = new AnimaStruct("Bunny", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["bunny"] = Bunny;
            animals.Add(Bunny);
            AnimaStruct Hamster = new AnimaStruct("Hamster", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["hamster"] = Hamster;
            animals.Add(Hamster);

        }

        private void sortList()
        {
            sortby.chooseSortby();
            printList(sortOption?.Invoke());
        }

        private void printList(List<AnimaStruct> animals)
        {
            for (int i = 0; i < animals.Count; i = i + 1)
            {
                Console.Write($"[{animals[i].Colour} {animals[i].Type}] >");              
                if (animals[i].FunScaling <= 80) { Console.Write(" | Gets bored quickly"); }
                if (animals[i].FunScaling >= 120) { Console.Write(" | Joyful"); }
                if (animals[i].SleepScaling <= 80) { Console.Write(" | Sleeps a lot"); }
                if (animals[i].SleepScaling >= 120) { Console.Write(" | Energic"); }
                if (animals[i].HungerScaling <= 80) { Console.Write(" | Eats a lot"); }
                if (animals[i].HungerScaling >= 120) { Console.Write(" | Doesn't eat much"); }
                Console.Write("\n");
            }
            Console.WriteLine("");
        }

        private void pickAnimal()
        {
            string animalName;
            int animalCount = 3;
            while (animalCount > 0)
            {
                Console.WriteLine("Choose an animal by typing its name");
                animalName = Console.ReadLine().ToLower();

                if (animaDict.TryGetValue(animalName, out AnimaStruct pickedAnimal))
                {
                    animals.Remove(pickedAnimal);
                    animaDict.Remove(animalName);
                    animalSelected[animalCount] = pickedAnimal;
                    animalStatus[animalCount] = [pickedAnimal.Hunger, pickedAnimal.Sleep, pickedAnimal.Fun];
                    printList(animals);
                    animalCount = animalCount - 1;
                    Console.WriteLine(animalCount);
                }
                else { Console.WriteLine("There is no such animal like that, please choose among existing options"); }
            }
            
            gp = new Gameplay();
        }
    }
}
