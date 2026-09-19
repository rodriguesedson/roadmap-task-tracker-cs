public class Program
{
    static void Main()
    {
        var runApp = true;

        do
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("task-cli: ");
            Console.ResetColor();

            var input = Console.ReadLine();

            switch (input)
            {
                case "clear":
                    Console.Clear();
                    break;
                case "exit":
                    runApp = false;
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        } while (runApp);
    }
}