using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Winton.Extensions.Configuration.Consul.Website
{
    internal sealed class Startup
    {
        private const string _AppTitle = "Test Website";
        private const string _Version = "v1";
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app)
        {
            app
                .UseDeveloperExceptionPage()
                .UseMvc()
                .UseSwagger()
                .UseSwaggerUI(c => { c.SwaggerEndpoint($"{_Version}/swagger.json", _AppTitle); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwaggerGen(c => { c.SwaggerDoc(_Version, new Info { Title = _AppTitle, Version = _Version }); })
                .AddSingleton(_configuration)
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}