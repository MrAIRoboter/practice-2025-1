using System.Device.Gpio;

namespace Hydroponics.Application.Abstracts.Devices
{
    public abstract class AbstractDevice
    {
        protected readonly GpioController _gpioController;

        protected AbstractDevice(GpioController gpioController)
        {
            _gpioController = gpioController;
        }

        protected abstract void InitializeGpioController();
    }
}