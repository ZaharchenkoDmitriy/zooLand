using System;
using System.Net;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.DataBase.Repositories;
using ConsoleApplication1.server;
using ConsoleApplication1.server.PlaneModels;
using Newtonsoft.Json;

namespace ConsoleApplication1.Controllers
{
    public class AnimalsController
    {
        AnimalRepository animalRepository = new AnimalRepository();
        UserRepository userRepository = new UserRepository();

        public Responce getAnimals(HttpListenerRequest request)
        {
            foreach (Consuming animal in DB.animals)
            {
                animal.calculateFeedDate();
            }

            return Responce.ok(DB.getAnimals());
        }

        public Responce getAppointedUser(HttpListenerRequest request)
        {
            Animal animal = parseAnimal(request);

            User user = userRepository.findOneByAnimal(animal);
            
            if (user != null)
                return Responce.ok((UserPlane) user);
            
            return Responce.notFound();
        }

        public Responce feedToday(HttpListenerRequest request)
        {
            Animal animal = parseAnimal(request);

            User user = userRepository.findOneByAnimal(animal);

            if (user != null)
            {
                user.feedTheAnimal(animal);
                return Responce.ok(user);
            }
            
            return Responce.notFound();
        }
        
        private Animal parseAnimal(HttpListenerRequest request)
        {
            string animalAsJson = RequestBodyParser.parse(request.InputStream, request.ContentEncoding);
            Animal animal = JsonConvert.DeserializeObject<Animal>(animalAsJson);
            
            return animal;
        }
    }
}