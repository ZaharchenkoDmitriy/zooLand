using ConsoleApplication1.DataBase;
using ConsoleApplication1.server;
using ConsoleApplication1.Telegram;


namespace ConsoleApplication1

{
    
    internal class Program
    {   
        public static void Main(string[] args)
        {
            TelegramConnector telegramConnector = new TelegramConnector();
            telegramConnector.connect();
           
            /*HttpServer httpServer = new HttpServer(Router.getRouter());
            DB.init();
            
            httpServer.start(3000);*/
        }
    }
}