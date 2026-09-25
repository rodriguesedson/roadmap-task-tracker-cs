#load "../Repositories/TaskRepository.csx"
#load "../Utils/InputHandler.csx"
#load "../Entities/DataRegistry.csx"

public class TaskService
{
    private readonly TaskRepository _repository;
    public TaskService()
    {
        _repository = new TaskRepository();
    }

    public void Add(string input)
    {
        try
        {
            var description = InputHandler.GetAddDescription(input);
            var data = _repository.GetData();
            var taskList = data.TaskList;
            var newId = data.TaskCount + 1;
            var newTask = new Task(newId, description, Status.TODO, DateTime.Now, DateTime.Now);
            taskList.Add(newTask);
            data.TaskCount += 1;

            _repository.SaveData(data);
        } 
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public void Update(string input)
    {
        try
        {
            var (id, description) = InputHandler.GetIdAndDescription(input);
            var (data, task) = FindTask(input);
            task.Description = description;
            task.UpdatedAt = DateTime.Now;
            _repository.SaveData(data);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public void Delete(string input)
    {
        try
        {
            var (data, task) = FindTask(input);
            var taskIndex = data.TaskList.IndexOf(task);
            data.TaskList.RemoveAt(taskIndex);
            _repository.SaveData(data);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public void MarkInProgress(string input)
    {
        try
        {
            var (data, task) = FindTask(input);
            task.Status = Status.IN_PROGRESS;
            _repository.SaveData(data);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public void MarkDone(string input)
    {
        try
        {
            var (data, task) = FindTask(input);
            task.Status = Status.DONE;
            _repository.SaveData(data);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private (DataRegistry, Task) FindTask(string input)
    {
        var id = InputHandler.GetId(input);
        var data = _repository.GetData();
        var taskList = data.TaskList;
        var task = taskList.FirstOrDefault(t => t.Id == id) ?? throw new Exception("Task not found");
        return (data, task);
    }
}