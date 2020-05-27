using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using PrestadorServico.Infra.Context;
using Microsoft.Extensions.Configuration;

using PrestadorServico.Domain.Repositories;
using PrestadorServico.Infra.Repositories;
using PrestadorServico.Domain.Handlers;

namespace PrestadorServico.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) { 
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            string strConn = Configuration.GetConnectionString("BDServico"); 
            // services.AddDbContext<DataContext>(options => options.UseSqlServer(strConn));

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BDServicos"));

            services.AddTransient<IServicoRepository, ServicoRepository>();
            services.AddTransient<ServicoHandler, ServicoHandler>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors( option =>
                            option.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin());

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
