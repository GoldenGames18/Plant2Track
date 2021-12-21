using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    /// <summary>
    /// task repository
    /// </summary>
    public class SetTaskRepository : ITaskRepository
    {

        public event NotifyCollectionChangedEventHandler CollectionChanged;


        private  List<Task> _tasks = new();
        private List<Task> _copyList = new();


        public List<Task> Tasks => _tasks;


        public IEnumerator<Task> GetEnumerator() => _tasks.GetEnumerator();

        public DateTime Start { get; set;}

        /// <summary>
        /// getter setter 
        /// </summary>   
        public DateTime End { get; set;}
        /// <summary>
        /// getter setter 
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// getter setter 
        /// </summary>
        public double[] TabValue { get; set; }
        /// <summary>
        /// getter setter 
        /// </summary>
        public double[] TabIndex { get; set; }

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
            CreateGraph(Start, End, Value);
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

        #region filterApllication

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
        #endregion
        #region graphDay
        /// <summary>
        /// creation de la taille du tableau
        /// </summary>
        /// <param name="start">date de début et date de fin </param>
        /// <param name="end"></param>
        public void SizeDay(DateTime start, DateTime end)
        {
            double[] tab = new double[(end - start).Days + 1];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = i;
            }
            TabIndex = tab;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>  
        public void ValueDay(DateTime start, DateTime end)
        {
            double[] tab = new double[(end - start).Days + 1];

            for (int i = 0; i < tab.Length; i++)
            {
                foreach (var item in _copyList)
                {
                    if (start.Equals(item.EffectiveDateEnd))
                    {
                        double value = tab[i];
                        tab[i] = value + 1;
                    }
                }
                start = start.AddDays(1);
            }
            TabValue = tab;
        }

        #endregion
        #region GraphMont
        public void SizeMonth(DateTime start, DateTime end)
        {
            double[] tab = new double[((end.Year - start.Year) * 12 + (end.Month - start.Month)) + 1];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = i;
            }
            TabIndex = tab;
        }
        public void ValueMonth(DateTime start, DateTime end)
        {
            double[] tab = new double[((end.Year - start.Year) * 12 + (end.Month - start.Month)) + 1];

            for (int i = 0; i < tab.Length; i++)
            {
                foreach (var item in _copyList)
                {
                    if (start.Month == item.EffectiveDateEnd.Month)
                    {
                        double value = tab[i];
                        tab[i] = value + 1;
                    }
                }
                start = start.AddMonths(1);
            }
            TabValue = tab;
        }
        #endregion
        #region GraphWeek
        private int NumberOfWeekBetweenTWoDate(DateTime start, DateTime end)
        {
            int value = 1;
            var copy = start;
            int weekValue = int.MaxValue;
            while (end.CompareTo(copy) != 0)
            {
                if (copy.DayOfWeek == DayOfWeek.Sunday || copy.DayOfWeek == DayOfWeek.Monday && ISOWeek.GetWeekOfYear(copy) == weekValue)
                {
                    value++;
                    weekValue = ISOWeek.GetWeekOfYear(copy);
                }
                copy = copy.AddDays(1);

            }
            return value;

        }

        public void SizeWeek(DateTime start, DateTime end)
        {
            double[] tab = new double[NumberOfWeekBetweenTWoDate(start,end)];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = i;
            }
            TabIndex = tab;
        }
        public void ValueWeek(DateTime start, DateTime end)
        {
            double[] tab = new double[NumberOfWeekBetweenTWoDate(start, end)];

            start = BackTime(start);

            for (int i = 0; i < tab.Length; i++)
            {
                foreach (var item in _copyList)
                {
                    if (ISOWeek.GetWeekOfYear(start) == ISOWeek.GetWeekOfYear(item.EffectiveDateEnd) && start.Year == item.EffectiveDateEnd.Year)
                    {
                        double value = tab[i];
                        tab[i] = value + 1;
                    }
                }
                start = start.AddDays(7);
            }
            TabValue = tab;
        }

        private static DateTime BackTime(DateTime start)
        {
            while (start.DayOfWeek != DayOfWeek.Monday)
            {
                start = start.AddDays(-1);
            }

            return start;
        }

        #endregion
        #region CreateGraph

        /// <summary>
        /// generation du graphic
        /// </summary>
        /// <param name="start">date de début</param>
        /// <param name="end">date de fin</param>
        /// <param name="type"> valeur du filtre</param>
        public void CreateGraph(DateTime start, DateTime end, string type)
        {
            End = end;
            Start = start;
            Value = type;
            
            if (type == "0" || string.IsNullOrEmpty(Value))
            {
                CreateGraphDay();

            }
            else if (type == "1")
            {
                CreateGraphWeek();

            }
            else if (type == "2")
            {
                CreateGraphMonth();
            }

        }
        /// <summary>
        /// generer le graph pour les mois
        /// </summary>
        private void CreateGraphMonth()
        {
            Value = "2";
            SizeMonth(Start, End);
            ValueMonth(Start, End);
        }

        /// <summary>
        /// generer le grpah pour les semaines
        /// </summary>
        private void CreateGraphWeek()
        {
            Value = "1";
            SizeWeek(Start, End);
            ValueWeek(Start, End);
        }

        /// <summary>
        /// generer les graph pour les jour
        /// </summary>
        private void CreateGraphDay()
        {
            if (string.IsNullOrEmpty(Value))
            {
                MinTime();
                MaxTime();
            }
            else 
            {
                Value = "0";
            }
            SizeDay(Start, End);
            ValueDay(Start, End);
        }

        /// <summary>
        /// determiner le temps le plus petit dans les tache terminée
        /// </summary>
        public void MinTime()
        {
            DateTime minDate = DateTime.MaxValue;
            foreach (var item in _copyList)
            {
                if (item.EffectiveDateEnd < minDate && item.EffectiveDateEnd != default)
                {
                    minDate = item.EffectiveDateEnd;
                    Start = item.EffectiveDateEnd;
                }
            }

            if (Start == default)
            {
                Start = DateTime.Now;
            }

        }

        /// <summary>
        /// generer le maximum pour les taches terminée 
        /// </summary>
        public void MaxTime()
        {
            DateTime maxDate = DateTime.MinValue;
            foreach (var item in _copyList)
            {
                if (item.EffectiveDateEnd > maxDate && item.EffectiveDateEnd != default)
                {
                    maxDate = item.EffectiveDateEnd;
                    End = item.EffectiveDateEnd;
                }
            }

            if (End == default)
            {
                Start = DateTime.Now;
            }

        }
        #endregion

        /// <summary>
        /// va organiser les diff taskdans les distionnaire sous le nom de chaque chantier
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Task>> ExtractAssembly()
        {

            Dictionary<string, List<Task>> disctionnaire = new();

            foreach (var item in _copyList)
            {
                if (!disctionnaire.ContainsKey(item.Planning))
                {
                    List<Task> list = new();
                    list.Add(item);
                    disctionnaire.Add(item.Planning, list);
                }
                else
                {
                    disctionnaire[item.Planning].Add(item);
                }

            }
            Total(disctionnaire);
            return disctionnaire;
        }



        public void Total(Dictionary<string, List<Task>> disctionnaire)
        {

            foreach (var item in _copyList)
            {
                if (!disctionnaire.ContainsKey("Total"))
                {
                    List<Task> list = new();
                    list.Add(item);
                    disctionnaire.Add("Total", list);
                }
                else
                {
                    disctionnaire["Total"].Add(item);
                }

            }

        }


    }
}
