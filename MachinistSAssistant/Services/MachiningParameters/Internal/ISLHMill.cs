namespace MachinistSAssistant.Services.MachiningParameters.Internal;
public interface ISLHMill
{
    public Task<Models.MachiningParameters.SLHMill> GetMachiningParameters(Models.ApplicationParameters.SLHMill SLHMillAppParam);
}