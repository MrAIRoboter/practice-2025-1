using System;
using System.Device.Gpio;
using Hydroponics.Application.Abstracts;
using Hydroponics.Application.Abstracts.Devices;
using Hydroponics.Application.Entities.FlowControl;
using Hydroponics.Infrastructure.Implementations.Application.Devices;
using Microsoft.Extensions.DependencyInjection;
using nanoFramework.Hardware.Esp32;

namespace Hydroponics.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, AbstractHydroponicsConfiguration configuration)
        {
            services.AddDevices(configuration);

            return services;
        }

        public static IServiceCollection AddDevices(this IServiceCollection services, AbstractHydroponicsConfiguration configuration)
        {
            GpioController gpioController = new GpioController();

            services.AddSingleton(typeof(AbstractBuzzer), new Buzzer(configuration.BuzzerPinNumber, gpioController));
            services.AddSingleton(typeof(AbstractDrive), new Drive(configuration.DrivePinNumber, gpioController));
            services.AddSingleton(typeof(AbstractSoilHygrometer), new SoilHygrometer(configuration.SoilHygrometerPinNumber, gpioController));

            return services;
        }
    }
}