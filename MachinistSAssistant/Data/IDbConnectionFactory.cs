using System.Data;

namespace MachinistSAssistant.Data
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
