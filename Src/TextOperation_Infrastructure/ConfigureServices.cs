namespace TextOperation_Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IRegexService, RegexService>();
        services.AddScoped<IRegextControllerOperation, RegextControllerOperation>();


        return services;
    }
}
