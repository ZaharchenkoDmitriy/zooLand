﻿using System;
using ConsoleApplication1.Controllers;
using ConsoleApplication1.server;


namespace ConsoleApplication1

{
    
    internal class Program
    {   
        public static void Main(string[] args)
        {
            HttpServer httpServer = new HttpServer(Router.getRouter());
            
            httpServer.start(3000);
        }
    }
}