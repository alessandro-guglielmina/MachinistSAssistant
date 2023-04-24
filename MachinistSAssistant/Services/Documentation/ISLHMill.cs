namespace MachinistSAssistant.Services.Documentation
{
    public interface ISLHMill
    {
        public MemoryStream GetDocumentation(Models.ProgramParameters.SLHMill progParam);
    }
}
