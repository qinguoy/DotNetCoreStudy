using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace QinGy.MarketPlatform.ProductCenterApi
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
            //添加SwaggerGen，配置api说明xml文档
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "ProductApi", Version = "v1" }
                    );
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "QinGy.MarketPlatform.ProductCenterApi.xml"); //程序说明xml文档路径
                p.IncludeXmlComments(xmlPath);
            });
            services.AddDbContext<ProductCenterEntity.ProductCenterContext>(p => p.UseMySql(Configuration.GetConnectionString("ProductcenterConnection"), c => c.MigrationsAssembly("QinGy.MarketPlatform.ProductCenterApi")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //注册swagger插件
            app.UseSwagger(p=>p.RouteTemplate= "{documentName}/swagger.json");
            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint("/productcenterapi/swagger.json", "productapi v1");
               // p.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductApi V1");//注意v1是与AddSwaggerGen中指定的名称一致
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
