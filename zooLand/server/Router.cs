using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication1.Controllers;

namespace ConsoleApplication1.server
{
    public class Router
    {
        delegate string Response();
        
        private Dictionary<string, Delegate> controllers = new Dictionary<string, Delegate>();

        public void addController(string uri, Delegate controller)
        {
            controllers.Add(uri, controller);
        }

        public Delegate getController(String uri)
        {
            try
            {
                return controllers[uri];
            }
            catch (Exception e)
            {
                return controllers["noController"];
            }

        }

        public static Router getRouter()
        {
            Router router = new Router();
            AnimalsController animalsController = new AnimalsController();

            Response response;
            response = animalsController.getResponse;
            
            router.addController("/animals", response);

            response = new NoController().noController;
            router.addController("noController", response);
            
            
            return router;
        }
    }
}