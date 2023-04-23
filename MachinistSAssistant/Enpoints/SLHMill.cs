using MachinistSAssistant.Enpoints.Internal;

namespace MachinistSAssistant.Enpoints;
public class SLHMill : IEndpoints
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
            app.MapGet(BaseRoute, GetCuttingParameters)
                .WithName("GetCuttingParameters")
                .Produces<IEnumerable<Book>>(200)
                .WithTags(Tag);
        }
        internal static async Task<Models.CuttingParameters.SLHMill> GetCuttingParameters(
        Services.CuttingParameters.ISLHMill SLHMillService)
        {
            if (Services.CuttingParameters.ISLHMill.Wor is not null && !string.IsNullOrWhiteSpace(searchTerm))
            {
                var matchedBooks = await bookService.SearchByTitleAsync(searchTerm);
                return Results.Ok(matchedBooks);
            }

            var books = await bookService.GetAllAsync();
            return Results.Ok(books);
        }
    }