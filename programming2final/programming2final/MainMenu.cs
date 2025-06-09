using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class MainMenu : Game
    {
        private List<string> strings = new List<string>();

        private bool isOnMainMenu;
        
        private int colouredLine = 3;
        private int startPaintAt = 3;
        public MainMenu() { isOnMainMenu = true; }

        async public Task MainFlow()
        {
            AddStrings("Welcome To Animal Manager");
            AddStrings("");
            AddStrings("Play");
            AddStrings("Options");
            AddStrings("Credits");

            var renderer = Task.Run(Renderer);

            CheckInput();
            await renderer;
            
        }

        private void CheckInput()
        {
            while (isOnMainMenu)
            {
                colouredLine = Math.Clamp(colouredLine, startPaintAt, strings.Count);
                if (Console.KeyAvailable)
                {
                    ConsoleKey keyPressed = Console.ReadKey(true).Key;

                    if (keyPressed == ConsoleKey.UpArrow) { colouredLine = colouredLine - 1; }
                    if (keyPressed == ConsoleKey.DownArrow) { colouredLine = colouredLine + 1; }
                    if (keyPressed == ConsoleKey.Enter) { Execute(strings[colouredLine - 1]); }

                }
            }
        }

        async private Task Renderer()
        {
            while (isOnMainMenu)
            {
                Console.Clear();
                PrintStrings(colouredLine);
                await Task.Delay(FlowDelay);
            }
        }
        
        private void AddStrings(string text)
        {
            strings.Add(text);
        }

        private void PrintStrings(int colouredLine)
        {
            for (int i = 0; i < strings.Count; i = i + 1)
            {
                if (i == colouredLine - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(strings[i]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.WriteLine(strings[i]);
                }
            }
        }

        private void Execute(string commandSelected)
        {
            switch (commandSelected)
            {
                case "Play":
                    isOnMainMenu = false;
                    AnimalPick animalPick = new AnimalPick();
                    animalPick.start();
                    break;
                case "Options":
                    SetUpOptionsMenu();
                    break;
                case "Credits":
                    Credits();
                    break;
                case "Back to Main Menu":
                    SetUpMainMenu();
                    break;
                case "Difficulty":
                    SetUpDifficulty();
                    break;
                case "Easy":
                    DifficultyMultiplier = 0.75f;
                    SetUpMainMenu();
                    break;
                case "Medium":
                    DifficultyMultiplier = 1f;
                    SetUpMainMenu();
                    break;
                case "Hard":
                    DifficultyMultiplier = 1.33f;
                    SetUpMainMenu();
                    break;
                default:
                    break;
            }
        }

        private void SetUpMainMenu()
        {
            colouredLine = 3;
            startPaintAt = 3;
            strings.Clear();
            AddStrings("Welcome To Animal Manager");
            AddStrings("");
            AddStrings("Play");
            AddStrings("Options");
            AddStrings("Credits");
        }

        private void SetUpOptionsMenu()
        {
            colouredLine = 3;
            strings.Clear();
            AddStrings("Options Menu");
            AddStrings("");
            AddStrings("Difficulty");
            AddStrings("Back to Main Menu");
        }

        private void SetUpDifficulty()
        {
            colouredLine = 3;
            strings.Clear();
            AddStrings("Options Menu");
            AddStrings("");
            AddStrings("Easy");
            AddStrings("Medium");
            AddStrings("Hard");
        }

        private void Credits()
        {
            colouredLine = 7;
            startPaintAt = 7;
            strings.Clear();
            AddStrings("This game is made by Eyup Tugrul Cevik - 2305041011");
            AddStrings("In this project small amount of code provided by 'claude.ai' is used");
            AddStrings("Some ideas from internet and from people around is used but not copied");
            AddStrings("Everything that is not marked as 'AI made' is written by me");
            AddStrings("'I saw that main menu thing from burak'");
            AddStrings("");
            AddStrings("Back to Main Menu");
        }
    }
}
