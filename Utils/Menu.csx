public static class Menu
{
    public static void HandleCommand(string command)
    {
        switch (command)
        {
            case "add":
                Console.WriteLine("Work in progress");
                break;
            case "update":
                Console.WriteLine("Work in progress");
                break;
            case "delete":
                Console.WriteLine("Work in progress");
                break;
            case "mark-in-progress":
                Console.WriteLine("Work in progress");
                break;
            case "mark-done":
                Console.WriteLine("Work in progress");
                break;
            case "list":
                Console.WriteLine("Work in progress");
                break;
            case "list done":
                Console.WriteLine("Work in progress");
                break;
            case "list todo":
                Console.WriteLine("Work in progress");
                break;
            case "list in-progress":
                Console.WriteLine("Work in progress");
                break;
            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }
}