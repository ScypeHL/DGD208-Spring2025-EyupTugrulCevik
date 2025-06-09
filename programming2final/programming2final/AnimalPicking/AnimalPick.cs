using programming2final;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        private event Action whoSelected;

        private T RandomColour<T>() // I got some help over that since i could not understand how to use the enum thing.
        {
            var v = Colours.GetValues(typeof(T));
            return (T)v.GetValue(rng.Next(0, v.Length));
        }
        public AnimalPick()
        {
            animals = new List<AnimaStruct>();
            animalsType = new List<string>();
            animaDict = new Dictionary<string, AnimaStruct>();
            AnimalSelected = new Dictionary<int, AnimaStruct>();
        }

        public void start()
        {
            Console.Clear();
            CreateList();
            sortby = new ListSortBy(animals, this);

            Console.WriteLine("Those are the animals in hand:");
            PrintList(animals);
            Menu();
            
            
            // pickAnimal();
        }

        private void Menu()
        {
            Printer.Get("What do you want to do");
            Printer.GetHighlighted("sort");
            Printer.GetHighlighted("choose");
            Printer.MainFlow();

            switch (Printer.Execute())
            {
                case "sort":
                    SortList();
                    Menu();
                    break;
                case "choose":
                    PickAnimal();
                    break;
                default:
                    Console.WriteLine("Invalid command or input");
                    Console.WriteLine("");
                    Menu();
                    break;
            }
        }

        #region CreateAndSortList
        void CreateList()
        {
            AnimaStruct Parrot = new AnimaStruct("Parrot", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["Parrot"] = Parrot;
            animals.Add(Parrot);
            AnimaStruct Dog = new AnimaStruct("Dog", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["Dog"] = Dog;
            animals.Add(Dog);
            AnimaStruct Cat = new AnimaStruct("Cat", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["Cat"] = Cat;
            animals.Add(Cat);
            AnimaStruct Fish = new AnimaStruct("Fish", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["Fish"] = Fish;
            animals.Add(Fish);
            AnimaStruct Rabbit = new AnimaStruct("Rabbit", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["Rabbit"] = Rabbit;
            animals.Add(Rabbit);
            AnimaStruct Hamster = new AnimaStruct("Hamster", RandomColour<Colours>().ToString(), rng.Next(50, 151), rng.Next(50, 151), rng.Next(50, 151));
            animaDict["Hamster"] = Hamster;
            animals.Add(Hamster);

        }

        private void SortList()
        {
            sortby.chooseSortby();
            PrintList(sortOption?.Invoke());
        }
        #endregion

        private void PrintList(List<AnimaStruct> animals)
        {
            for (int i = 0; i < animals.Count; i = i + 1)
            {
                Printer.Get($"{animals[i].Colour} {animals[i].Type}");
                /* Console.Write($"[{animals[i].Colour} {animals[i].Type}] >");              
                if (animals[i].FunScaling <= 80) { Console.Write(" | Gets bored quickly"); }
                if (animals[i].FunScaling >= 120) { Console.Write(" | Joyful"); }
                if (animals[i].SleepScaling <= 80) { Console.Write(" | Sleeps a lot"); }
                if (animals[i].SleepScaling >= 120) { Console.Write(" | Energic"); }
                if (animals[i].HungerScaling <= 80) { Console.Write(" | Eats a lot"); }
                if (animals[i].HungerScaling >= 120) { Console.Write(" | Doesn't eat much"); }
                Console.Write("\n"); */
            }
            Console.WriteLine("");
        }

        private void PrintListHighlighted(List<AnimaStruct> animals)
        {
            for (int i = 0; i < animals.Count; i = i + 1)
            {
                Printer.GetHighlighted($"{animals[i].Type}");
            }
        }
        
        private void PickAnimal()
        {
            string animalName;
            int animalCount = 3;
            while (animalCount > 0)
            {
                Printer.Clear();
                Printer.Get("Choose an animal");
                whoSelected?.Invoke();
                PrintListHighlighted(animals);
                Printer.MainFlow();

                animalName = Printer.Execute();

                if (animaDict.TryGetValue(animalName, out AnimaStruct pickedAnimal))
                {
                    animals.Remove(pickedAnimal);
                    animaDict.Remove(animalName);
                    AnimalSelected[animalCount] = pickedAnimal;
                    AnimalStatus[animalCount] = [pickedAnimal.Hunger, pickedAnimal.Sleep, pickedAnimal.Fun, 0];
                    animalCount = animalCount - 1;
                    whoSelected += () => printSelectedAnimal();
                }
                else { Console.WriteLine("There is no such animal like that, please choose among existing options"); }
            }

            void printSelectedAnimal()
            {
                Printer.Get($"You have selected: {animalName}");
                whoSelected -= printSelectedAnimal;
            }
            
            gp = new Gameplay();
        }
    }
}
