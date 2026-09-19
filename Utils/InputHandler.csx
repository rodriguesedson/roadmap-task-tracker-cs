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
}