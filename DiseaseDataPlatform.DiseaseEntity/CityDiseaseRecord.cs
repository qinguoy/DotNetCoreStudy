using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiseaseDataPlatform.DiseaseEntity
{
    public class CityDiseaseRecord
    {

        [Key]
        public Guid Id { get; set; }

        public Guid ProvinceDiseaseRecordId { get; set; }
        [ForeignKey("ProvinceDiseaseRecordId")]
        public ProvinceDiseaseRecord ProvinceDiseaseRecord { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        #region
        /// <summary>
        /// 
        /// </summary>
        public int? TodayConfirmQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TodaySuspectQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TodayDeadQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TodayHealQty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdated { get; set; }
        #endregion


        /// <summary>
        /// 确诊数
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
        public bool ShowRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ShowHeal { get; set; }
        /// <summary>
        /// 死亡比例
        /// </summary>
        public double? DeadRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? HealRate { get; set; }
        /// <summary>
        /// 统计日期
        /// </summary>
        public DateTime StatDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
