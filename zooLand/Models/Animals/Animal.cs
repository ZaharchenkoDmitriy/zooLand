using System;
using System.ComponentModel;
using ConsoleApplication1.DataBase;

namespace ConsoleApplication1.server
{
    public class Animal : Consuming
    {
        public string Name { get; set; }
        public string FeedDate { get; set; }
        public string AnimalClass { get; set; }
        private bool hungry;

        public bool Hungry
        {
            get { return hungry; }
            set
            {
                hungry = value;
                calculateFeedDate();
            }
        }

        public int ID { get; set; }

        public Animal()
        {
            FeedDate = DateFormatter.getCurrentDate();
            Hungry = true;
        }

        public virtual void calculateFeedDate()
        {
         return;   
        }
    }
}