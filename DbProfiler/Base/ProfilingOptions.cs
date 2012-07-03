using System;
using DbProfiler.Output;

namespace DbProfiler
{
    public class ProfilingOptions
    {
        public bool IncludeQueryStatistics { get; set; }
        public bool ProfileConnections { get; set; }
        public ProfilingOutput ProfilingOutput { get; set; }
        public IProfileOutput CustomProfileOutput { get; set; }

        public ProfilingOptions(bool includeQueryStatistics, bool profileConnections, IProfileOutput customProfileOutput)
        {
            CustomProfileOutput = customProfileOutput;
            IncludeQueryStatistics = includeQueryStatistics;
            ProfileConnections = profileConnections;
            ProfilingOutput = ProfilingOutput.Custom;
        }

        public ProfilingOptions(bool includeQueryStatistics, bool profileConnections, ProfilingOutput profilingOutput)
        {
            IncludeQueryStatistics = includeQueryStatistics;
            ProfileConnections = profileConnections;
            ProfilingOutput = profilingOutput;
        }

        public ProfilingOptions()
        {
            IncludeQueryStatistics = false;
            ProfileConnections = true;
            ProfilingOutput = ProfilingOutput.Debug;
        }

        public IProfileOutput CreateOutput()
        {
            if (CustomProfileOutput != null && ProfilingOutput == ProfilingOutput.Custom)
                return CustomProfileOutput;

            switch (ProfilingOutput)
            {
                case ProfilingOutput.Wcf:
                    return new WcfProfileOutput();
                    break;
                case ProfilingOutput.Debug:
                    return new DebugProfileOutput();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}