using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALGserver.Global
{
    public static class Settings
    {
        public static int Port = 8020;

        public static int MaxUsers = 100;

        public static int NetworkManagerNumberOfThreads = 100;

        public static int MaxRequestLength = 4096;

        public static char RequestLineBreakerChar = '*';

    }
}
