using Microsoft.AspNetCore.Mvc;

namespace MachinistSAssistant.Services.Documentation
{
    public interface ISLHMill
    {
        public IResult GetDocumentation(Models.ProgramParameters.SLHMill progParam);
    }
}
