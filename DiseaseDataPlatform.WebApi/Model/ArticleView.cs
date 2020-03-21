using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Model
{
    public class ArticleView
    {
        public Guid id { get; set; } 
        /// <summary>
        /// cms id
        /// </summary> 
        public string cmsId { get; set; }
        /// <summary>
        /// 源
        /// </summary> 
        public string source { get; set; }
        /// <summary>
        /// 媒体
        /// </summary> 
        public string media { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime publishTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? canUse { get; set; }
        /// <summary>
        /// 描述
        /// </summary> 
        public string description { get; set; }
        /// <summary>
        /// 网址
        /// </summary> 
        public string url { get; set; }
        /// <summary>
        /// title 
        /// </summary> 
        public string title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime created { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime lastModified { get; set; }
    }
}
