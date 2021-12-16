using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Datas
{
    public class AllData
    {
        private readonly List<User> _allUsers = new();
        private readonly List<Planning> _allPlanning = new();
        private readonly List<Task> _taskList = new();
        private Login _code1, _code2, _code3, _code4, _code5;
        private User _user1,_user2,user3,_user4,_user5;
        private Task _task1, _task2, _task3, _task4, _task5, _task6, _task7, _task8, _task9, _task10, _task11, _task12;
        private Planning _helmo, _mariage; 
        public List<User> AllUsers()
        {
            AffecteDateUser();
            _allUsers.Add(_user5);
            _allUsers.Add(_user4);
            _allUsers.Add(user3);
            _allUsers.Add(_user2);
            _allUsers.Add(_user1);
            return _allUsers;
        }

        public List<Planning> GeneratePlanning()
        {
            CreatePlanning();
            _allPlanning.Add(_mariage);
            _allPlanning.Add(_helmo);
            return _allPlanning;
        }


        private void AffecteLogin() 
        {

            _code1 = new Login("D007", "DaniBond");
            _code2 = new Login("G021", "GretaRulez");
            _code3 = new Login("H042", "H2G2");
            _code4 = new Login("F004", "OktoberFest");
            _code5 = new Login("S010", "HELMo");
        }

        public object TakeTaskUserConnected(object code)
        {
            throw new NotImplementedException();
        }

        private void AffecteDateUser()
        {
            AffecteLogin();
            _user1 = new(_code1, "Bond", "Dani");
            _user2 = new(_code2, "Thumberg", "Greta");
            user3 = new(_code3, "Hendrikx", "Nicolas");
            _user4 = new(_code4, "Muller", "Gerard");
            _user5 = new(_code5, "Lamy", "Simon");
        }




        private void AffactDateTask()
        {
            _task1 = new Task("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021,09,06), new DateTime(2021, 09, 01), new DateTime(2021, 09, 06));
            _task2 = new Task("Installer eau", "G021", new DateTime(2021, 09, 01), new DateTime(2021, 09, 05), new DateTime(2021, 09, 01) );
            _task3 = new Task("Monter scène", "H042", new DateTime(2021, 09, 07), new DateTime(2021, 09, 10));
            _task4 = new Task("Monter bar", "H042", new DateTime(2021, 09, 06), new DateTime(2021, 09, 11));
            _task5 = new Task("Installer eclairage", "D007", new DateTime(2021, 09, 11), new DateTime(2021, 09, 15));
            _task6 = new Task("Valider electricité et hygiène", "F004", new DateTime(2021, 09, 12), new DateTime(2021, 09, 17));
            _task7 = new Task("Répéter les concerts", "S010", new DateTime(2021, 09, 18), new DateTime(2021, 09, 21));
           
            _task8 = new Task("Monter tonnelle", "H042", new DateTime(2021, 09, 05), new DateTime(2021, 09, 06), new DateTime(2021, 09, 06), new DateTime(2021, 09, 08));
            _task9 = new Task("Installer électricité", "D007", new DateTime(2021, 09, 05), new DateTime(2021, 09, 07), new DateTime(2021, 09, 05), new DateTime(2021, 09, 06));
            _task10 = new Task("Monter scène", "H042", new DateTime(2021, 09, 08), new DateTime(2021, 09, 09));
            _task11 = new Task("Installer éclairage", "D007", new DateTime(2021, 09, 08), new DateTime(2021, 09, 09));
            _task12 = new Task("Tester avec DJ", "S010", new DateTime(2021, 09, 10), new DateTime(2021, 09, 10));

            
        
        }

        public void CreatePlanning()
        {
            AffactDateTask();
            _helmo = new Planning("HELMo - Garden Party", _task1, _task2, _task3, _task4, _task5, _task6, _task7);
            foreach (var item in _helmo.Tasks)
            {
                item.Planning = _helmo.Name;
            }
            _mariage = new Planning("Mariage Claudy et Claudette", _task8, _task9, _task10, _task11, _task12);
            foreach (var item in _mariage.Tasks)
            {
                item.Planning = _mariage.Name;
            }

        }



        public List<Task> TakeTaskUserConnected(string code)
        {
            GeneratePlanning();
            foreach (var item in _allPlanning)
            {
                _taskList.AddRange(item.TakeTask(code));
            }

            return _taskList;
        }

        
    }
}
