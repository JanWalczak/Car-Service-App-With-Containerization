namespace Ssjw.EAutoService.ClientAppUSvc.RestSvc
{
    using Microsoft.OpenApi.Models;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Ssjw.EAutoService.ClientAppUSvc.WebSvc",
                    Version = "v1"
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ssjw.EAutoService.ClientAppUSvc.WebSvc v1"));
            }
            /* AT
            app.UseHttpsRedirection( );
            */
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
