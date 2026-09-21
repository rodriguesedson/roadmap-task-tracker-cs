#load "../Entities/Task.csx"

using System.Text.Json;
using System.Text.Encodings.Web;

public class Repository
{
    public string FilePath {get; set;} = "Data/tasks-data.json";

    public void SaveTask(Task task)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented  = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var tasksList = ListTasks();
        tasksList.Add(task);

        var data = JsonSerializer.Serialize(tasksList, jsonOptions);
        File.WriteAllText(FilePath, data);
    }

    public List<Task> ListTasks()
    {
        var data = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Task>>(data);
    }
}