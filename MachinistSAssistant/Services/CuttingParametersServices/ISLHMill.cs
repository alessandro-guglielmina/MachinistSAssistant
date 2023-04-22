namespace MachinistSAssistant.Services.CuttingParametersServices
{
    public interface ISLHMill
    {
        public Task<Models.CuttingParameters.SLHMill> GetCuttingParameters(Models.ApplicationParameters.SLHMill SLHMillAppParam);
    }
}
