using System;
using System.Net;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.server;

namespace ConsoleApplication1.Controllers
{
    public class AnimalsController
    {
        public Responce getAnimals(HttpListenerRequest request)
        {
            foreach (Consuming animal in DB.animals)
            {
                animal.calculateFeedDate();
            }

            return Responce.ok(DB.getAnimals());
        }
    }
}