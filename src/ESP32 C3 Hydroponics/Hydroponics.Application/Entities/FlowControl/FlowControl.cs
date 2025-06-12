
using Hydroponics.Application.Abstracts.Devices;

namespace Hydroponics.Application.Entities.FlowControl
{
    public sealed class FlowControl
    {
        private readonly AbstractDrive _drive;
        private readonly FlowLimit[] _flowLimits;

        private int _flowLimitsIndex;

        public FlowControl(AbstractDrive drive, FlowLimit[] flowLimits)
        {
            _drive = drive;
            _flowLimits = flowLimits;

            ResetFlowLimitsQueue();
        }

        public bool IsLimitExceeded()
        {
            FlowLimit currentFlowLimit = GetCurrentFlowLimit();

            return IsLimitExceeded(currentFlowLimit);
        }

        public FlowLimit GetCurrentFlowLimit() => _flowLimits[_flowLimitsIndex];

        public void SelectNextFlowLimit()
        {
            if (_flowLimitsIndex < _flowLimits.Length - 1)
                _flowLimitsIndex++;
        }

        public bool IsNeedResetFlowLimitsQueue()
        {
            if (_flowLimits.Length == 0)
                return false;

            int index = _flowLimitsIndex - 1;

            if (index < 0)
                index = 0;

            return IsLimitExceeded(_flowLimits[index]) == false;
        }

        public void ResetFlowLimitsQueue()
        {
            _flowLimitsIndex = 0;
        }

        private bool IsLimitExceeded(FlowLimit flowLimit)
        {
            if (_drive.ContinuousOperationTime > flowLimit.MaxContinuousOperationTime)
                return true;

            return false;
        }
    }
}