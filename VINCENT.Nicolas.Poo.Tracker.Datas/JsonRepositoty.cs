using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Datas
{

    public class JsonRepositoty : IStorageFactory
    {

        
        public List<User> Users { get; set; }

        public List<Planning> Planning { get; set; }



        /// <summary>
        /// va aller chercher toute les taches dans chaque fichier
        /// </summary>
        /// <returns></returns>
        public void LoadPlanning()
        {
            List<Planning> plannings = new();

            string path = @"C:\temp\planningNicolasVincent";

            var file = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach(string value in file)
            {
                LoadAllPlanning(plannings, value);
            }
            foreach (Planning item in plannings)
            {
                foreach (var task in item.Tasks) {
                    task.Planning = item.Name;
                }
            }
            Planning = plannings;
            
        }

        /// <summary>
        /// va load chaque planning 
        /// </summary>
        /// <param name="plannings"> une liste de planning </param>
        /// <param name="path"> string le chemain de chaque fichier</param>
        public void LoadAllPlanning(List<Planning> plannings, string path) 
        {
            JsonSerializer serializer = new();

            using var streamReader = new StreamReader(path);
            using var jsonReader = new JsonTextReader(streamReader);
         
            var assembly = serializer.Deserialize<Planning>(jsonReader);
           
            plannings.Add(assembly);
        }

        
        /// <summary>
        /// va aller chercher tache de utilisateur connecter
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Task> TakeTaskUserConnected(string code)
        {
            List<Task> _task = new();
            LoadPlanning();
            foreach (var item in Planning) //to do edit futur
            {
                _task.AddRange(item.TakeTask(code));
            }
            return _task;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        public void WritePlanning(Task update) 
        {
            
            foreach (var item in Planning)
            {
                item.Update(update);
            }

            UpdateJson(Planning, update);
          


        }


        /// <summary>
        /// update des fichier json
        /// </summary>
        /// <param name="plannings"></param>
        public void UpdateJson(List<Planning> plannings, Task update) 
        {
            string path = @"c:\temp\planningNicolasVincent";

            foreach (var item in plannings)
            {

                if (update.Planning == item.Name)
                {
                   CreateJson(path + @"\" + item.Name + ".json", item);
                }
               
            }


        }

        /// <summary>
        /// ecriture dans le fichier json 
        /// </summary>
        /// <param name="planning"></param>
        /// <returns></returns>
        private JArray WritePlanning(Planning planning)
        {
            JArray arrayPlanning = new();

            foreach (var item in planning.Tasks)
            {
                CreateJsonObejt(arrayPlanning, item);
            }


            return arrayPlanning;
        }

        private static void CreateJsonObejt(JArray arrayPlanning, Task item)
        {
            JObject task = new();
            task.Add("description", item.Description);
            task.Add("code", item.Code);
            task.Add("dateStart", item.DateStart);
            task.Add("dateEnd", item.DateEnd);
            task.Add("EffectiveDateStrart", item.EffectiveDateStart.ToString("yyyy-MM-dd"));
            task.Add("EffectiveDateEnd", item.EffectiveDateEnd.ToString("yyyy-MM-dd"));
            arrayPlanning.Add(task);
        }

        /// <summary>
        /// faire update du json
        /// </summary>
        /// <param name="path"></param>
        /// <param name="planning"></param>
        private void CreateJson(string path, Planning planning) 
        {

            JObject assembly = new();
            assembly.Add("name", planning.Name);
            assembly.Add("planning", WritePlanning(planning));


            File.WriteAllText(path, assembly.ToString());
            using StreamWriter file = File.CreateText(path);
            using JsonTextWriter writer = new(file);
            assembly.WriteTo(writer);
        }


        /// <summary>
        /// va aller cherger tous le fichier json de chaque user
        /// </summary>
        /// <returns></returns>
        public List<User> LoadUser()
        {


            string path =@"..\..\..\..\VINCENT.Nicolas.Poo.Tracker.Datas\DataUsers\User.json";
           

            JsonSerializer serializer = new();
            using var streamReader = new StreamReader(path);
            using var jsonReader = new JsonTextReader(streamReader);

            var users = serializer.Deserialize<List<User>>(jsonReader);

            Users = users;


            return users;

        }
    }
}
