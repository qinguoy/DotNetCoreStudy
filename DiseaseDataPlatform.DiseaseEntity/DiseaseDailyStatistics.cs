using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiseaseDataPlatform.DiseaseEntity
{
    /// <summary>
    /// 中国每日统计
    /// </summary>
    public class ChinaDiseaseDailyStatistics
    {
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// 确审数
        /// </summary>
        public int? ConfirmQty { get; set; }
        /// <summary>
        /// 疑是数
        /// </summary>
        public int? SuspectQty { get; set; }
        /// <summary>
        /// 死亡数
        /// </summary>
        public int? DeadQty { get; set; }
        /// <summary>
        /// 治愈数
        /// </summary>
        public int? HealQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? DeadRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HealRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Date { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
