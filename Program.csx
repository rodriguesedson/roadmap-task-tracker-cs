#load "Utils/InputHandler.csx"
#load "Utils/Menu.csx"
#load "Utils/FileConfig.csx"

var runApp = true;

FileConfig.StartConfig();

var menu = new Menu();

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
            menu.HandleCommand(command, input);
            break;
    }
} while (runApp);