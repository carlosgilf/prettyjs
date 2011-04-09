using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace IssueAppVS2008_CSharp
{
    public class Utils
    {
        public static DataTable BuildDatatable(int intCols, int intRows)
        {
            DataTable DT = new DataTable();
            for (int i = 1; i <= intCols; i++)
            {
                DT.Columns.Add("Col" + i.ToString());
            }
            for (int i = 1; i <= intRows; i++)
            {
                DataRow DR = DT.NewRow();
                for (int j = 1; j <= intCols; j++)
                {
                    DR["Col" + j.ToString()] = j.ToString();
                }
                DT.Rows.Add(DR);
            }
            return DT;
        }

        public static DataTable BuildDatatable(int intCols, int intRows, Type t)
        {
            DataTable DT = new DataTable();
            for (int i = 1; i <= intCols; i++)
            {
                DT.Columns.Add("Col" + i.ToString(), t);
            }
            for (int i = 1; i <= intRows; i++)
            {
                DataRow DR = DT.NewRow();
                for (int j = 1; j <= intCols; j++)
                {
                    DR["Col" + j.ToString()] = GetNonNullValue(t);
                }
                DT.Rows.Add(DR);
            }
            return DT;
        }

        public static Object GetNonNullValue(Type t)
        {
            if (t == typeof (int))
                return 0;
            else if (t == typeof(Boolean))
                return false;
            else if (t == typeof(string))
                return "";
            else
                throw new InvalidCastException("Default non-null value not supported for " + t.ToString());
        }


    }
}
