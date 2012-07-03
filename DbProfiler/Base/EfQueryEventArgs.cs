using System;
using System.Data.Objects;

namespace DbProfiler
{
    public class EfQueryEventArgs : EventArgs
    {
        public string CommandText { get; set; }
        public ObjectContext ObjectContext { get; set; }
        public TimeSpan Duration { get; set; }
        public string Type { get; set; }

        public EfQueryEventArgs(string cmdText, ObjectContext context, TimeSpan duration, string type)
        {
            CommandText = cmdText;
            ObjectContext = context;
            Duration = duration;
            Type = type;
        }

        public override string ToString()
        {
            return string.Format("{0}: [{1}ms] : {2} :: {3}", Type, Duration.TotalMilliseconds, ObjectContext.ToString(), CommandText);
        }
    }
}