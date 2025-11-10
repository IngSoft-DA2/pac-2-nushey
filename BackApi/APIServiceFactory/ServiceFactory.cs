using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServices;
using Microsoft.AspNetCore.Hosting;
using Services;

namespace APIServiceFactory
{
    public static class ServiceFactory
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IReflectionService>(provider =>
            {
                var webHostEnvironment = provider.GetRequiredService<IWebHostEnvironment>();

                string contentRootPath = webHostEnvironment.ContentRootPath;

                string reflectionFolderPath = Path.Combine(contentRootPath, "reflection");

                return new ReflectionService(reflectionFolderPath);
            });
        }
    }
}
