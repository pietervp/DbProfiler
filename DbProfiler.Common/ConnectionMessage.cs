using System.Runtime.Serialization;

namespace Van.Parys.Data.Common
{
    [DataContract]
    public class ConnectionMessage
    {
        [DataMember]
        public string ConnectionGUID { get; set; }

        [DataMember]
        public bool Open { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0} changed to {1}", ConnectionGUID, Open ? "Open" : "Closed");
        }
    }
}