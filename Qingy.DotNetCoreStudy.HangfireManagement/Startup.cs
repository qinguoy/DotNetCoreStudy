using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MySql.Core;
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
using Qingy.DotNetCoreStudy.HangfireJobEntity;

namespace Qingy.DotNetCoreStudy.HangfireManagement
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

            #region swagger
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "WishSalesCenter API 接口文档",
                    Contact = new OpenApiContact
                    {
                        Name = "qinguoyong",
                        Email = "909803191@qq.com",
                        Url = new Uri("http://xxxx.com"),
                    },
                });
                // 为 Swagger JSON and UI设置xml文档注释路径
                var xmlPathByModel = Path.Combine(AppContext.BaseDirectory, "Qingy.DotNetCoreStudy.HangfireManagement.xml");
                p.IncludeXmlComments(xmlPathByModel);
                // c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });
            #endregion

            services.AddDbContext<HangfireTaskContext>(p => p.UseMySql(Configuration.GetConnectionString("TimingTaskConnection")));

            services.AddHttpClient();  //注入HttpClient

            var storage = new MySqlStorage(Configuration.GetConnectionString("TimingTaskConnection")
                  , new MySqlStorageOptions { PrepareSchemaIfNecessary = true, TablePrefix = "" });
            //GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(storage, new MySqlStorageOptions
            //{
            //    TransactionIsolationLevel = IsolationLevel.ReadCommitted, //  事务隔离级别。默认值为读提交。
            //    QueuePollInterval = TimeSpan.FromSeconds(15),             // 作业队列轮询间隔。默认值为15秒
            //    JobExpirationCheckInterval = TimeSpan.FromHours(1),       //  作业过期检查间隔（管理过期记录）。默认为1小时
            //    CountersAggregateInterval = TimeSpan.FromMinutes(5),      // 间隔到聚合计数器。默认为5分钟
            //    PrepareSchemaIfNecessary = true,                          // 如果设置为true，则创建数据库表。默认值为true
            //    DashboardJobListLimit = 50000,                            // 仪表板作业列表上限。默认值为50000 
            //    TransactionTimeout = TimeSpan.FromMinutes(1),             // 事务超时。默认为1分钟
            //}));  

            //hangfire
            services.AddHangfire(p => p.UseStorage(storage));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireServer();
            app.UseHangfireDashboard();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HangfireJob API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
