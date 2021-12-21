using System;
using System.ComponentModel;



namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    public class LoginFactory : ILoginView
    {
        /// <summary>
        /// affecter un login 
        /// </summary>
        public Login Last { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// generer un nouveau login
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="mdps">mots de passe</param>
        /// <returns></returns>
        public Login NewLogin(string code, string mdps)
        {
            Last = new Login(code, mdps);
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Last)));
            return Last;

        }
    }
}
