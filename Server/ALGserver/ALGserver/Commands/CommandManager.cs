using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGserver.Commands
{
    public class CommandManager
    {
         private static readonly CommandManager instance = new CommandManager();

        //Important not remove
        static CommandManager()
        {
        
        }
        //important not remove
        CommandManager()
        {
        }
        public static CommandManager Instance
        {
            get
            {
                return instance;
            }
        }

        public Command Parse(string Message)
        {
            return new EmptyCommand();
        }
    }
}
