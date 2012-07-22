using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGserver.Users
{
    class UserManager
    {
        private List<User> Users = new List<User>();

        private static readonly UserManager instance = new UserManager();

        //Important not remove
        static UserManager()
        {
        
        }
        //important not remove
        UserManager()
        {
        }
        public static UserManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void AddUser(User userToAdd)
        {
            if(!Users.Contains(userToAdd))
            {
                Users.Add(userToAdd);
            }
        }

        public void RemoveUser(User userToRemove)
        {
            Users.Remove(userToRemove);
            userToRemove.Disconnect();
        }
    }
}
