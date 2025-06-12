using System;
using Hydroponics.Application;
using Hydroponics.Application.Entities.FlowControl;
using Hydroponics.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hydroponics.ESP32_C3
{
    public class Program
    {
        public static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                           .ConfigureServices(services =>
                           {
                               HydroponicsConfiguration config = new HydroponicsConfiguration();

                               services.AddInfrastructure(config)
                                       .AddApplication(config);

                               // Запускаем Hydroponic как HostedService
                               services.AddHostedService(typeof(HydroponicService));
                           })
                           .Build();

            // Блокирует основной поток, пока контроллер работает
            host.Run();
        }
    }
}
