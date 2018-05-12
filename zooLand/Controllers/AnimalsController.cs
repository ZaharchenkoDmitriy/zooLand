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
            Lion lion = new Lion();
            lion.Name = "Lion grisha";
            lion.FoodType = "Meat";
            DB.animals.Add(lion);
            
            return Responce.ok(DB.getAnimals());
        }
    }
}