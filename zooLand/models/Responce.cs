using System;

namespace ConsoleApplication1.server
{
    public class Responce
    {
        public string Status { get; set; }
        public object Body { get; set; }

        public static Responce ok(Object body)
        {
            Responce responce = new Responce();

            responce.Body = body;
            responce.Status = "OK";

            return responce;
        }

        public static Responce notFound()
        {
           Responce responce = new Responce();

            responce.Status = "Not Found";
            responce.Body = null;

            return responce;
        }
        
    }
}