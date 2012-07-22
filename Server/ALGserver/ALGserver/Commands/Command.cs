using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALGserver.Global;

namespace ALGserver.Commands
{
    public class Command:ICommand
    {
        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class EmptyCommand : Command
    {
        public override void Execute()
        {
            //Do nothing
        }
    }
}
