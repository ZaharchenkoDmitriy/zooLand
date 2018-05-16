using System;
using System.Threading;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.server;


namespace ConsoleApplication1

{
    
    internal class Program
    {   
        public static void Main(string[] args)
        {
            TelegramConnector telegramConnector = new TelegramConnector();
            HttpServer httpServer = new HttpServer(Router.getRouter());

            DB.init();
            
            telegramConnector.sendMessagesToStuff();   
            httpServer.start(3000);
            
            while (true)
            {
                foreach (Animal animal in DB.animals)
                {
                    animal.calculateFeedDate();
                }
                telegramConnector.sendMessagesToStuff();
                Thread.Sleep(86400000);
            }
        }
    }
}