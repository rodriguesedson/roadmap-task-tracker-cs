#load "../Entities/Task.csx"
#load "../Entities/DataRegistry.csx"

using System.Text.Json;
using System.Text.Encodings.Web;

public class TaskRepository
{
    public string FilePath {get; set;} = "Data/tasks-data.json";

    public DataRegistry GetData()
    {
        var data = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<DataRegistry>(data);
    }

    public void SaveData(DataRegistry data)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var fileData = JsonSerializer.Serialize(data, jsonOptions);
        File.WriteAllText(FilePath, fileData);
    }
}