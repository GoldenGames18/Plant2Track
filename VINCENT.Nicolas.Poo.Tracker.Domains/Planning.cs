using System.Collections.Generic;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    public class Planning
    {
        private readonly  List<Task> _planning ;
        private readonly string _name;

        public Planning(string name, params Task[] planning)
        {
            _name = name;
            _planning = new List<Task>(planning);
        }

        /// <summary>
        /// getter et setter de name
        /// </summary>
        public string Name { get { return _name; } }
       
        /// <summary>
        /// cette méthode va aller chercher tous les task de l'utilisateur connecter
        /// </summary>
        /// <param name="code"> code de utilsateur connecter</param>
        /// <returns>un liste de task d'un user conenecter </returns>
        public List<Task> TakeTask(string code)
        {
            List<Task> taskList = new();
            foreach (Task task in _planning)
                if (task.Code == code)
                    taskList.Add(task);
            return taskList;
 
        }

        public List<Task> Tasks { get { return _planning; } }


        /// <summary>
        /// cette méthode permet de retourner les nom du chantier et celui-ci est null si il n'existe pas dans le chantier
        /// </summary>
        /// <param name="task"> task d'une utilsateur connecter </param>
        /// <returns>le nomre du chantier ou une valeur null</returns>
        public string GiveNamePojectByTask(Task task)
        {
            foreach (var item in _planning)
            {
                if (item.Equals(task))
                {
                    return Name;
                }

            }
            return null;
        }


        public void Update(Task update)
        {
            int value = -1;
            foreach (var item in _planning)
            {
                if (item.Update(update))
                {
                    value = _planning.IndexOf(item);
                }
            }

            if (value > -1)
            {
                _planning[value] = update;
            }

        }



    }
}
