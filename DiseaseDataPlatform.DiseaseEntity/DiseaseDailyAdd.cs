using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiseaseDataPlatform.DiseaseEntity
{
    /// <summary>
    /// 每日新增
    /// </summary>
    public class DiseaseDailyAdd
    {
        [Key]
        public Guid Id { get; set; }
        public int? ConfirmQty { get; set; }
        public int? SuspectQty { get; set; }
        public int? DeadQty { get; set; }
        public int? HealQty { get; set; }
        public double? DeadRate { get; set; }
        public double? HealRate { get; set; }
        public string Date { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }
}
