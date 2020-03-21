using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DiseaseDataPlatform.DiseaseEntity;
using DiseaseDataPlatform.WebApi.Service;
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

namespace DiseaseDataPlatform.WebApi
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
                var xmlPathByModel = Path.Combine(AppContext.BaseDirectory, "DiseaseDataPlatform.WebApi.xml");
                p.IncludeXmlComments(xmlPathByModel);
                // c.OperationFilter<HttpHeaderOperation>(); // ���httpHeader����
            });
            #endregion

            services.AddDbContext<DiseaseDataContext>(p => p.UseMySql(Configuration.GetConnectionString("DiseaseDataConnection")));

            services.AddHttpClient();  //ע��HttpClient

            var storage = new MySqlStorage(Configuration.GetConnectionString("DiseaseJobConnection")
                  , new MySqlStorageOptions { PrepareSchemaIfNecessary = true, TablePrefix = "Disease" });
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
            //��������
            services.AddCors(options => options.AddPolicy("myCors",
            builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
            //AllowAnyMethod�����������������еķ�����GET/POST/PUT/DELETE �ȷ���  �������������Ҫ AllowAnyMethod("GET","POST") ���������з��ʷ���������
            //AllowAnyHeader�����κε�Headerͷ������    �й�ͷ��������������þͲ����������
            //AllowAnyOrigin �����κ���Դ
            //AllowCredentials ����ƾ����Դ ������AllowAnyOrigin һ��ͬʱʹ��
            //����Ϊָ������ſɷ��ʣ��ɼ���.WithOrigins("www.xxx.com","www.xx2.com")


            services.AddScoped<IDiseaseService, DiseaseService>();

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
            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiseaseDataPlatform API V1");
                c.RoutePrefix = string.Empty;
            });
            //hangfire
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<IDiseaseService>("SyncDiseaseData", p => p.SyncDiseaseData(), "0 9,12,18,0 * * ?");
            RecurringJob.AddOrUpdate<IDiseaseService>("SyncDiseaseDataToFile", p => p.SyncToFile(), "0 9,12,18,0 * * ?");

            app.UseCors("myCors");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
