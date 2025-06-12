
namespace Hydroponics.Application.Entities.Alarm
{
    public sealed class AlertValue
    {
        public readonly bool State;
        public readonly int Duration;

        public AlertValue(bool state, int duration)
        {
            State = state;
            Duration = duration;
        }
    }
}