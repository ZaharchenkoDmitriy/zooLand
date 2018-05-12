using System;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection;
using ConsoleApplication1.Controllers;

namespace ConsoleApplication1.server
{
    public class SimpleDispatcher : Dispatcher
    {
        public SimpleDispatcher(Router router)
        {
            this.router = router;
        }

        private Router router;
        
        public override Responce getResponce(HttpListenerRequest request)
        {
            Delegate _delegate = router.getController(new URI(request.RawUrl, request.HttpMethod));

            return (Responce) _delegate.Method.Invoke(_delegate.Target, new object[] {request});

        }
    }
}