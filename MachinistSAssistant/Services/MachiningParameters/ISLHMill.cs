namespace MachinistSAssistant.Services.MachiningParameters
{
    public interface ISLHMill
    {
        public Task<Models.MachiningParameters.SLHMill> GetMachiningParameters(Models.ApplicationParameters.SLHMill appParam);
    }
}
