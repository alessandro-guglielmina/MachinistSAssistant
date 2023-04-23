using Org.BouncyCastle.Crypto.IO;

namespace MachinistSAssistant.Enpoints;
public class SLHMill : Internal.IEndpoints
{
    private const string ContentType = "application/json";
    private const string Tag = "SLHMill";
    private const string BaseRoute = "slhmill";
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        throw new NotImplementedException();
    }
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet(BaseRoute, GetDocumentation)
            .WithName("GetDocumentation")
            .Accepts<Models.ApplicationParameters.SLHMill>(ContentType)
            .Produces<IEnumerable<Models.ProgramParameters.SLHMill>>(200)
            .WithTags(Tag);
    }
    internal static async Task<IResult> GetDocumentation(
        Models.ApplicationParameters.SLHMill appParam,
        Services.MachiningParameters.SLHMill machParamService,
        Services.ProgramParameters.SLHMill progParamService,
        Services.Documentation.SLHMill docService)
    {
        var machParam = await machParamService.GetMachiningParameters(appParam);
        var progParam = progParamService.GetProgramParameters(appParam, machParam);
        var docMemStream = docService.GetDocumentation(progParam);
        return Results.Ok(docMemStream);
    }
}