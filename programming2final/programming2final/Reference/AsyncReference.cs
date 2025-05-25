using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Flag to control if we should keep updating the screen
    private static bool _keepRunning = true;

    // Current input from the user
    private static string _currentInput = string.Empty;

    // Counter for demonstration purposes
    private static int _counter = 0;

    static async Task Main(string[] args)
    {
        Console.WriteLine("Interactive Console Application");
        Console.WriteLine("Press 'Q' to quit, any other key to update the counter value");
        Console.WriteLine();

        // Start the task that handles screen updates
        var updateTask = Task.Run(UpdateScreenPeriodically);

        // Start handling keyboard input (this won't block Main)
        await HandleKeyboardInput();

        // Wait for the update task to complete
        await updateTask;

        Console.WriteLine("Application has ended. Press any key to exit.");
        Console.ReadKey(true);
    }

    private static async Task HandleKeyboardInput()
    {
        while (_keepRunning)
        {
            // ReadKey is blocking, but it's now in a separate task
            // so it won't block the screen updates
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true); // true means don't display the key

                if (key.Key == ConsoleKey.Q)
                {
                    _keepRunning = false;
                }
                else
                {
                    _currentInput = key.KeyChar.ToString();
                    // Increment counter when a key is pressed
                    _counter++;
                }
            }

            // Small delay to prevent CPU overuse
            await Task.Delay(50);
        }
    }

    private static async Task UpdateScreenPeriodically()
    {
        // Save the initial cursor position
        int initialCursorLeft = Console.CursorLeft;
        int initialCursorTop = Console.CursorTop;

        while (_keepRunning)
        {
            // Clear only the relevant part of the screen
            ClearLine(initialCursorTop);
            ClearLine(initialCursorTop + 1);

            // Reset cursor position
            Console.SetCursorPosition(initialCursorLeft, initialCursorTop);

            // Update the display
            Console.WriteLine($"Counter: {_counter}");
            Console.WriteLine($"Last Key Pressed: {_currentInput}");

            // Wait a bit before next update
            await Task.Delay(100);
        }
    }

    private static void ClearLine(int top)
    {
        Console.SetCursorPosition(0, top);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, top);
    }
}