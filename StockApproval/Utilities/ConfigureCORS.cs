namespace StockApproval.Utilities
{
    public static class ConfigureCORS
    {
        public static void EnableCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.WithOrigins("http://localhost:4200", "https://stock.committedcargo.net")
                           .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS")
                           .AllowAnyHeader()
                           .AllowCredentials());
            });
        }
    }
}
