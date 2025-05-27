using System;

namespace Pro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            
            MainMenu menu = new MainMenu();
            menu.MainFlow();
            
        }
    }
}