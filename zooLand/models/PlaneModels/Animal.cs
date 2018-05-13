using System;
using System.ComponentModel;

namespace ConsoleApplication1.server
{
    public abstract class Animal : Consuming
    {
        public string Name { get; set; }
        public string FeedDate { get; set; }
        public string AnimalClass { get; set; }
        public bool Hungry { get; set; }

        public Animal()
        {
            FeedDate = DateTime.Now.Year +"-"+ DateTime.Now.Month + "-" + DateTime.Now.Day;
            Hungry = true;
        }
        
        public abstract void calculateFeedDate();
    }
}