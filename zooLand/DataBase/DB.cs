using System.Collections;
using System.Runtime.CompilerServices;
using ConsoleApplication1.server;

namespace ConsoleApplication1.DataBase
{
    public static class DB
    {
        public static ArrayList animals = new ArrayList();
        public static ArrayList users = new ArrayList();

        public static Animal[] getAnimals()
        {
            Animal[] animalsArr = (Animal[]) animals.ToArray(typeof(Animal));
            return animalsArr;
        }

        public static void init()
        {
            
            Lion lion = new Lion();
            lion.Name = "Lion grisha";
            lion.FeedDate = "2018-05-05";
            animals.Add(lion);
            
            Bear bear = new Bear();
            bear.Name = "Misha";
            bear.FeedDate = "2018-05-05";
            animals.Add(bear);
        }
    }
}