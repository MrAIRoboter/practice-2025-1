using System;
using System.Text;
using Hydroponics.Application.Abstracts;
using Hydroponics.Application.Abstracts.Devices;
using Hydroponics.Application.Entities.FlowControl;
using Microsoft.Extensions.DependencyInjection;

namespace Hydroponics.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, AbstractHydroponicsConfiguration configuration)
        {
            services.AddSingleton(typeof(AbstractHydroponicsConfiguration), configuration);
            services.AddSingleton(typeof(FlowControl), CreateFlowControl);
            services.AddSingleton(typeof(Hydroponic), CreateHydroponic);

            return services;
        }

        private static object CreateFlowControl(IServiceProvider serviceProvider)
        {
            AbstractHydroponicsConfiguration configuration = (AbstractHydroponicsConfiguration)serviceProvider.GetRequiredService(typeof(AbstractHydroponicsConfiguration));
            AbstractDrive drive = (AbstractDrive)serviceProvider.GetRequiredService(typeof(AbstractDrive));

            return new FlowControl(drive, configuration.FlowLimits);
        }

        private static object CreateHydroponic(IServiceProvider serviceProvider)
        {
            AbstractSoilHygrometer soilHygrometer = (AbstractSoilHygrometer)serviceProvider.GetRequiredService(typeof(AbstractSoilHygrometer));
            AbstractDrive drive = (AbstractDrive)serviceProvider.GetRequiredService(typeof(AbstractDrive));
            AbstractBuzzer buzzer = (AbstractBuzzer)serviceProvider.GetRequiredService(typeof(AbstractBuzzer));
            FlowControl flowControl = (FlowControl)serviceProvider.GetRequiredService(typeof(FlowControl));

            return new Hydroponic(soilHygrometer, drive, buzzer, flowControl);
        }
    }
}
