using Dapper;

namespace MachinistSAssistant.Services.CuttingParametersServices
{
    public class SLHMill : ISLHMill
    {
        private readonly Data.IDbConnectionFactory _connectionFactory;

        public SLHMill(Data.IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<Models.CuttingParameters.SLHMill> GetCuttingParameters(Models.ApplicationParameters.SLHMill SLHMillAppParam)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return connection.QuerySingleOrDefault<Models.CuttingParameters.SLHMill>(
                "SELECT (AxialRampLead, AxialRampCuttingSpeed) FROM @ToolType WHERE SLHType = @SLHType, ToolReferenceDiameter = @ToolReferenceDiameter, LIMIT 1", SLHMillAppParam);
        }
    }
}
