using System.Runtime.Serialization;

namespace Van.Parys.Data.Common
{
    [DataContract]
    public enum ExecuteMethod
    {
        ExecuteScalar,
        ExecuteNonQuery,
        ExecuteDbDataReader
    }
}