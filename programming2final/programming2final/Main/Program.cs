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
            
            // Printer printer = new Printer();
            
            // printer.Get("Hello and Welcome");
            // printer.Get("We decided to hire you");
            // printer.Get("What do you think");
            // printer.GetHighlighted("Yes");
            // printer.GetHighlighted("No");
            // printer.MainFlow();
        }
    }
}