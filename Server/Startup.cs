using GraphQLComplexFilter.Interfaces;
using GraphQLComplexFilter.Module1;
using GraphQLComplexFilter.Module2;
using GreenDonut;
using HotChocolate.Data.Filters;
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

namespace GraphQLComplexFilter.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();

            services.AddPooledDbContextFactory<FirstDbContext>(options => options.UseSqlite("Data Source=filtertest.db"));
            services.AddPooledDbContextFactory<SecondDbContext>(options => options.UseSqlite("Data Source=filtertest.db"));

            services.AddGraphQLServer()
                .AddProjections()
                .AddFiltering<FirstFilterConvention>()
                .AddFiltering<SecondFilterConvention>()
                .AddSorting()
                //.OnBeforeRegisterDependencies((ctx, def, state)=>
                //{
                //    if (def is { })
                //        Console.WriteLine($"OnBeforeRegisterDependencies {def.Name}");
                //})
                //.OnBeforeCompleteType((ctx, def, state) =>
                //{
                //    if (def is { })
                //        Console.WriteLine($"BeforCompleteType {def.Name}");
                //}, c=>true)
                //.TryAddTypeInterceptor<TestTypeInterceptor>()
                .BindRuntimeType<IFirstInterface, FirstInputType>()
                .BindRuntimeType<ISecondInterface, SecondInputType>()
                //.BindRuntimeType<IFirstInterface,FirstType>()
                //.BindRuntimeType<ISecondInterface, SecondType>()
                .AddType<FirstType>()
                .AddType<SecondType>()
                .AddType<MyEnum>()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddTypeExtension<FirstQuery>()
                .AddTypeExtension<SecondQuery>()
                .AddTypeExtension<FirstMutation>()
                .AddTypeExtension<SecondMutation>()
                .AddTypeExtension<EnumTypeExtension>()
                .AddDataLoader<IDataLoader<int, IFirstInterface>, FirstDataLoader>()
                .AddDataLoader<IDataLoader<int, ISecondInterface>, SecondDataLoader>();
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
