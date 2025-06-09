using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class LoseScreen: Game
    {
        private string output;
        public void start()
        {
            Printer.Get("You lost all of you animals");
            Printer.Get("It is detected by goverment and taken from you");
            Printer.Get("Now they are waiting to find a good home that will take care of them properly");

            Printer.GetHighlighted("Quit");
            Printer.MainFlow();

            output = Printer.Execute();

            switch (output)
            {
                case "Quit":
                    System.Environment.Exit(-1);
                    break;
            }
        }
    }
}
