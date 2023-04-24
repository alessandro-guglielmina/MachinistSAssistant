using MachinistSAssistant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Crypto.IO;

namespace MachinistSAssistant.Enpoints;
public class SLHMill : Internal.IEndpoints
{
    private const string ContentType = "application/json";
    private const string Tag = "SLHMill";
    private const string BaseRoute = "slhmill";
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<Services.Documentation.ISLHMill, Services.Documentation.SLHMill>();
        services.AddSingleton<Services.MachiningParameters.ISLHMill, Services.MachiningParameters.SLHMill>();
        services.AddSingleton<Services.ProgramParameters.ISLHMill, Services.ProgramParameters.SLHMill>();
    }
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(BaseRoute, GetDocumentation)
            .WithName("GetDocumentation")
            .Accepts<Models.ApplicationParameters.SLHMill>(ContentType)
            .Produces<MemoryStream>(200)
            .WithTags(Tag);
    }
    internal static async Task<IResult> GetDocumentation(
        [FromBody] Models.ApplicationParameters.SLHMill appParam,
        Services.MachiningParameters.ISLHMill machParamService,
        Services.ProgramParameters.ISLHMill progParamService,
        Services.Documentation.ISLHMill docService)
    {
        var machParam = await machParamService.GetMachiningParameters(appParam);
        var progParam = progParamService.GetProgramParameters(appParam, machParam);
        var docMemStream = docService.GetDocumentation(progParam);
        return Results.Ok(docMemStream);
    }
}