namespace cdbv1.Queries
{
    // internal class?
    public class MyQueries()

    {
        public static string GetAllCompanies()
        {
            return "SELECT * FROM company_information;";
        }
        public static string GetDbNamesQuery()
        {
            return "SELECT datname FROM pg_database WHERE datistemplate = false;";
        }
        public static string GetAllApplicationsQuery()
        {
            return "SELECT * FROM application;";
        }
        public static string InsertNewApplicationQuery(Models.JobApplication jobApplication)
        {
            return "INSERT into application (company_name, current_status, current_status_date, job_description)" +
            $" VALUES ('{jobApplication.CompanyName}', '{jobApplication.CurrentStatus}', '{jobApplication.CurrentStatusDate}', '{jobApplication.JobDescription}');";
        }
        public static string GetDbTableNamesQuery()
        {
            return "SELECT table_name, table_type "
                + "FROM information_schema.tables WHERE table_schema "
                + "NOT IN ('pg_catalog', 'information_schema') "
                + "ORDER BY table_schema, table_name;";
        }
        public static string GetTableFieldNamesQuery(string tableName)
        {
            return "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS "
                + $"WHERE TABLE_NAME = '{tableName}' "
                + "ORDER BY ORDINAL_POSITION;";
        }
        public static string CreateNewDsaSolutionQuery(int problemId, string solution)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            return $"INSERT INTO dsa_solution (problem_id, solution, date_completed) VALUES ({problemId}, '{solution}', '{today}') RETURNING id;";
        }
        public static string UpdateDsaProblemDateCompletedTodayIdQuery(int problemId)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            return $"UPDATE dsa_problem SET date_completed='{today}' WHERE id={problemId};";
        }
    }
}