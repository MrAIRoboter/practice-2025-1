using System.Device.Gpio;
using Hydroponics.Application.Abstracts.Devices;

namespace Hydroponics.Infrastructure.Implementations.Application.Devices
{
    public sealed class SoilHygrometer : AbstractSoilHygrometer
    {
        public override bool DigitalValue { get => _gpioController.Read(PinNumber) == PinValue.High; }
        public int PinNumber { get; private set; }

        public SoilHygrometer(int pinNumber, GpioController gpioController) : base(gpioController)
        {
            PinNumber = pinNumber;

            InitializeGpioController();
        }

        protected override void InitializeGpioController()
        {
            _gpioController.OpenPin(PinNumber, PinMode.Input);
        }
    }
}