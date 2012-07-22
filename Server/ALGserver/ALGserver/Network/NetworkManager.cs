using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ALGserver.Global;
using ALGserver.Users;

namespace ALGserver
{
    class NetworkManager
    {
        private static readonly NetworkManager instance = new NetworkManager();

        //Important not remove
        static NetworkManager()
        {
        // Определим нужное максимальное количество потоков
               // Пусть будет по 100 на каждый процессор
               int maxThreadsCount = Environment.ProcessorCount * Settings.NetworkManagerNumberOfThreads;
               // Установим максимальное количество рабочих потоков
               ThreadPool.SetMaxThreads(maxThreadsCount, maxThreadsCount);
               // Установим минимальное количество рабочих потоков
               ThreadPool.SetMinThreads(2, 2);
               
        }
        //important not remove
        NetworkManager()
        {
        }
        public static NetworkManager Instance
        {
            get
            {
                return instance;
            }
        }

        private Thread thread;
       
        TcpListener Listener; // Объект, принимающий TCP-клиентов


        public bool Start()
        {
            Listener = new TcpListener(IPAddress.Any, Settings.Port); // Создаем "слушателя" для указанного порта
            Listener.Start(); // Запускаем его


            ThreadStart ts = new ThreadStart(_main);
            thread = new Thread(ts);
            thread.Start();
            return true;

        }

        private void _main()
        {
            // В бесконечном цикле
            while (true)
            {
                // Принимаем новых клиентов. После того, как клиент был принят, он передается в новый поток (ClientThread)
                // с  использованием пула потоков.
                ThreadPool.QueueUserWorkItem(new WaitCallback(ClientThread), Listener.AcceptTcpClient());
            }
        }

        static void ClientThread(Object StateInfo)
        {
            // Просто создаем новый экземпляр класса Client и передаем ему приведенный к классу TcpClient объект StateInfo
            new User((TcpClient)StateInfo);
        }

        public bool Stop()
        {
            thread.Abort();
            Listener.Stop();
            return true;
        }


    }
}
