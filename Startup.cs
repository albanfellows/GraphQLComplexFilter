using GraphQLComplexFilter.Module1;
using GraphQLComplexFilter.Module2;
using GreenDonut;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddTypeExtension<FirstQuery>()
                .AddTypeExtension<SecondQuery>()
                .AddType<FirstType>()
                .AddType<SecondType>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddDataLoader<IDataLoader<int, FirstClass>, FirstDataLoader>()
                .AddDataLoader<IDataLoader<int, SecondClass>, SecondDataLoader>();

            services.AddPooledDbContextFactory<FirstDbContext>(options => options.UseSqlite("Data Source=filtertest.db"));
            services.AddPooledDbContextFactory<SecondDbContext>(options => options.UseSqlite("Data Source=filtertest.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
