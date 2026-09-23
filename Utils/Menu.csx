#load "../Services/TaskService.csx"

public class Menu
{
    private readonly TaskService _taskService;

    public Menu() {
        _taskService = new TaskService();
    }

    public void HandleCommand(string command, string input)
    {
        switch (command)
        {
            case "add":
                _taskService.Add(input);
                break;
            case "update":
                _taskService.Update(input);
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