using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALGserver.Global;
using ALGserver.Users;

namespace ALGserver.Commands
{
    public class Command:ICommand
    {
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
        
    }

    public class CommandObjectParams
    {
        private List<Object> _paramsList = new List<object>();
 
        public void Add(Object param)
        {
            _paramsList.Add(param);
        }

        public Object Get(int index)
        {
            if (_paramsList[index] != null)
                return _paramsList[index];
            else
                return null;
        }
    }

    public class EmptyCommand : Command
    {
        public const string CommandName = "";

        public EmptyCommand(List<string> stringCommandParameters, CommandObjectParams referencedObjects)
        {
            //no parameters
        }

        public override void Execute()
        {
            //Do nothing
        }
    }

    public class Login:Command
    {
        public const string CommandName = "Login";

        private string _username;

        private User _user;

        public Login(List<string> stringCommandParameters, CommandObjectParams referencedObjects)
        {
            _username = stringCommandParameters[0];
            _user = (User)referencedObjects.Get(0);
        }

        public override void Execute()
        {
            UserManager.Instance.AddUser(_user);
        }

    }
}
