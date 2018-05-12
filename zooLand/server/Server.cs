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
        private SimpleDispatcher dispatcher;
        
        public void start(int port)
        {
            Console.WriteLine("Starting server...");
            _httpListener.Prefixes.Add("http://localhost:+"+ port +"/");
            _httpListener.Start();
           
            Thread _responseThread = new Thread(ResponseThread);
            _responseThread.Start();
            Console.WriteLine("Server start on port: " + port);            

            dispatcher =  new SimpleDispatcher(Router.getRouter());
        }

        private void ResponseThread()
        {
            
            while (true)
            {
                HttpListenerContext ctx = _httpListener.GetContext();
                if (ctx.Request.HttpMethod == "OPTIONS")
                {
                    ctx.Response.StatusCode = 200;
                    continue;    
                }
                
                Responce response = dispatcher.getResponce(ctx.Request);
                
                byte[] responseBody = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response.Body));
                ctx.Response.StatusCode = response.Status;
                
                ctx.Response.ContentType = "application/json"; 
                ctx.Response.AppendHeader("Access-Control-Allow-Origin", "*");
                
                ctx.Response.OutputStream.Write(responseBody, 0, responseBody.Length);
                ctx.Response.Close();
            }
        } 
    }
}