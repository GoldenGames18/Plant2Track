﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VINCENT.Nicolas.Poo.Tracker.Datas;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Controllers
{

    public class LoginControlleur
    {
        
        private readonly Func<string, string, Login>  _login;


        private readonly JsonRepositoty _json;

        public event EventHandler AboutToQuit;
        public event EventHandler<Login> LoginRequested;

        /// <summary>
        /// Constructeur de notre supperviseur
        /// </summary>
        /// <param name="loginView"></param>
        public LoginControlleur( Func<string, string, Login> login, JsonRepositoty json)
        {
            _login = login;
            _json = json;
        }


        #region CONNEXION SYSTEME 

        /*************************************************(Système de connection)****************************************************/
        /// <summary>
        /// verification de connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="login"></param>
        public void VerifyConnection(object sender, Login login)
        {

                if (!login.ListMumber(_json.Users)) return;
                NotifyPlayerIsConnected(NewLogin(login.Code, login.Mdps));
            
 
        }

        private Login NewLogin(string code, string mdps) => _login.Invoke(code, mdps);
        

        private void NotifyPlayerIsConnected(Login login) => LoginRequested?.Invoke(this, login);

       





        /*****************************************************************************************************************************/

        #endregion


        #region CLOSE PROGRAME
        /*************************************************(FERMETURE DU PROGRAMME)****************************************************/

        /// <summary>
        /// permet la fermeture de la view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnQuitRequested(object sender, EventArgs e)
        {
            NotifyAboutQuitting();
        }

        /// <summary>
        /// Permet de quitter event en cours cours
        /// </summary>
        private void NotifyAboutQuitting() => AboutToQuit?.Invoke(this, EventArgs.Empty);


        /*****************************************************************************************************************************/

        #endregion


    }
}
