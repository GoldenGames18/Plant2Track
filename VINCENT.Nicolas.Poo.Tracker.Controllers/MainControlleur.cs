using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Domains;

#nullable disable
namespace VINCENT.Nicolas.Poo.Tracker.Controllers
{
    public class MainControlleur
    {
        public event EventHandler<List<string>> Filter;
        public event EventHandler<List<string>> Graph;
        
        private readonly ITaskRepository _repository;


        

        public MainControlleur(ITaskRepository repository)
        {
            _repository = repository;
            UpdateView();

        }
        /// <summary>
        /// update de la view
        /// </summary>
        public void UpdateView()
        {
            _repository.Update();
        }

        #region FilterAplication

        /// <summary>
        /// creation des filtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"> collection de string pour les filtres</param>
        public void Affect(object sender,  List<string> value)
        {

            if (value[1] == "0")
            {
                _repository.ResetFilter();
            }
            else if (value[1] == "1")
            {
                Statut(value);
            }
            else if (value[1] == "2")
            {
                Site(value);
            }
            else if (value[1] == "3")
            {
                Date(value);
            }

            UpdateView(value);

        }

        private void UpdateView(List<string> value)
        {
            SortDate(value);
            Filter?.Invoke(this, value);
            _repository.Update();
        }

        private void SortDate(List<string> value)
        {
            if (value[0] == "0")
            {
                _repository.SortDate();
            }
        }

        private void Statut(List<string> value)
        {
            if (value[0] == "1")
            {
                _repository.SortStatu();
            }
            else if (value[0] == "2")
            {
                _repository.ReverseStatu();
            }
            if (!string.IsNullOrEmpty(value[2]))
            {
                _repository.FindStatut(value[2]);
            }
        }

        private void Site(List<string> value)
        {
            if (value[0] == "1")
            {
                _repository.SortSite();
            }
            else if (value[0] == "2")
            {
                _repository.ReverseSite();
            }
            if (!string.IsNullOrEmpty(value[2]))
            {
                _repository.FindSite(value[2]);
            }
        }

        private void Date(List<string> value)
        {
            if (value[0] == "1")
            {
                _repository.SortDateStart();
            }
            else if (value[0] == "2")
            {
                _repository.ReverseDateStart();
            }
            if (!string.IsNullOrEmpty(value[2]))
            {
                _repository.FindDate(value[2]);
            }
        }

        #endregion

        /// <summary>
        /// generation du fitre pour le graphic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        public void GenerateGraph(object sender, List<string> value) 
        {

            if (DateTime.Parse(value[0]) > DateTime.Parse(value[1]))
            {
                throw new Exception("La Date de début est plus grande que la date de fin");
            }
            else
            {
                _repository.CreateGraph(DateTime.Parse(value[0]), DateTime.Parse(value[1]), value[2]);

                UpdateView();
                Graph?.Invoke(this, value);
            }

            
        }




    }
}
