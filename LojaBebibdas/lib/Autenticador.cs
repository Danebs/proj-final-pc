using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaBebibdas.data;
using LojaDeBebidas.data.entidades;

namespace LojaBebibdas.lib
{
    class Autenticador : UserModel
    {
        protected User UserSession;

        public bool AuthUser(string login, string password)
        {
            UserModel UserModel = new UserModel();

            User user = UserModel.FindByName(login);

            if (user != null && user.ValidatePassword(password)) { 
                this.UserSession = user;
                return true;
            } else { 
                return false;
            }

        }

    }
}
