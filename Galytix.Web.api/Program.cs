using System.Threading;
using Microsoft.Owin.Hosting;

namespace Galytix.Web.Api
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/";

            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
