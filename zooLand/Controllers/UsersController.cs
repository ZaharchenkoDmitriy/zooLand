using System.Net;
using ConsoleApplication1.DataBase;
using ConsoleApplication1.server;
using ConsoleApplication1.server.PlaneModels;
using Newtonsoft.Json;

namespace ConsoleApplication1.Controllers
{
    public class UsersController
    {
        public Responce createUser(HttpListenerRequest request)
        {
            string userAsJson = RequestBodyParser.parse(request.InputStream, request.ContentEncoding);
            User user = JsonConvert.DeserializeObject<User>(userAsJson);

            DB.users.Add(user);
            
            return Responce.ok((UserPlane) user);
        }

        public Responce getUsers(HttpListenerRequest request)
        {
            return Responce.ok(DB.users.ToArray());
        }
    }
}