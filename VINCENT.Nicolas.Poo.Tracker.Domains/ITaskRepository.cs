using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    public interface ITaskRepository : IEnumerable<Task>, INotifyCollectionChanged
    {
        /// <summary>
        /// update de la view
        /// </summary>
        void Update();
        /// <summary>
        /// update des task dans assembly
        /// </summary>
        /// <param name="task"></param>
        void Update(Task task);
        /// <summary>
        /// trie par ordre des date
        /// </summary>
        void SortDate();
        /// <summary>
        /// ordre décroisant statut
        /// </summary>
        void ReverseStatu();
        /// <summary>
        /// ordre croisant statu
        /// </summary>
        void SortStatu();
        /// <summary>
        /// ordre décroisant site
        /// </summary>
        void ReverseSite();
        /// <summary>
        /// ordre croisant  site
        /// </summary>
        void SortSite();
        /// <summary>
        /// filtrer par statut 
        /// </summary>
        /// <param name="statut">donner de filtre</param>
        void FindStatut(string statut);
        // <summary>
        /// filtrer sur le nom du planning
        /// </summary>
        /// <param name="name"> nom du planning</param>
        void FindSite(string name);
        /// <summary>
        /// filter sur les date
        /// </summary>
        /// <param name="date"> date donne par utilisateur</param>
        void FindDate(string date);
        /// <summary>
        /// supprimer tous les filtres
        /// </summary>
        void ResetFilter();

        /// <summary>
        ///  ordre croisant date de début
        /// </summary>
        void SortDateStart();
        /// <summary>
        /// ordre décroisant date de début
        /// </summary>
        void ReverseDateStart();



        /// <summary>
        /// generation du graphique 
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <param name="v"></param>
        void CreateGraph(DateTime start, DateTime end, string type);


        public double[] TabValue { get; set; }
        public double[] TabIndex { get; set; }


        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string  Value { get; set; }

        public Dictionary<string, List<Task>> ExtractAssembly();

    }
}
