using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGserver.Global
{
        //Command from client to server
        interface ICommand
        {
            void Execute();
        }

        #region map

        interface IMap
        {
            void Generate(int sizeX, int sizeY);
        }

        #endregion

        #region user

        interface IUser
        {
            void Disconnect();
        }
        
        #endregion
    
}
