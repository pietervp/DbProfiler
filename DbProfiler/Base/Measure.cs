using System;
using System.Diagnostics;

namespace DbProfiler
{
    public class Measure : IDisposable
    {
        private readonly Stopwatch _stopwatch;

        public bool IsRunning
        {
            get { return _stopwatch.IsRunning; }
        }

        public TimeSpan Elapsed
        {
            get { return _stopwatch.Elapsed; }
        }

        public long ElapsedMilliseconds
        {
            get { return _stopwatch.ElapsedMilliseconds; }
        }

        public long ElapsedTicks
        {
            get { return _stopwatch.ElapsedTicks; }
        }

        [ThreadStatic]
        private static IDisposable _this;

        public static IDisposable Scope
        {
            get
            {
                _this = new Measure(); 
                return _this;
            }
        }

        public static Measure Was
        {
            get
            {
                return _this as Measure;
            }
        }

        public Measure()
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatch.Stop();
        }
    }
}