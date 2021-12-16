using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VINCENT.Nicolas.Poo.Tracker.Domains;

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
        public void UpdateView()
        {
            _repository.Update();
        }


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



        public void GenerateGraph(object sender, List<string> value) 
        {

            if (string.IsNullOrWhiteSpace(value[0]) && string.IsNullOrWhiteSpace(value[1]))
            {

            }



            Graph?.Invoke(this, value);
        }




    }
}
