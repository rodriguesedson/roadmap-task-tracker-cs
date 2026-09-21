public static class FileConfig
{
    public static void StartConfig() {
        var dataFilePath = "Data/tasks-data.json";
        var directoryName = "Data";
        if (!Directory.Exists(directoryName) || !File.Exists(dataFilePath))
        {
            var initialData = "{}";
            Directory.CreateDirectory(directoryName);
            File.WriteAllText(dataFilePath, initialData);
        }
    }
}