using System.Data.Common;
using System.Diagnostics;
using System;

namespace DbProfiler
{
    public static class ProfilerStopwatchAction
    {
        public static TimeSpan Measure<T>(this Action<T> action, T argument)
        {
            var startNew = Stopwatch.StartNew();

            //perform action to measure time
            action(argument);
            
            startNew.Stop();

            return TimeSpan.FromMilliseconds(startNew.ElapsedMilliseconds);
        }
    }
}