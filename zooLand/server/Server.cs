using System;
using System.IO;
using System.Net;using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace ConsoleApplication1.server
{
    public class HttpServer
    {
        
        public HttpServer(Router router)
        {
            this.router = router;
        }
        
        HttpListener _httpListener = new HttpListener();
        private Router router;

        public void start(int port)
        {
            Console.WriteLine("Starting server...");
            _httpListener.Prefixes.Add("http://localhost:+"+ port +"/");
            _httpListener.Start();
           
            Thread _responseThread = new Thread(ResponseThread);
            _responseThread.Start();
            Console.WriteLine("Server start on port: " + port);
        }

        private void ResponseThread()
        {
            
            while (true)
            {
                HttpListenerContext ctx = _httpListener.GetContext();
                SimpleDispatcher simpleDispatcher = new SimpleDispatcher(Router.getRouter());
                
                Object responseObject = simpleDispatcher.getResponce(ctx.Request).Body;
                byte[] response = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(responseObject));
                
                ctx.Response.ContentType = "application/json"; 
                ctx.Response.AppendHeader("Access-Control-Allow-Origin", "*");
                ctx.Response.OutputStream.Write(response, 0, response.Length);
                ctx.Response.Close();
            }
        } 
    }
}