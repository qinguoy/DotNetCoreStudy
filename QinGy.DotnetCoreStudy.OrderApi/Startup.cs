using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace QinGy.MarketPlatform.OrderApi
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
            //���SwaggerGen������api˵��xml�ĵ�
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("orderapi",
                    new OpenApiInfo { Title = "OrderApi", Version = "v1" }
                    );
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "QinGy.MarketPlatform.OrderApi.xml"); //����˵��xml�ĵ�·��
                p.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //ע��swagger���
            app.UseSwagger(p=>p.RouteTemplate= "{documentName}/swagger.json");

            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint("/orderapi/swagger.json", "orderapi v1");
               // p.SwaggerEndpoint("/swagger/v1/swagger.json", "OrderApi V1");//ע��v1����AddSwaggerGen��ָ��������һ��
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
