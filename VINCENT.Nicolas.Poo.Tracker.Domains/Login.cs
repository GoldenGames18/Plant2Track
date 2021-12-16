using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VINCENT.Nicolas.Poo.Tracker.Domains
{
    public class Login
    {
        readonly string _code, _mdps;
        /// <summary>
        /// Constructeur de object Login
        /// </summary>
        /// <param name="code">Code de utilsateur</param>
        /// <param name="mdps">mots de passe utilsateur</param>
        public Login(string code,string mdps)
        {
            _code = code;
            _mdps = mdps;
        }
        /// <summary>
        /// getter Code
        /// </summary>
        public string Code { get { return _code; } }
        /// <summary>
        /// getter du mots de passe
        /// </summary>
        public string Mdps { get { return _mdps; } }

        /// <summary>
        /// Cette méthode va vérifier si le login et mots de passe donner sont bien présent dans la liste des utilsateur
        /// </summary>
        /// <param name="allUsers">List de tous les utilsateur</param>
        /// <returns></returns>
        public bool ListMumber(IList<User> allUsers) {


            WitheSpaceCode();
            WitheSpaceMdps();

            foreach (User item in allUsers)
            {
                if (this.Equals(item.Login))
                        return true;
                }
            throw new Exception("Authentification échouée");

            
            



        }

        /// <summary>
        /// va regarder si le le mots de passe ets vide
        /// </summary>
        /// <returns></returns>
        public bool WitheSpaceMdps() {
            if (string.IsNullOrWhiteSpace(_mdps))
            {
                throw new Exception("Mots de passe est vide");
            }
            return false;
        }
        /// <summary>
        /// code est blanc 
        /// </summary>
        /// <returns>exeption si il ets blanc</returns>
        public bool WitheSpaceCode()
        {
            if (string.IsNullOrEmpty(_code))
            {
                throw new Exception("Le code est vide");            
            }
            return false;
        }



        /// <summary>
        /// Redefinition de Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Login login &&
                   _code == login.Code &&
                   _mdps == login.Mdps;
        }
        /// <summary>
        /// Redefinition du HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_code, _mdps, Code, Mdps);
        }
    }
}
