
using Hydroponics.Application.Abstracts;
using Hydroponics.Application.Entities.Alarm;
using Hydroponics.Application.Entities.FlowControl;

namespace Hydroponics.ESP32_C3
{
    public class HydroponicsConfiguration : AbstractHydroponicsConfiguration
    {
        public override int SoilHygrometerPinNumber { get; protected set; }
        public override int DrivePinNumber { get; protected set; }
        public override int BuzzerPinNumber { get; protected set; }
        public override FlowLimit[] FlowLimits { get; protected set; }

        public HydroponicsConfiguration()
        {
            InitializeDevicePins();
            InitializeFlowLimits();
        }

        private void InitializeDevicePins()
        {
            SoilHygrometerPinNumber = 0;
            DrivePinNumber = 1;
            BuzzerPinNumber = 2;
        }

        private void InitializeFlowLimits()
        {
            FlowLimits = new FlowLimit[3];

            FlowLimits[0] = new FlowLimit(maxContinuousOperationTime: 30 * 1000,
                                          postAlarmPauseDuration: 30 * 60000,
                                          alarmsRepeatCount: 62,
                                          alertPattern: new[] {
                                              new AlertValue(true,  50),
                                              new AlertValue(false, 430)
                                          });

            FlowLimits[1] = new FlowLimit(maxContinuousOperationTime: 60 * 60000,
                                          postAlarmPauseDuration: 1 * 60 * 60000,
                                          alarmsRepeatCount: 250,
                                          alertPattern: new[] {
                                              new AlertValue(true,  50),
                                              new AlertValue(false, 430)
                                          });

            FlowLimits[2] = new FlowLimit(maxContinuousOperationTime: 90 * 60000,
                                          postAlarmPauseDuration: 4 * 60 * 60000,
                                          alarmsRepeatCount: 625,
                                          alertPattern: new[] {
                                              new AlertValue(true,  50),
                                              new AlertValue(false, 430)
                                          });
        }
    }
}
