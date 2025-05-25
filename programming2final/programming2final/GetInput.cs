using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class GetInput : Game
    {
        public GetInput() { }

        private string CheckInput()
        {
            string q1 = "";
            if (Console.KeyAvailable)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.D1) { q1 = "1"; }
                if (keyPressed == ConsoleKey.D2) { q1 = "2"; }
                if (keyPressed == ConsoleKey.D3) { q1 = "3"; }
                if (keyPressed == ConsoleKey.D4) { q1 = "4"; }
                if (keyPressed == ConsoleKey.D5) { q1 = "5"; }
                if (keyPressed == ConsoleKey.D6) { q1 = "6"; }
                if (keyPressed == ConsoleKey.D7) { q1 = "7"; }
                if (keyPressed == ConsoleKey.D8) { q1 = "8"; }
                if (keyPressed == ConsoleKey.D9) { q1 = "9"; }
            }
            Task.Delay(1);
            return q1;
        }
    }
}
