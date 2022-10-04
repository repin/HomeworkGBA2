using Dapper;
using MetricsManager.Models;
using Microsoft.Extensions.Options;
using System.Data.SQLite;

namespace MetricsManager.Services.Impl
{

    public class AgentRepository : IAgentRepository
    {

        #region Services

        private readonly IOptions<DatabaseOptions> _databaseOptions;

        #endregion

        public AgentRepository(IOptions<DatabaseOptions> databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }


        public void Create(AgentInfo item)
        {

            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Open();
            connection.Execute("INSERT INTO agentinfo(agentaddress, enable) VALUES(@agentaddress, @enable)", new
            {
                agentaddress = item.AgentAddress,
                enable = item.Enable
            });

        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Open();
            connection.Execute("DELETE FROM agentinfo WHERE id=@id",
            new
            {
                id = id
            });
            //using var cmd = new SQLiteCommand(connection);
            //// Прописываем в команду SQL-запрос на удаление данных
            //cmd.CommandText = "DELETE FROM agentinfo WHERE id=@id";
            //cmd.Parameters.AddWithValue("@id", id);
            //cmd.Prepare();
            //cmd.ExecuteNonQuery();
        }

        public void Update(AgentInfo item)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Execute("UPDATE agentinfo SET agentaddress = @agentaddress, enable = @enable WHERE id = @id",
            new
            {
                agentaddress = item.AgentAddress,
                enable = item.Enable,
                id = item.id
            });
        }

        public IList<AgentInfo> GetAll()
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            return connection.Query<AgentInfo>("SELECT id, enable, agentaddress FROM agentinfo").ToList();

        }

        public AgentInfo GetById(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            AgentInfo metric = connection.QuerySingle<AgentInfo>("SELECT id, enable, agentaddress FROM agentinfo WHERE id = @id",
            new { id = id });
            return metric;

        }
        public void EnableAgentById(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Execute("UPDATE agentinfo SET enable = @enable WHERE id = @id",
            new
            {
                enable = true,
                id = id
            });
        }
        public void DisableAgentById(int id)
        {
            using var connection = new SQLiteConnection(_databaseOptions.Value.ConnectionString);
            connection.Execute("UPDATE agentinfo SET enable = @enable WHERE id = @id",
            new
            {
                enable = false,
                id = id
            });
        }
    }
}
