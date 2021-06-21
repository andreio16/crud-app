using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.BusinessLogic
{
    public class User
    {
        public int UserId;
        public string UserName;
        public string LastName;
        public string FirstName;
        public string Password;

        public User()
        {

        }

        public User(int id, string userName, string firstName, string lastName)
        {
            UserId = id;
            UserName  = userName;
            LastName  = lastName;
            FirstName = firstName;
        }

        public User(string userName, string firstName, string lastName, string password)
        {
            UserName = userName;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
        }
    }

    public class Admin
    {
        public int AdminId;
        public string AdminName;

        public Admin(int id, string name)
        {
            AdminId = id;
            AdminName = name;
        }

    }
}
