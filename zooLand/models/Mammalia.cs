using System;

namespace ConsoleApplication1.server
{
    public abstract class Mammalia : Animal
    {
        public String FoodType { get; set; }
        public String Name { get; set; }
        
        public abstract override void feed();
    }
}