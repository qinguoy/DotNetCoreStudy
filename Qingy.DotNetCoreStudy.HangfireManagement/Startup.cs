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
                    Title = "WishSalesCenter API �ӿ��ĵ�",
                    Contact = new OpenApiContact
                    {
                        Name = "qinguoyong",
                        Email = "909803191@qq.com",
                        Url = new Uri("http://xxxx.com"),
                    },
                });
                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var xmlPathByModel = Path.Combine(AppContext.BaseDirectory, "Qingy.DotNetCoreStudy.HangfireManagement.xml");
                p.IncludeXmlComments(xmlPathByModel);
                // c.OperationFilter<HttpHeaderOperation>(); // ���httpHeader����
            });
            #endregion

            services.AddDbContext<HangfireTaskContext>(p => p.UseMySql(Configuration.GetConnectionString("TimingTaskConnection")));

            services.AddHttpClient();  //ע��HttpClient

            var storage = new MySqlStorage(Configuration.GetConnectionString("TimingTaskConnection")
                  , new MySqlStorageOptions { PrepareSchemaIfNecessary = true, TablePrefix = "" });
            //GlobalConfiguration.Configuration.UseStorage(new MySqlStorage(storage, new MySqlStorageOptions
            //{
            //    TransactionIsolationLevel = IsolationLevel.ReadCommitted, //  ������뼶��Ĭ��ֵΪ���ύ��
            //    QueuePollInterval = TimeSpan.FromSeconds(15),             // ��ҵ������ѯ�����Ĭ��ֵΪ15��
            //    JobExpirationCheckInterval = TimeSpan.FromHours(1),       //  ��ҵ���ڼ������������ڼ�¼����Ĭ��Ϊ1Сʱ
            //    CountersAggregateInterval = TimeSpan.FromMinutes(5),      // ������ۺϼ�������Ĭ��Ϊ5����
            //    PrepareSchemaIfNecessary = true,                          // �������Ϊtrue���򴴽����ݿ��Ĭ��ֵΪtrue
            //    DashboardJobListLimit = 50000,                            // �Ǳ����ҵ�б����ޡ�Ĭ��ֵΪ50000 
            //    TransactionTimeout = TimeSpan.FromMinutes(1),             // ����ʱ��Ĭ��Ϊ1����
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
