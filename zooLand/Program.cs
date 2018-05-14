using ConsoleApplication1.DataBase;
using ConsoleApplication1.server;


namespace ConsoleApplication1

{
    
    internal class Program
    {   
        public static void Main(string[] args)
        {
            HttpServer httpServer = new HttpServer(Router.getRouter());
            DB.init();
            
            httpServer.start(3000);
        }
    }
}