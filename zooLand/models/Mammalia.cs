using System;

namespace ConsoleApplication1.server
{
    public abstract class Mammalia : Animal
    {
        public String FoodType { get; set; }
        
        public abstract void feed();
    }
}