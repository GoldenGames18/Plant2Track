using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Datas
{
    public class JsonRepositoty
    {
      
        /// <summary>
        /// va aller chercher toute les taches dans chaque fichier
        /// </summary>
        /// <returns></returns>
        public List<Planning> LoadPlanning()
        {
            List<Planning> plannings = new();

            string path = @"c:\temp";

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
            return plannings;
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
            foreach (var item in LoadPlanning())
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
        public List<Planning> SaveData(Task update) 
        {
            List<Planning> plannings = LoadPlanning();
            foreach (var item in plannings)
            {
                item.Update(update);
            }

            UpdateJson(plannings, update);
            return plannings;
        


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
                JObject task = new();
                task.Add("description", item.Description);
                task.Add("code", item.Code);
                task.Add("dateStart", item.DateStart);
                task.Add("dateEnd", item.DateEnd);
                task.Add("EffectiveDateStrart", item.EffectiveDateStart.ToString("yyyy-MM-dd"));
                task.Add("EffectiveDateEnd", item.EffectiveDateEnd.ToString("yyyy-MM-dd"));
                arrayPlanning.Add(task);
            }


            return arrayPlanning;
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

        
    }
}
