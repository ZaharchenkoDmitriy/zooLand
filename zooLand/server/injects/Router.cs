using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ConsoleApplication1.Controllers;

namespace ConsoleApplication1.server
{
    public class Router
    {
        delegate Responce Response(HttpListenerRequest request);
        
        private Dictionary<URI, Delegate> controllers = new Dictionary<URI, Delegate>();

        public void addController(URI uri, Delegate controller)
        {
            controllers.Add(uri, controller);
        }

        public Delegate getController(URI uri)
        {
            if (uri.Route[uri.Route.Length - 1] == '/')
            {
                uri.Route = uri.Route.Remove(uri.Route.Length - 1);
            } 
            try
            {
                return controllers[uri];
            }
            catch (Exception e)
            {
                return controllers[new URI("no", "controller")];
            }

        }

        public static Router getRouter()
        {
            Router router = new Router();
            AnimalsController animalsController = new AnimalsController();
            UsersController usersController = new UsersController();

            Response response;
            
            response = animalsController.getAnimals;
            router.addController(new URI("/animals", "GET"), response);

            response = usersController.createUser;
            router.addController(new URI("/users", "POST"), response);

            response = usersController.getUsers;
            router.addController(new URI("/users", "GET"), response);
            
            response = new NoController().noController;
            router.addController(new URI("no", "controller"), response);
            
            
            return router;
        }
    }
}