using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DiseaseDataPlatform.DiseaseEntity
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article
    {
        [Key]
        public Guid Id { get; set; } 
        public Guid DiseaseRecordId { get; set; }
        [ForeignKey("DiseaseRecordId")]
        public DiseaseRecord DiseaseRecord { get; set; }
        /// <summary>
        /// cms id
        /// </summary>
        [MaxLength(100)]
        public string CmsId { get; set; }
        /// <summary>
        /// 源
        /// </summary>
        [MaxLength(200)]
        public string Source { get; set; }
        /// <summary>
        /// 媒体
        /// </summary>
        [MaxLength(250)]
        public string Media { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? CanUse { get; set; }
        /// <summary>
        /// 描述
        /// 例如 ：截至2月11日22时30分，从武汉市定点收治医院转诊而来的确诊患者，陆续抵达火神山医院，患者收治总数达到925人。
        /// </summary>
        [MaxLength(4000)]
        public string Description { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        [MaxLength(500)]
        public string Url { get; set; }
        /// <summary>
        /// title 
        /// </summary>
        [MaxLength(500)]
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }

}
