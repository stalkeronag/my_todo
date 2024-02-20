namespace WebApi.Services.Interfaces
{
    public interface ITaskService
    {
        public void AddTask();

        public void RemoveTask();

        public void GetAllExpiredTask();

        public void GetTaskById();

        public void GetTaskByName();

        public void MarkTaskAsDone();

    }
}
