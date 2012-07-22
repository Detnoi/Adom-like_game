using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALGserver.Global;

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

        public Command Parse(string message, CommandObjectParams referencedObjects )
        {
            string commandName = string.Empty;
            List<string> comandParams = new List<string>();
            string tmpParceCommand = string.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                if(message[i]==Settings.RequestLineBreakerChar)
                {
                    if(commandName==string.Empty)
                    {
                        commandName = tmpParceCommand;
                    }
                    else
                    {
                        comandParams.Add(tmpParceCommand);
                    }

                    tmpParceCommand = string.Empty;
                    continue;
                }
                else
                {
                    tmpParceCommand += message[i];
                }
            }

            switch (commandName)
            {
                default:
                    {
                        return new EmptyCommand(comandParams, referencedObjects);
                    }
            }
        }
    }
}
