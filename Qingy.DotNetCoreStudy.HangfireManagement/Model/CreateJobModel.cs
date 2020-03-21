using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qingy.DotNetCoreStudy.HangfireManagement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateJobModel
    {
        //public static void AddOrUpdate<T>(string recurringJobId, 
        //Expression<Func<T, Task>> methodCall, 
        //string cronExpression, TimeZoneInfo timeZone = null, string queue = "default");

        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desciption { get; set; }
        /// <summary>
        /// 任务组Id
        /// </summary>
        public Guid groupId { get; set; }
        
        public string executeClassName
        { 
            get; set;
        }
        /// <summary>
        /// 参数
        /// </summary>
        public string argument { get; set; }
        /// <summary>
        /// 任务队列（hangfire一般默认default）
        /// </summary>
        public string queueName { get; set; }
    }
}
