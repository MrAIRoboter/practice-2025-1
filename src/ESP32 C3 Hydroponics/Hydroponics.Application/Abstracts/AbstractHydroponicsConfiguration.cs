
using Hydroponics.Application.Entities.FlowControl;

namespace Hydroponics.Application.Abstracts
{
    public abstract class AbstractHydroponicsConfiguration
    {
        public abstract int SoilHygrometerPinNumber { get; protected set; }
        public abstract int DrivePinNumber { get; protected set; }
        public abstract int BuzzerPinNumber { get; protected set; }
        public abstract FlowLimit[] FlowLimits { get; protected set; }
    }
}
