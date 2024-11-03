using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace APIRecicheck
{
    public partial class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Program>(); // Usa o próprio `Program.cs` como configuração.
                });
    }
}
