namespace MachinistSAssistant.Services.CuttingParameters
{
    public interface ISLHMill
    {
        public Task<Models.CuttingParameters.SLHMill> GetCuttingParameters(Models.ApplicationParameters.SLHMill SLHMillAppParam);
    }
}
