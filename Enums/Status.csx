using System.Text.Json.Serialization;

public enum Status
{
    [JsonPropertyName("todo")]
    TODO,
    [JsonPropertyName("in-progress")]
    IN_PROGRESS,
    [JsonPropertyName("done")]
    DONE
}