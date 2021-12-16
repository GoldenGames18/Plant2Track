using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{

    /// <summary>
    /// enumerateur des statut de tache
    /// </summary>
    public enum StatutTask
    {
        Terminee = 1,
        AFaire =2,
        EnCours = 3
    }
    public class Task
    {
        private  string  _description, _code, _planningName ;
        private DateTime _dateEnd, _dateStart, _EffectiveDateEnd, _EffectiveDateStrart;
       


        /// <summary>
        /// Constructeur de Object task
        /// </summary>
        /// <param name="description">description de la task</param>
        /// <param name="code">code de utilisateur qui doit réaliser la task</param>
        /// <param name="dateStart">date de début de la task</param>
        /// <param name="dateEnd">date de fin de la task </param>
        /// <param name="EffectiveDateStrart">date de début officiel</param>
        /// <param name="EffectiveDateEnd">date de finn officiel</param>
        public Task(string description, string code, DateTime dateStart, DateTime dateEnd, DateTime EffectiveDateStrart = default, DateTime EffectiveDateEnd = default)
        {
            _description = description;
            _code = code;
            _dateEnd = dateEnd;
            _dateStart = dateStart;
            _EffectiveDateEnd = EffectiveDateEnd;
            _EffectiveDateStrart = EffectiveDateStrart;
        }

        


        /// <summary>
        /// Méthode qui va calculer les jour de retard du chantier
        /// </summary>
        /// <returns>un nombre qui correspond on nombre de jour de chantier de retard</returns>
        public int DelayTime()
        { 
            if (_EffectiveDateEnd != default)
            {
                TimeSpan delay = _EffectiveDateEnd - _dateEnd;
                return Convert.ToInt32(delay.Days) <0 ? 0 : Convert.ToInt32(delay.Days);
            }
            else
            {
                DateTime toDay = DateTime.Today;
                TimeSpan delay = toDay - _dateEnd;
                return Convert.ToInt32(delay.Days)  < 0  ? 0 : Convert.ToInt32(delay.Days);
            }
            
        }
        /// <summary>
        /// méthode qui va genere le statu de la tache 
        /// </summary>
        /// <returns>string "À faire" si les deux date effective sont default ou  "Terminée" </returns>s
        public StatutTask GenerateStatut()
        {

            if (_EffectiveDateStrart == default && _EffectiveDateEnd == default)
            {
                return StatutTask.AFaire;
            }
            else if (_EffectiveDateStrart != default && _EffectiveDateEnd != default)
            {
                return StatutTask.Terminee;
            }
            else
            {
                return StatutTask.EnCours;
            }
        }
        /// <summary>
        /// Permet de contatener les date effective 
        /// </summary>
        /// <returns>return Indéfinies si les date sont default  </returns>
        public string EffectiveDate()
        {
            return _EffectiveDateStrart == default || _EffectiveDateEnd == default ? 
                "Indéfinies" :
                _EffectiveDateStrart.ToString("yyyy-MM-dd") + " " + _EffectiveDateEnd.ToString("yyyy-MM-dd");
        }


        /// <summary>
        /// Cette méthode va renvoyer le statut de notre task
        /// </summary>
        public string Statut { 
            get 
            {
                StatutTask save = GenerateStatut();
                string value = "";
                if (save.Equals(StatutTask.EnCours))
                {
                    value = "En cours";
                }
                else if (save.Equals(StatutTask.AFaire))
                {
                    value = "À faire";
                }
                else if (save.Equals(StatutTask.Terminee))
                {
                    value = "Terminée";
                }
                return value;

            } 
        }
        /// <summary>
        /// Cette méthode va renvoyer la description de notre task ou soit changer la description 
        /// </summary>
        public string Description { get{return _description;} set{ _description = value; }}
        /// <summary>
        /// Cette méthode va renvoyer le code de utilsateur qui doit réaliser cette task
        /// </summary>
        public string Code { get { return _code; } }

        /// <summary>
        /// Cette méthode va renvoyer la date de fin de la task en format string
        /// </summary>
        public string DateEnd { get { return _dateEnd.ToString("yyyy-MM-dd"); } }
        /// <summary>
        /// Cette méthode va renvoyer la date de début de la task en format string
        /// </summary>
        public string DateStart { get { return _dateStart.ToString("yyyy-MM-dd"); } }

     

        /// <summary>
        /// renvoie la date de debut effective
        /// </summary>
        public DateTime EffectiveDateStart { get { return _EffectiveDateStrart; } } //.ToString("yyyy-MM-dd");

        /// <summary>
        /// renvoie la date de fin effective
        /// </summary>
        public DateTime EffectiveDateEnd { get { return _EffectiveDateEnd; } } //ToString("yyyy-MM-dd")


        public string Planning { get { return _planningName; } set { _planningName = value; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plannings">List des diff planning</param>
        /// <returns></returns>
        public string GetSite(List<Planning> plannings)
        {
            foreach (Planning item in plannings)
            {
                if (item.GiveNamePojectByTask(this) != null)
                    return item.Name;
            }

            return null;
        }



        /// <summary>
        /// Cette méthode va renvoyer une concatenation de toute les infoamtion d'une task
        /// </summary>
        /// <returns>String avec toutes les inforamtion d'une task</returns>
        public override string ToString() {

            return string.Format("| {0,-30} | {1,-15}  {2,15} | {3,-20} | {4,-35} | {5,-20}",
                Description,
                DateStart,
                DateEnd,
                Statut,
                EffectiveDate(),
               DelayTime()
                ) ;

        }


        /// <summary>
        /// Permet ajouter la date auj 
        /// </summary>
        public void AffectDateStart() 
        {
            _EffectiveDateStrart = DateTime.Now;
        }

        /// <summary>
        /// permet d'ajouter la date auj fin de la tache
        /// </summary>
        public void AffectDateEnd()
        {
            _EffectiveDateEnd = DateTime.Now;
        }

        /// <summary>
        /// permet de mettre à jour une task par rapport à sa description/ chantier/ date de start et date de fain
        /// </summary>
        /// <param name="task"> la taches à mettre à jour </param>
        /// <returns></returns>
        public bool Update(Task task) 
        {
            return _description == task.Description && Planning == task.Planning && DateStart == DateStart && DateEnd == DateEnd;
        }
        

        

    }



}
