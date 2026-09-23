#load "../Repositories/TaskRepository.csx"
#load "../Utils/InputHandler.csx"

public class TaskService
{
    private readonly Repository _repository;
    public TaskService()
    {
        _repository = new Repository();
    }

    public void Add(string input)
    {
        try
        {
            var description = InputHandler.GetAddDescription(input);
            var tasksList = _repository.ListTasks();
            var newId = tasksList.Count + 1;
            var newTask = new Task(newId, description, Status.TODO, DateTime.Now, DateTime.Now);

            _repository.SaveTask(newTask);
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
            var tasksList = _repository.ListTasks();
            var task = tasksList.FirstOrDefault(t => t.Id == id) ?? throw new Exception("Task not found");
            task.Description = description;
            task.UpdatedAt = DateTime.Now;
            _repository.UpdateTask(tasksList);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}