namespace MachinistSAssistant.Services.ProgramParameters.Internal;
public interface ISLHMill
{
    public Models.ProgramParameters.SLHMill CreateProgramParameters(Models.ApplicationParameters.SLHMill appParam, Models.MachiningParameters.SLHMill machParam);
}