﻿using System.Collections;
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
    }
}