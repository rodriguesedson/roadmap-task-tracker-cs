#load "Utils/InputHandler.csx"
#load "Utils/Menu.csx"

var runApp = true;

do
{
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.Write("task-cli: ");
    Console.ResetColor();

    var input = Console.ReadLine();
    var command = InputHandler.GetCommand(input);

    switch (command)
    {
        case "clear":
            Console.Clear();
            break;
        case "exit":
            runApp = false;
            break;
        default:
            Menu.HandleCommand(command);
            break;
    }
} while (runApp);