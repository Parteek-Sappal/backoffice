using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace Samples
{
    public class OrderedHierarchy
    {

        // Receives a Table and orders the rows based on a specific relationship and
        // a parent column.
        public static DataTable GetOrderedTable(DataTable baseTable, string relationshipName, string parentColumnName)
        {

            // Configure the ordered table that will be passed out to the client
            DataTable tbl = baseTable.Clone();
            tbl.Columns.Add(new DataColumn("Depth", typeof(Int32)));
            
            ComputeHierarchy(ref tbl, baseTable.Select(parentColumnName + "=0"), 0);
            return tbl;
        }

        // Recursive routine that appends rows to the Private 
        // table in an ordered manner

        private static void ComputeHierarchy(ref DataTable orderedTable, DataRow[] members, Int32 depth)
        {
            DataRow member = null;
            foreach (DataRow member_loopVariable in members)
            {
                member = member_loopVariable;
                orderedTable.ImportRow(member);
                orderedTable.Rows[orderedTable.Rows.Count - 1]["Depth"] = depth;
                ComputeHierarchy(ref orderedTable, member.GetChildRows("ParentChild"), depth + 1);
            }
        }

    }

}
