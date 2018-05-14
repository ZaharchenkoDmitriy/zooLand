using System.Collections.Generic;

namespace ConsoleApplication1.server
{
    public class URI
    {
        public string Route{ get ; set; }
        public string Method { get; set; }
    
        public URI(string route, string method)
        {
            Route = route;
            Method = method;
        }

        protected bool Equals(URI other)
        {
            return string.Equals(Route, other.Route) && string.Equals(Method, other.Method);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((URI) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Route != null ? Route.GetHashCode() : 0) * 397) ^ (Method != null ? Method.GetHashCode() : 0);
            }
        }
    }
}