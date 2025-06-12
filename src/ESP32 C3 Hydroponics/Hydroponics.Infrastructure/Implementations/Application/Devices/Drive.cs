using System.Device.Gpio;
using Hydroponics.Application.Abstracts.Devices;
using Hydroponics.Application.Common.Diagnostics;

namespace Hydroponics.Infrastructure.Implementations.Application.Devices
{
    public sealed class Drive : AbstractDrive
    {
        public int PinNumber { get; private set; }

        public override long ContinuousOperationTime { get => _stopwatch.ElapsedMilliseconds; }

        private AccumulatingStopwatch _stopwatch;
        private bool _isActive;
        private bool _isPaused;

        public Drive(int pinNumber, GpioController gpioController) : base(gpioController)
        {
            PinNumber = pinNumber;
            _stopwatch = new AccumulatingStopwatch();
            _isActive = false;
            _isPaused = false;

            InitializeGpioController();
        }

        protected override void InitializeGpioController()
        {
            _gpioController.OpenPin(PinNumber, PinMode.Output);
        }

        public override void Start()
        {
            if (_isActive == true)
                return;

            _stopwatch.Start();

            _gpioController.Write(PinNumber, PinValue.High);

            _isActive = true;
            _isPaused = false;
        }

        public override void Pause()
        {
            if (_isPaused == true)
                return;

            _stopwatch.Stop();

            _gpioController.Write(PinNumber, PinValue.Low);

            _isActive = false;
            _isPaused = true;
        }

        public override void Stop()
        {
            if (_isActive == false)
                return;

            _stopwatch.Stop();
            _stopwatch.Reset();

            _gpioController.Write(PinNumber, PinValue.Low);

            _isActive = false;
            _isPaused = false;
        }
    }
}