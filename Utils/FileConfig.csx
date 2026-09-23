#load "../Entities/DataRegistry.csx"

using System.Text.Json;
using System.Text.Encodings.Web;

public static class FileConfig
{
    public static void StartConfig() {
        var dataFilePath = "Data/tasks-data.json";
        var directoryName = "Data";
        if (!Directory.Exists(directoryName) || !File.Exists(dataFilePath))
        {
            var dataRegistry = new DataRegistry
            {
                TaskCount = 0,
                TaskList = new List<Task>()
            };
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented  = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var initialData = JsonSerializer.Serialize(dataRegistry, jsonOptions);
            Directory.CreateDirectory(directoryName);
            File.WriteAllText(dataFilePath, initialData);
        }
    }
}