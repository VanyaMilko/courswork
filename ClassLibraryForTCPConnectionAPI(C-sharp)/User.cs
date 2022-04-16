using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForTCPConnectionAPI_C_sharp_
{
    public abstract class User : IEquatable<User>
    {
        virtual public int Id { get; set; }
        virtual public string Password { get; }
        virtual public string Login { get; }

        protected User() 
        {
            Id = 0;
            Login = "empty";
            Password = "empty";
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public bool Equals(User other)
        {
            return Id == other.Id && Password == other.Password && Login == other.Login;
        }

    }
}
