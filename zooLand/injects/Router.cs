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
            try
            {
                URI test1 = new URI("no", "controller");
                URI test2 = new URI("no", "controller");
                URI test3 = new URI("no", "controller");
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

            Response response;
            response = animalsController.getLion;
            
            router.addController(new URI("/animals", "GET"), response);

            response = new NoController().noController;
            router.addController(new URI("no", "controller"), response);
            
            
            return router;
        }
    }
}