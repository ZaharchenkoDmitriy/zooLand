using System;
using System.Net;
using ConsoleApplication1.server;

namespace ConsoleApplication1.Controllers
{
    public class NoController
    {
        public Responce noController(HttpListenerRequest request)
        {
            return Responce.notFound();
        }
    }
}