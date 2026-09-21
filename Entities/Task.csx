#load "../Enums/Status.csx"

public class Task(int id, string description, Status status, DateTime createdAt, DateTime UpdatedAt)
{
    public int Id {get; set;} = id;
    public string Description {get; set;} = description;
    public Status Status {get; set;} = status;
    public DateTime CreatedAt {get; set;} = createdAt;
    public DateTime UpdatedAt {get; set;} = UpdatedAt;
}