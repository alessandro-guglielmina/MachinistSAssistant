using Dapper;

namespace MachinistSAssistant.Services.MachiningParameters;
public class SLHMill: ISLHMill
{
    private readonly Data.IDbConnectionFactory _connectionFactory;

    public SLHMill(Data.IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task<Models.MachiningParameters.SLHMill> GetMachiningParameters(Models.ApplicationParameters.SLHMill appParam)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return connection.QuerySingleOrDefault<Models.MachiningParameters.SLHMill>(
            @"SELECT CircularRampLead, CircularRampChipThickness, CircularRampCuttingSpeed, RadialStockRemoval FROM SLHMill WHERE SLHType = @SLHType AND ToolReferenceDiameter = @ToolReferenceDiameter LIMIT 1", appParam);
    }
}