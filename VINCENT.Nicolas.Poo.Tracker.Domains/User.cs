using System;


namespace VINCENT.Nicolas.Poo.Tracker.Domains
{

    /**
     * idée 
     * en cas de bcp utilsateur utiliser une collection avec clef et puis juste regarder si la clef existe bien dans la collection exemple hashMap; 
     */
    public class User
    {
        private string _name;
        private string _firstName;


        private Login _login;
        /// <summary>
        /// Constructeur login
        /// </summary>
        /// <param name="_login">Login qui possède son login et mots de passe</param>
        /// <param name="_name">nom  utilsiateur </param>
        /// <param name="_firstName">prenom </param>
        public User(Login _login, string _name = "", string _firstName = "")
        {
            this._login = _login;
            this._name = _name;
            this._firstName = _firstName;

        }
      
        /// <summary>
        /// getter et setter de name
        /// </summary>
        public string Name { get { return this._name; } set { this._name = value; } }
        /// <summary>
        ///  getter et setter de Fistname
        /// </summary>
        public string FirstName { get { return this._firstName; } set { this._firstName = value; } }

        /// <summary>
        /// getter de l'objet login
        /// </summary>
        public Login Login { get { return _login;} }

    }
}
