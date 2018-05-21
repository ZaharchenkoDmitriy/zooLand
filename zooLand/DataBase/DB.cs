using System.Collections;
using ConsoleApplication1.server;

namespace ConsoleApplication1.DataBase
{
    public static class DB
    {
        public static ArrayList animals = new ArrayList();
        public static ArrayList users = new ArrayList();
        public static TelegramConnector telegramConnector { get; set; }

        public static Animal[] getAnimals()
        {
            Animal[] animalsArr = (Animal[]) animals.ToArray(typeof(Animal));
            return animalsArr;
        }

        public static void createAnimal(Animal animal)
        {
            Animal lastAnimal = (Animal)DB.animals[DB.animals.Count - 1];
            animal.ID = lastAnimal.ID + 1;
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
            lion.Name = "Grisha";
            lion.ID = 1;
            lion.Hungry = true;
            lion.FeedDate = "2018-05-05";
            animals.Add(lion);

            Bear bear = new Bear();
            bear.Name = "Misha";
            bear.ID = 2;
            bear.Hungry = true;
            bear.FeedDate = "2018-05-05";
            animals.Add(bear);

            User yaLubimiy = new User("zahar");
            yaLubimiy.ID = 1;
            //yaLubimiy.ChatId = 376484784;
            yaLubimiy.addAnimal(lion);
            
            users.Add(yaLubimiy);
        }

        public static User findUserByChat(long chatId)
        {
            foreach (User user in users)
            {
                if (user.ChatId == chatId)
                    return user;
            }

            return null;
        }

        public static User findUserByName(string name)
        {
            foreach (User user in users)
            {
                if (user.Name.Equals(name))
                {
                    return user;
                }
            }

            return null;
        }
    }
}