using System;
using VINCENT.Nicolas.Poo.Tracker.Domains;
using Task = VINCENT.Nicolas.Poo.Tracker.Domains.Task;

namespace VINCENT.Nicolas.Poo.Tracker.Controllers
{


    
   public class TaskController
    {
        private readonly ITaskRepository _repository;

        public event EventHandler<Task> StartTask;
        public event EventHandler<Task> EndTask;

        public TaskController(ITaskRepository repository) 
        {
            _repository = repository;
        }


        public void AffectDateTaskStart(object sender, Task task) 
        {
            task.AffectDateStart();
            _repository.Update(task);

            StartTask?.Invoke(this, task);
            
        }

        public void AffectDateTaskEnd(object sender, Task task)
        {
            task.AffectDateEnd();
            _repository.Update(task);
            EndTask?.Invoke(this, task);
        }

        

    }
}
