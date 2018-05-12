using System;
using System.Net;
using ConsoleApplication1.server;

namespace ConsoleApplication1.Controllers
{
    public class AnimalsController
    {
        public Responce getLion(HttpListenerRequest request)
        {
            Lion lion = new Lion();
            lion.Name = "Lion grisha";
            lion.FoodType = "Meat";
            
            return Responce.ok(lion);
        }
    }
}