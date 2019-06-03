using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaBebibdas.data;
using System.Xml;
using System.Xml.Linq;

namespace LojaBebibdas.lib
{
    class User
    {
        public static List<UserModel> Get_Users()
        {
     
            List <UserModel> Users = new List <UserModel>();

            XElement xml = XElement.Load(@"/../data/xml/Users.xml");

            foreach (XElement x in xml.Elements())
            {
                UserModel user = new UserModel(int.Parse(x.Attribute("codigo").Value), x.Attribute("nome").Value, x.Attribute("telefone").Value);
                Users.Add(user);
            }

            return Users;
        }
    }
}
