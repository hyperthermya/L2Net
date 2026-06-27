using System;
using System.Threading;

namespace L2_login
{
    public class SmartTimer
    {
        public delegate void Tick();

        public Tick OnTimerTick;
        private const int InternalTick = 200;

        public volatile bool Initialized = false;
        public volatile int Interval;
        private Timer _timer;
        private DateTime _lastfired = new DateTime(0L);

        private readonly object LastFiredLock = new object();
        private volatile bool _fire = false;

        private void TimerCallback(object state)
        {
            if (!_fire) return;

            DateTime now = DateTime.Now;
            DateTime lastFired;

            lock (LastFiredLock)
            {
                lastFired = _lastfired;
            }

            if (now > lastFired.AddMilliseconds(Interval))
            {
                OnTimerTick?.Invoke();
                lock (LastFiredLock)
                {
                    _lastfired = now;
                }
            }
        }

        public void Start()
        {
            _fire = true;

            if (!Initialized)
            {
                Initialized = true;
                _lastfired = DateTime.Now;
                _timer = new Timer(TimerCallback, null, 0, InternalTick);
            }
        }

        public void Stop()
        {
            _fire = false;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _timer = null;
            Initialized = false;
            _fire = false;
        }
    }
}
