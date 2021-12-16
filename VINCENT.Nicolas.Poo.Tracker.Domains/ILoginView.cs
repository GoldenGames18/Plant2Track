using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    public interface ILoginView : INotifyPropertyChanged
    {
        /// <summary>
        /// generer un nouveau login
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="mdps">mots de passe</param>
        /// <returns></returns>
        Login NewLogin(string code, string mdps);
        /// <summary>
        /// affecter un login 
        /// </summary>
        Login Last { get; }
    }

    






}
