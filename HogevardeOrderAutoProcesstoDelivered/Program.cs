using HogevardeOrderAutoProcesstoDelivered.Test;
using HogevardeOrderAutoProcesstoDelivered.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using HogevardeOrderAutoProcesstoDelivered.Repository.Interface;
using HogevardeOrderAutoProcesstoDelivered.Repository.Implementation;

namespace HogevardeOrderAutoProcesstoDelivered
{
   public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<ITestCl, TestCl>();
            services.AddScoped<IFirewoodOrders, FirewoodOrders>();
            services.AddScoped<ICleaningOrder, CleaningOrderRepo>();
            services.AddDbContext<hogevardeDbContext>();
            services.AddSingleton<App>();
          

            var serviceProvider = services.BuildServiceProvider();
            var defaultApp = serviceProvider.GetService<App>();
            defaultApp.AppRun();

        }


   




    }
}
