using System.Device.Gpio;

namespace Hydroponics.Application.Abstracts.Devices
{
    public abstract class AbstractDrive : AbstractDevice
    {
        public abstract long ContinuousOperationTime { get; }

        protected AbstractDrive(GpioController gpioController) : base(gpioController)
        {
        }

        public abstract void Start();
        public abstract void Pause();
        public abstract void Stop();
    }
}