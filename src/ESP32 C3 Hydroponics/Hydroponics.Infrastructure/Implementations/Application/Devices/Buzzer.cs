using System.Device.Gpio;
using System.Threading;
using Hydroponics.Application.Abstracts.Devices;
using Hydroponics.Application.Entities.Alarm;

namespace Hydroponics.Infrastructure.Implementations.Application.Devices
{
    public sealed class Buzzer : AbstractBuzzer
    {
        public int PinNumber { get; private set; }

        public Buzzer(int pinNumber, GpioController gpioController) : base(gpioController)
        {
            PinNumber = pinNumber;

            InitializeGpioController();
        }

        protected override void InitializeGpioController()
        {
            _gpioController.OpenPin(PinNumber, PinMode.Output);
        }

        public override void PlayAlert(AlertValue[] alertPattern)
        {
            for (int i = 0; i < alertPattern.Length; i++)
            {
                AlertValue alertValue = alertPattern[i];
                PinValue pinValue = alertValue.State == true ? PinValue.High : PinValue.Low;

                _gpioController.Write(PinNumber, pinValue);

                Thread.Sleep(alertValue.Duration);
            }
        }

        public override void Speak(int millisecondsDuration)
        {
            _gpioController.Write(PinNumber, PinValue.High);

            Thread.Sleep(millisecondsDuration);

            _gpioController.Write(PinNumber, PinValue.Low);
        }
    }
}