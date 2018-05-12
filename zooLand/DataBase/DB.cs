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
    }
}