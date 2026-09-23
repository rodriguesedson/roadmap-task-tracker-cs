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
        var contentArray = input.Split(" ");
        if (contentArray.Count() == 1)
            throw new Exception("Id is missing");
        else
        {
            if (!int.TryParse(contentArray[1], out _))
                throw new Exception("Invalid id");
            else
                return int.Parse(contentArray[1]);
        }
    }

    public static string GetAddDescription(string input)
    {
        var description = input.Split(" ");
        if (description.Count() <= 2 && int.TryParse(description[1], out _))
            throw new Exception("Invalid task description");
        else
            return string.Join(" ", description[1..]);
    }

    public static (int, string) GetIdAndDescription(string input)
    {
        var contentArray = input.Split(" ");
        if (contentArray.Count() == 1)
            throw new Exception("Invalid task id or description");
        else if (contentArray.Count() == 2)
            if (!int.TryParse(contentArray[1], out _))
                throw new Exception("Invalid task id");
            else
                throw new Exception("Invalid task description");
        else
        {
            var id = contentArray[1];
            if (!int.TryParse(id, out _)) throw new Exception("Invalid id");
            var description = string.Join(" ", contentArray[2..]);
            return (int.Parse(id), description);
        }
    }
}