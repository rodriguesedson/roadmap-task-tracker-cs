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
            var description = InputHandler.GetDescription(input);
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
}