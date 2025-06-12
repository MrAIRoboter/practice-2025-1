using System.Device.Gpio;

namespace Hydroponics.Application.Abstracts.Devices
{
    public abstract class AbstractSoilHygrometer : AbstractDevice
    {
        public abstract bool DigitalValue { get; }

        protected AbstractSoilHygrometer(GpioController gpioController) : base(gpioController)
        {
        }
    }
}