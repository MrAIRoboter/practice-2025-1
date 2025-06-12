using Hydroponics.Application.Abstracts.Devices;

namespace Hydroponics.Application.Entities.Alarm
{
    public sealed class Alarm
    {
        private readonly AbstractBuzzer _buzzer;

        public Alarm(AbstractBuzzer buzzer)
        {
            _buzzer = buzzer;
        }

        public void Play(AlertValue[] alarmPattern, int repeatsCount)
        {
            for (int i = 0; i < repeatsCount; i++)
                _buzzer.PlayAlert(alarmPattern);
        }
    }
}