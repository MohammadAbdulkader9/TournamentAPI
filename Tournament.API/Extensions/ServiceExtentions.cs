namespace Tournament.API.Extensions
{
    public static class ServiceExtentions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(builder =>
            {
                builder.AddPolicy("AllowAll", p =>
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
            });
        }
    }
}
