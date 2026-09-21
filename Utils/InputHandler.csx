public static class InputHandler
{
    public static string GetCommand(string input)
    {
        var wordsList = input.Split(" ");
        var command = wordsList[0];
        var listCommands = new List<string>{"todo", "in-progress", "done"};

        if (command.Equals("list") && wordsList.Count() > 1)
        {
            var secondCommand = wordsList[1];
            if (listCommands.Contains(secondCommand))
            {
                return $"{command} {secondCommand}";
            }
        }

        return command;
    }

    public static int GetId(string input)
    {
        var id = input.Split(" ")[1];
        if (!int.TryParse(id, out _))
            throw new Exception("Invalid id");
        else
            return int.Parse(id);
    }

    public static string GetDescription(string input)
    {
        var description = input.Split(" ");
        if (description.Count() == 1 || description.Count() == 2 && int.TryParse(description[1], out _))
            throw new Exception("Invalid task description");
        else
            return string.Join(" ", description[1..]);
    }
}