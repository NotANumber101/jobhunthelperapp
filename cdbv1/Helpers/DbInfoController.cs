using System;
using System.Collections.Generic;
using System.Text;

namespace cdbv1.Helpers
{
    // internal class?
    public class DbInfoController()

    {
        public string GetDbNames()
        {
            // Get all database names
            return "SELECT datname FROM pg_database WHERE datistemplate = false;";
        }
        public string GetDbTableNamesSql()
        {
        // Get db table names and table fields 
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
        public string CreateNewDsaSolution(int problemId, string solution)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            return $"INSERT INTO dsa_solution (problem_id, solution, date_completed) VALUES ({problemId}, '{solution}', '{today}');";
        }
        public string UpdateDsaProblemDateCompletedTodayId(int problemId)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            return $"UPDATE dsa_problem SET date_completed='{today}' WHERE id={problemId}";
        }
    }
}