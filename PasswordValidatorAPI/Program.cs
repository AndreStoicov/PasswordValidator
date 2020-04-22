using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PasswordValidatorAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseUrls("http://0.0.0.0:5050/", "http://localhost:5051/")
                .UseKestrel().UseStartup<Startup>();
        }
    }
}