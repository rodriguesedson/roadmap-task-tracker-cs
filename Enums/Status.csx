using System.Text.Json.Serialization;
using System.ComponentModel;

public enum Status
{
    [Description("todo")]
    TODO,
    [Description("in-progress")]
    IN_PROGRESS,
    [Description("done")]
    DONE,
    [Description("deleted")]
    DELETED
}