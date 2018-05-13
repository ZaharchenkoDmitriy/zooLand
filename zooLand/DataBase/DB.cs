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

        public static void createUser(User user)
        {
            if(users.Count != 0) 
            {
                User lastUser = (User)users[users.Count - 1];
                user.ID = lastUser.ID + 1;
            }
            else
            {
                user.ID = 1;
            }

            users.Add(user);
        }
        public static void init()
        {
            
            Lion lion = new Lion();
            lion.Name = "Lion grisha";
            lion.ID = 1;
            lion.FeedDate = "2018-05-05";
            animals.Add(lion);
            
            Bear bear = new Bear();
            bear.Name = "Misha";
            bear.ID = 2;
            bear.FeedDate = "2018-05-05";
            animals.Add(bear);
        }
    }
}