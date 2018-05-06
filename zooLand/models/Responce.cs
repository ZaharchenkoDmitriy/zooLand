using System;

namespace ConsoleApplication1.server
{
    public class Responce
    {
        public int Status { get; set; }
        public object Body { get; set; }

        public static Responce ok(Object body)
        {
            Responce responce = new Responce();

            responce.Body = body;
            responce.Status = 200;

            return responce;
        }

        public static Responce notFound()
        {
           Responce responce = new Responce();

            responce.Status = 404;
            responce.Body = null;

            return responce;
        }
        
    }
}