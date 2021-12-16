using System;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    /// <summary>
    /// recod pour affectation des donnée dans la view
    /// </summary>
    public record TaskViewModel
    {
        private readonly Domains.Task _task;

        /// <summary>
        /// constructeur 
        /// </summary>
        /// <param name="task"> tâche à affecter un une viniète</param>
        public TaskViewModel(Task task)
        {
            _task = task; 
        }

        /// <summary>
        /// renvoie le nom du chantier
        /// </summary>
        public string Chantier => _task.Planning;

        /// <summary>
        /// renvoie la description
        /// </summary>
        public string Description => _task.Description;
        /// <summary>
        /// renvoie la date formatée
        /// </summary>
        public string Date => string.Format("Du {0} au {1}", _task.DateStart, _task.DateEnd);
        /// <summary>
        /// renvoie le nombre de de retard 
        /// </summary>
        public int Delay =>  _task.DelayTime();
        /// <summary>
        /// renvoie la date effective de commancement
        /// </summary>
        public DateTime EffectiveDateStart =>  _task.EffectiveDateStart;
        /// <summary>
        /// renvoie la date effective de fin
        /// </summary>
        public DateTime EffectiveDateEnd =>  _task.EffectiveDateEnd;
        /// <summary>
        /// renvoie le statut de la tâche
        /// </summary>
        public string Statut => _task.Statut;

        /// <summary>
        /// renvoie la tâche
        /// </summary>
        public Task Task=> _task;
        
    }
}
