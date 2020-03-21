using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qingy.DotNetCoreStudy.HangfireJobEntity
{
    /// <summary>
    /// 作业任务
    /// </summary>
    public class HangfireTask
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public Guid GroupId { get; set; }
        /// <summary>
        /// 执行类名
        /// </summary>
        [MaxLength(300)]
        public string ExecuteClassName { get; set; }
        [MaxLength(1000)]
        public string Arguments { get; set; }
        [MaxLength(200)]
        public string Queue { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public List<HangfireTaskTrigger> TriggerList { get; set; }
    }
}
