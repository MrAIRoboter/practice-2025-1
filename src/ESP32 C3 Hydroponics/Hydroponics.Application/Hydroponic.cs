using System.Diagnostics;
using System.Threading;
using Hydroponics.Application.Abstracts.Devices;
using Hydroponics.Application.Entities.Alarm;
using Hydroponics.Application.Entities.FlowControl;

namespace Hydroponics.Application
{
    public sealed class Hydroponic
    {
        private AbstractSoilHygrometer _soilHygrometer;
        private AbstractDrive _drive;
        private AbstractBuzzer _buzzer;
        private FlowControl _flowControl;

        public Hydroponic(AbstractSoilHygrometer soilHygrometer, AbstractDrive drive, AbstractBuzzer buzzer, FlowControl flowControl)
        {
            _soilHygrometer = soilHygrometer;
            _drive = drive;
            _buzzer = buzzer;
            _flowControl = flowControl;
        }

        public void Run(CancellationToken stoppingToken)
        {
            Alarm alarm = new Alarm(_buzzer);

            Thread.Sleep(1000);
            Debug.WriteLine("I am initialized!");

            _buzzer.Speak(20);
            Debug.WriteLine("*beep*");

            while (stoppingToken.IsCancellationRequested == false)
            {
                Thread.Sleep(500);

                bool isNeedWatering = _soilHygrometer.DigitalValue;

                if (_flowControl.IsLimitExceeded() == false)
                {
                    if (_flowControl.IsNeedResetFlowLimitsQueue() == true)
                        _flowControl.ResetFlowLimitsQueue();

                    SetDriveState(isNeedWatering);
                    Debug.WriteLine($"ContinuousOperationTime is {_drive.ContinuousOperationTime} ms. No need in alarm. Current drive state is {isNeedWatering}.");
                    continue;
                }

                Debug.WriteLine("ALARM!!!");

                _drive.Pause();

                FlowLimit currentFlowLimit = _flowControl.GetCurrentFlowLimit();

                alarm.Play(currentFlowLimit.AlarmPattern, currentFlowLimit.AlarmRepeatsCount);

                Debug.WriteLine($"*sleep* ({currentFlowLimit.PostAlarmPauseDuration} ms)");
                Thread.Sleep(currentFlowLimit.PostAlarmPauseDuration);

                _flowControl.SelectNextFlowLimit();
            }
        }

        private void SetDriveState(bool isEnabled)
        {
            if (isEnabled == true)
                _drive.Start();
            else
                _drive.Stop();
        }
    }
}
