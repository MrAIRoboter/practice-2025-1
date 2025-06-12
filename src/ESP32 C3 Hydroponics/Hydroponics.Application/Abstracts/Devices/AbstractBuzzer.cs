using System.Device.Gpio;
using Hydroponics.Application.Entities.Alarm;

namespace Hydroponics.Application.Abstracts.Devices
{
    public abstract class AbstractBuzzer : AbstractDevice
    {
        protected AbstractBuzzer(GpioController gpioController) : base(gpioController)
        {
        }

        public abstract void Speak(int millisecondsDuration);
        public abstract void PlayAlert(AlertValue[] alertPattern);
    }
}