using Easv.PetShop.Application.Services.DomainService;
using Easv.PetShop.Core.Application.Services.ApplicationService;
using Easv.PetShop.Core.Application.Services.ApplicationService.Services;
using Easv.PetShop.Infrastructure.Static.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EASV.PetShop
{
    class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            var serviceProvider = services.BuildServiceProvider();

            var petService = serviceProvider.GetService<IPetService>();

            var printer = new Printer(petService);
        }
    }
}
