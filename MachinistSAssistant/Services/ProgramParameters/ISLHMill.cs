namespace MachinistSAssistant.Services.ProgramParameters
{
    public interface ISLHMill
    {
        public Models.ProgramParameters.SLHMill GetProgramParameters(Models.ApplicationParameters.SLHMill appParam, Models.MachiningParameters.SLHMill machParam);
    }
}
