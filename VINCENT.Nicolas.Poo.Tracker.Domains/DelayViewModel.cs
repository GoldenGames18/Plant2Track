using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    public class DelayViewModel
    {

        private readonly List<Task> _tasks;

        public DelayViewModel(List<Task> tasks)
        {
            _tasks = tasks;
        }

        /// <summary>
        /// calculer le délait de chaque planning pour utilsateur connecter 
        /// </summary>
        public string Delay
        {
            get
            {
                int value = 0;
                foreach (var item in _tasks)
                {
                    value += item.DelayTime();
                }

                return value + " jours de retard";
            }

        }
        /// <summary>
        /// return le nom du planning
        /// </summary>
        public string Name
        {
            get
            {

                string name = _tasks[0].Planning;
                foreach (var item in _tasks)
                {
                    if (name != item.Planning)
                    {
                        return "Total";
                    }
                }

                return name;

            }

        }


    }
}
