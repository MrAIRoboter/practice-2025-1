using System.Diagnostics;

namespace Hydroponics.Application.Common.Diagnostics
{
    public sealed class AccumulatingStopwatch
    {
        public long ElapsedMilliseconds
        {
            get
            {
                long result = _accumulatedElapsedMilliseconds;

                if (_isRunning == true)
                    result += _stopwatch.ElapsedMilliseconds;

                return result;
            }
        }

        private Stopwatch _stopwatch;
        private long _accumulatedElapsedMilliseconds;
        private bool _isRunning;

        public AccumulatingStopwatch()
        {
            _stopwatch = new Stopwatch();
            _accumulatedElapsedMilliseconds = 0;
            _isRunning = false;
        }

        public void Start()
        {
            if (_isRunning == true)
                return;

            _stopwatch.Restart();

            _isRunning = true;
        }

        public void Stop()
        {
            if (_isRunning == false)
                return;

            _stopwatch.Stop();

            _accumulatedElapsedMilliseconds += _stopwatch.ElapsedMilliseconds;
            _isRunning = false;
        }

        public void Reset()
        {
            _stopwatch.Reset();

            _accumulatedElapsedMilliseconds = 0;
            _isRunning = false;
        }
    }
}