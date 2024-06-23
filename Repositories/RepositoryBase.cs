using System.Data.SqlClient;

namespace WPF_LoginForm.Repositories
{
    /// <summary>
    /// Esta clase está destinada para albergar lo concerniente acerca de la conexión a DB.
    /// </summary>
    public abstract class RepositoryBase
    {
        string _connectionString = "Server=(Local); Database=MVVMLoginDb; Integrated Security=true";
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
