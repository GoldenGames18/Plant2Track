using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Datas
{
    interface IStorageFactory
    {
        public void LoadPlanning();

        public List<Task> TakeTaskUserConnected(string code);

        public void WritePlanning(Task update);

        public List<User> LoadUser();

    }
}
