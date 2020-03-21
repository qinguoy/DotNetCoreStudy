using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qingy.DotNetCoreStudy.HangfireManagement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        ///id
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string taskName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 任务组Id
        /// </summary>
        public Guid groupId { get; set; }
        /// <summary>
        /// 执行类
        /// </summary>
        public string executeClassName { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public string arguments { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime created { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime LastModified { get; set; }
        /// <summary>
        /// 触发器
        /// </summary>
        public List<TaskTriggerModel> triggerList { get; set; }
    }

     
}
