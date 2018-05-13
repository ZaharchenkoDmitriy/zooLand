using System;
using System.Net;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.DataBase.Repositories;
using ConsoleApplication1.server;
using ConsoleApplication1.server.PlaneModels;
using Newtonsoft.Json;

namespace ConsoleApplication1.Controllers
{
    public class UsersController
    {
        private UserRepository userRepository = new UserRepository();
        
        public Responce createUser(HttpListenerRequest request)
        {
            User user = parseUser(request);
          
            userRepository.createUser(user);
            
            return Responce.ok((UserPlane) user);
        }

        public Responce setAnimalOnUser(HttpListenerRequest request)
        {
            string animalAsString = RequestBodyParser.parse(request.InputStream, request.ContentEncoding);
            Animal animal = JsonConvert.DeserializeObject<Animal>(animalAsString);
      
            User user = userRepository.setAnimalOnUser(Int32.Parse(request.QueryString["userId"]), animal);
            
            return Responce.ok((UserPlane) user);
        }

        public Responce getUsers(HttpListenerRequest request)
        {
            return Responce.ok(userRepository.getUsers());
        }

        private User parseUser(HttpListenerRequest request)
        {
            string userAsJson = RequestBodyParser.parse(request.InputStream, request.ContentEncoding);
            User user = JsonConvert.DeserializeObject<User>(userAsJson);
            
            return user;
        }
    }
}