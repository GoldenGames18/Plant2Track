using System;


namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    public class Commentary
    {

        private readonly string  _description;
        private readonly string _titel;
        private readonly DateTime _date;

        /// <summary>
        /// Constructeur de commentary
        /// </summary>
        /// <param name="titel"> titre du commentaire</param>
        /// <param name="description"> description du commentaire</param>
        public Commentary(string titel ,string description)
        {
            _titel = titel;
            _description = description;
            _date = DateTime.Now;
        
        }

        /// <summary>
        /// Renvoie le titre du commentaire
        /// </summary>
        public string Titel { get { return _titel; } }
        /// <summary>
        /// Renvoie la description du commentaire
        /// </summary>
        public string Description { get { return _description; } }
        /// <summary>
        /// Renvoie la date du commentaire
        /// </summary>
        public string DatePost { get { return _date.ToString("dd-MM-yy"); } }


        public override string ToString()
        {
            return string.Format("{0,-30}  {1,-15}  {2, -15}", Titel, Description, DatePost);
        }


        }
}
