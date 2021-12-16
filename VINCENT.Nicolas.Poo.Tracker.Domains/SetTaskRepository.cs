using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    /// <summary>
    /// task repository
    /// </summary>
    public class SetTaskRepository : ITaskRepository
    {

        public event NotifyCollectionChangedEventHandler CollectionChanged;
    

        private  List<Task> _tasks = new();
        private  List<Task> _copyList = new();

        public IEnumerator<Task> GetEnumerator() => _tasks.GetEnumerator();
           
        /// <summary>
        /// update de la view
        /// </summary>
        public void Update()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// update des task dans assembly
        /// </summary>
        /// <param name="task"></param>
        public void Update(Task task)
        {
            Task value = null;
            foreach (var item in _copyList)
            {
                if (item.Update(task))
                {
                    value = item; 
                }
               
            }

            _copyList[_copyList.IndexOf(value)] = task;
            _tasks[_tasks.IndexOf(value)] = task;
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tasks"></param>
        public void Add(List<Task> tasks) 
        {
            foreach (var item in tasks)
            {
                _tasks.Add(item);
                _copyList.Add(item);
            }
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        /// <summary>
        /// enumerator de list 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => _tasks.GetEnumerator(); 
        /// <summary>
        /// trie par ordre des date
        /// </summary>
        public void SortDate() => _tasks.Sort((x, y) => x.DateStart.CompareTo(y.DateStart));
        /// <summary>
        /// ordre décroisant statut
        /// </summary>
        public void ReverseStatu() => _tasks.Sort((x, y) => y.Statut.CompareTo(x.Statut));
        /// <summary>
        /// ordre croisant statu
        /// </summary>
        public void SortStatu() => _tasks.Sort((x, y) => x.Statut.CompareTo(y.Statut));
        /// <summary>
        /// ordre décroisant site
        /// </summary>
        public void ReverseSite() => _tasks.Sort((x, y) => y.Planning.CompareTo(x.Planning));

        /// <summary>
        /// ordre croisant  site
        /// </summary>
        public void SortSite() => _tasks.Sort((x, y) => x.Planning.CompareTo(y.Planning));

        /// <summary>
        /// filtrer par statut 
        /// </summary>
        /// <param name="statut">donner de filtre</param>
        public void FindStatut(string statut)
        {
            _tasks = _tasks.FindAll(x => x.Statut == statut);
        }
        /// <summary>
        /// filtrer sur le nom du planning
        /// </summary>
        /// <param name="name"> nom du planning</param>
        public void FindSite(string name)
        {
            _tasks = _tasks.FindAll(x => x.Planning == name);
        }

        /// <summary>
        /// filter sur les date
        /// </summary>
        /// <param name="date"> date donne par utilisateur</param>
        public void FindDate(string date)
        {
            _tasks = _tasks.FindAll(x => x.DateStart == date || x.EffectiveDateStart.ToString("dd-MM-yyyy") == date);
        }

        /// <summary>
        /// supprimer tous les filtres
        /// </summary>
        public void ResetFilter()
        {
            _tasks = _copyList;
        }

        /// <summary>
        ///  ordre croisant date de début
        /// </summary>
        public void SortDateStart() => _tasks.Sort((x, y) => x.DateStart.CompareTo(y.DateStart));
        /// <summary>
        /// ordre décroisant date de début
        /// </summary>
        public void ReverseDateStart() => _tasks.Sort((x, y) => y.DateStart.CompareTo(x.DateStart));

    }
}
