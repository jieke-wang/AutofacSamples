using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Llibrary.Interceptors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace WebApiSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiSample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiSample v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    
        // 使用Autofac注册服务
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            // containerBuilder.RegisterType<ConsoleLogInterceptor>();

            // containerBuilder
            //     .RegisterType<Llibrary.Service.Service1.ServiceImplement>()
            //     .As<Llibrary.Service.Service1.IService>()
            //     .SingleInstance()
            //     .EnableInterfaceInterceptors();

            // containerBuilder
            //     .RegisterType<Llibrary.Service.Service2.ServiceImplement>()
            //     .As<Llibrary.Service.Service2.IService>()
            //     .InstancePerLifetimeScope()
            //     .EnableClassInterceptors();

            // containerBuilder
            //     .RegisterType<Llibrary.Service.Service3.ServiceImplement>()
            //     .As<Llibrary.Service.Service3.IService>()
            //     .InstancePerDependency()
            //     .PropertiesAutowired();

            containerBuilder.RegisterModule<Llibrary.LlibraryModule>(); // 注册模块
        }
    }
}
