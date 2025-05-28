using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Printer : Game
    {
        private List<string> strings = new List<string>();
        private List<string> stringsHighlighted = new List<string>();
        private int colouredLine;
        public Action takeAction;
        private bool onStage = true;

        public Printer() { }

        #region Fundementals
        public void Get(string text)
        {
            strings.Add(text);
        }

        public void GetHighlighted(string text)
        {
            stringsHighlighted.Add(text);
        }
        #endregion

        public async void MainFlow()
        {
            var printer = Task.Run(Print);

            colouredLine = strings.Count + 2;
            GetInput();
            await printer;
        }

        private void GetInput()
        {
            while (onStage)
            {
                colouredLine = Math.Clamp(colouredLine, strings.Count + 1, strings.Count + stringsHighlighted.Count + 1);
                if (Console.KeyAvailable)
                {
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;

                    if (keyPressed == ConsoleKey.UpArrow) { colouredLine = colouredLine - 1; }
                    if (keyPressed == ConsoleKey.DownArrow) { colouredLine = colouredLine + 1; }
                    if (keyPressed == ConsoleKey.Enter) { Execute(stringsHighlighted[colouredLine - 2 - strings.Count]); }

                }
            }
        }

        async public Task Print()
        {
            while (onStage)
            {
                Console.Clear();
                for (int i = 0; i < strings.Count; i++)
                {
                    Console.WriteLine(strings[i]);
                }
                Console.Write($"\n");
                PrintHighlighted(colouredLine);
                await Task.Delay(FlowDelay);
            }
        }

        private void PrintHighlighted(int colouredLine)
        {
            for (int i = strings.Count + 1; i < stringsHighlighted.Count + strings.Count + 1; i = i + 1)
            {
                if (i == colouredLine - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(stringsHighlighted[i - strings.Count - 1]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.WriteLine(stringsHighlighted[i - strings.Count - 1]);
                }
            }
        }

        private void Execute(string context)
        {
            if (context == stringsHighlighted[0]) { }
        }
    }
}
