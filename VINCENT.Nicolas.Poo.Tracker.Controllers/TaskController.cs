using System;
using VINCENT.Nicolas.Poo.Tracker.Datas;
using VINCENT.Nicolas.Poo.Tracker.Domains;
using Task = VINCENT.Nicolas.Poo.Tracker.Domains.Task;

namespace VINCENT.Nicolas.Poo.Tracker.Controllers
{


    
   public class TaskController
    {
        private readonly ITaskRepository _repository;

        public event EventHandler<Task> StartTask;
        public event EventHandler<Task> EndTask;

        private readonly JsonRepositoty _jsonRepositoty;

        public TaskController(ITaskRepository repository, JsonRepositoty jsonRepositoty) 
        {
            _repository = repository;
            _jsonRepositoty = jsonRepositoty;
        }


        /// <summary>
        /// update des task pour le temp minimum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="task"></param>
        public void AffectDateTaskStart(object sender, Task task) 
        {
            task.AffectDateStart();
            _repository.Update(task);
            _jsonRepositoty.WritePlanning(task);
            StartTask?.Invoke(this, task);
            
        }

        /// <summary>
        /// update des task pour le temps maximum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="task"></param>
        public void AffectDateTaskEnd(object sender, Task task)
        {
            task.AffectDateEnd();
            _repository.Update(task);
            _jsonRepositoty.WritePlanning(task);
            EndTask?.Invoke(this, task);
        }

        

    }
}
