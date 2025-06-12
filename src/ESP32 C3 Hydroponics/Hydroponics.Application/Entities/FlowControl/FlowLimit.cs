
using Hydroponics.Application.Entities.Alarm;

namespace Hydroponics.Application.Entities.FlowControl
{
    public sealed class FlowLimit
    {
        public readonly long MaxContinuousOperationTime;
        public readonly int PostAlarmPauseDuration;
        public readonly int AlarmRepeatsCount;
        public readonly AlertValue[] AlarmPattern;

        public FlowLimit(long maxContinuousOperationTime, int postAlarmPauseDuration, int alarmsRepeatCount, AlertValue[] alertPattern)
        {
            MaxContinuousOperationTime = maxContinuousOperationTime;
            PostAlarmPauseDuration = postAlarmPauseDuration;
            AlarmRepeatsCount = alarmsRepeatCount;
            AlarmPattern = alertPattern;
        }
    }
}