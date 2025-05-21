using System;

namespace Pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            AnimalPick animalPick = new AnimalPick();
            animalPick.start();
        }
    }
}