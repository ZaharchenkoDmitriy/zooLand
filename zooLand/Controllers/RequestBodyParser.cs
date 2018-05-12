using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace ConsoleApplication1.Controllers
{
    public class RequestBodyParser
    {
        
        public static string parse(System.IO.Stream inputStream, System.Text.Encoding encoding) { 
            StreamReader reader = new StreamReader(inputStream, encoding);
            String bodyText = reader.ReadToEnd();
            
            return bodyText;
        }
    }
}