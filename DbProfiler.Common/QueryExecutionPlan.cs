using System.Runtime.Serialization;

namespace Van.Parys.Data.Common
{
    [DataContract]
    public class QueryExecutionPlan
    {
        /// <summary>
        /// For rows that are not of type PLAN_ROW, this column contains the text of the Transact-SQL statement. For rows of type PLAN_ROW,
        /// this column contains a description of the operation. This column contains the physical operator and may optionally also contain 
        /// the logical operator. This column may also be followed by a description that is determined by the physical operator. For more
        ///  information, see Logical and Physical Operators Reference.
        /// </summary>
        [DataMember]
        public string StmtText { get; set; }

        /// <summary>
        /// Number of the statement in the current batch.
        /// </summary>
        [DataMember]
        public string StmtId { get; set; }

        /// <summary>
        /// ID of the node in the current query.
        /// </summary>
        [DataMember]
        public string NodeId { get; set; }

        /// <summary>
        /// Node ID of the parent step
        /// </summary>
        [DataMember]
        public string Parent { get; set; }

        /// <summary>
        /// Physical implementation algorithm for the node. For rows of type PLAN_ROWS only
        /// </summary>
        [DataMember]
        public string PhysicalOp { get; set; }

        /// <summary>
        /// Relational algebraic operator this node represents. For rows of type PLAN_ROWS only.
        /// </summary>
        [DataMember]
        public string LogicalOp { get; set; }

        /// <summary>
        /// Provides supplemental information about the operation being performed. The contents of this column depend on the physical operator.
        /// </summary>
        [DataMember]
        public string Argument { get; set; }

        /// <summary>
        /// Contains a comma-separated list of values introduced by this operator. These values may be computed expressions which were present
        /// in the current query (for example, in the SELECT list or WHERE clause), or internal values introduced by the query processor in order
        ///  to process this query. These defined values may then be referenced elsewhere within this query. For rows of type PLAN_ROWS only
        /// </summary>
        [DataMember]
        public string DefinedValues { get; set; }

        /// <summary>
        /// Estimated number of rows of output produced by this operator. For rows of type PLAN_ROWS only.
        /// </summary>
        [DataMember]
        public string EstimateRows { get; set; }

        /// <summary>
        /// Estimated I/O cost* for this operator. For rows of type PLAN_ROWS only.
        /// </summary>
        [DataMember]
        public string EstimatedIO { get; set; }

        /// <summary>
        /// Estimated CPU cost* for this operator. For rows of type PLAN_ROWS only.
        /// </summary>
        [DataMember]
        public string EstimateCPU { get; set; }

        /// <summary>
        /// Estimated average row size (in bytes) of the row being passed through this operator.
        /// </summary>
        [DataMember]
        public string AvgRowSize { get; set; }

        /// <summary>
        /// Estimated (cumulative) cost* of this operation and all child operations.
        /// </summary>
        [DataMember]
        public string TotalSubtreeCost { get; set; }

        /// <summary>
        /// Contains a comma-separated list of columns being projected by the current operation.
        /// </summary>
        [DataMember]
        public string OutputList { get; set; }

        /// <summary>
        /// Contains a comma-separated list of warning messages relating to the current operation. Warning messages may include the string 
        /// "NO STATS:()" with a list of columns. This warning message means that the query optimizer attempted to make a decision based 
        /// on the statistics for this column, but none were available. Consequently, the query optimizer had to make a guess, which may
        /// have resulted in the selection of an inefficient query plan. For more information about creating or updating column statistics
        /// (which help the query optimizer choose a more efficient query plan), see UPDATE STATISTICS. This column may optionally include 
        /// the string "MISSING JOIN PREDICATE", which means that a join (involving tables) is taking place without a join predicate. Accidentally
        /// dropping a join predicate may result in a query which takes much longer to run than expected, and returns a huge result set. If 
        /// this warning is present, verify that the absence of a join predicate is intentional.
        /// </summary>
        [DataMember]
        public string Warnings { get; set; }

        /// <summary>
        /// Node type. For the parent node of each query, this is the Transact-SQL statement type (for example, SELECT, INSERT, EXECUTE, and
        /// so on). For subnodes representing execution plans, the type is PLAN_ROW.
        /// </summary>
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// 0 = Operator is not running in parallel.
        /// 1 = Operator is running in parallel.
        /// </summary>
        [DataMember]
        public string Parallel { get; set; }

        /// <summary>
        /// Estimated number of times this operator will be executed while running the current query.
        /// </summary>
        [DataMember]
        public string EstimateExecutions { get; set; }

        public int CenterPointX { get; set; }
        public int CenterPointY { get; set; }

        public override string ToString()
        {
            return StmtText;
        }

        public string GetPercentage()
        {
            return TotalSubtreeCost.ToUpper();
        }
    }
}