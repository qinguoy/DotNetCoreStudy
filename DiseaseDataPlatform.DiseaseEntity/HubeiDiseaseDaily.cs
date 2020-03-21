using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiseaseDataPlatform.DiseaseEntity
{
    public class HubeiDiseaseDaily
    {
        [Key]
        public Guid Id { get; set; }
        public string Date { get; set; }
        public int? HubeiAddQty { get; set; }
        public int? CountryAddQty { get; set; }
        public int? NotHebeiAddQty { get; set; }

        #region 死亡率
        public double? HubeiDeadRate { get; set; }
        public double? NotHebeiDeadRate { get; set; }
        public double? CountryDeadRate { get; set; }
        #endregion
        #region 治愈率
        public double? HubeiHealRate { get; set; }
        public double? NotHubeiHealRate { get; set; }
        public double? CountryHealRate { get; set; }
        #endregion
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }
}
