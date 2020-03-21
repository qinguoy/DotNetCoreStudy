using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qingy.DotNetCoreStudy.HangfireJobEntity
{
    /// <summary>
    /// 作业触发器
    /// </summary>
    public class HangfireTaskTrigger
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 触发器名称
        /// </summary>
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// 作业Id
        /// </summary>
        public Guid HangfireTaskId { get; set; }
        /// <summary>
        /// 作业
        /// </summary>
        [ForeignKey("HangfireTaskId")]
        public HangfireTask HangfireTask { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(1000)]
        public string Description { get; set; }
        /// <summary>
        /// cron表达式
        /// </summary>
        [MaxLength(100)]
        public string Cron { get; set; }
        /// <summary>
        /// 0-等待，1-执行中,2-暂停
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime LastModified { get; set; }

    }
}
