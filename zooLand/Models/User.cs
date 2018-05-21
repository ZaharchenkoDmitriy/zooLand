using System.Collections;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.server.PlaneModels;

namespace ConsoleApplication1.server
{
    public class User : UserPlane
    {
        private ArrayList animalsToFeed = new ArrayList();
      
        public User(string name)
        {
            Name = name;
        }

        public void addAnimal(Animal animal)
        {
            animalsToFeed.Add(animal);
        }

        public Animal findAnimal(Animal animal)
        {
            foreach (Animal an in animalsToFeed)
            {
                if (an.ID == animal.ID)
                    return an;
            }

            return null;
        }

        public void removeAnimal(Animal animal)
        {
            foreach (Animal an in animalsToFeed)
            {
                if (an.ID == animal.ID)
                {
                    animalsToFeed.Remove(an);
                    break;
                } 
            }
        }

        public bool isAppointed(Animal animal)
        {
            foreach (Animal an in animalsToFeed)
            {
                if (an.ID == animal.ID)
                    return true;
            }

            return false;
        }

        public void feedTheAnimal(Animal animal)
        {
            Animal animalToFeed = findAnimal(animal);
            animalToFeed.Hungry = true;
            DB.telegramConnector.sendMessageToUser(this, animalToFeed);
        }

        public string getAppointedAnimalsMessage()
        {
            string result = "You must to feed animals: \n";
            bool animalFinded = false;
            foreach (Animal animal in animalsToFeed)
            {
                if (animal.Hungry)
                {
                    result += animal.Name + '\n';
                    animalFinded = true;
                }
            }

            return animalFinded ? result : "You are free now, there are no animals to feed";
        }

        public Animal findAnimalByName(string name)
        {
            foreach (Animal animal in animalsToFeed)
            {
                if (animal.Name.Equals(name))
                    return animal;
            }

            return null;
        }
    }
}