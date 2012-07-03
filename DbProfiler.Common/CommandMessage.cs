using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Serialization;

namespace Van.Parys.Data.Common
{
    [DataContract]
    public class CommandMessage
    {
        [DataMember]
        public object NonReaderResult { get; set; }

        [DataMember]
        public string ConnectionGUID { get; set; }

        [DataMember]
        public string CommandText { get; set; }
        
        [DataMember]
        public TimeSpan Duration { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public List<QueryExecutionPlan> QueryExecutionPlans { get; set; }

        public CommandMessage()
        {
            
        }

        public CommandMessage(string cmdText, TimeSpan duration, string type, string connectionGUID)
        {
            CommandText = cmdText;
            Duration = duration;
            Type = type;
            ConnectionGUID = connectionGUID;
        }

        public override string ToString()
        {
            return string.Format("{0}: [{1}ms] [result:'{3}'] : {2}", Type, Duration.TotalMilliseconds,  CommandText, NonReaderResult);
        }
    }
}
