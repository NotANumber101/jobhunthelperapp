using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Helpers
{
    // internal class?
    public class DbInfoController
    {

        public string GetDbTableNamesSql()
        {
            return "SELECT table_name, table_type "
    + "FROM information_schema.tables WHERE table_schema "
    + "NOT IN ('pg_catalog', 'information_schema') "
    + "ORDER BY table_schema, table_name;";
        }
        public string GetTableFieldNamesSql(string tableName)
        {
            return "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS "
            + $"WHERE TABLE_NAME = '{tableName}' "
            + "ORDER BY ORDINAL_POSITION;";
        }
    }
}