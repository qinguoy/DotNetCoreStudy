using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Model
{
    
    public class ChinaDayListItem
    {
        /// <summary>
        /// 确审数
        /// </summary>
        public int? confirm { get; set; }
        /// <summary>
        /// 疑是数
        /// </summary>
        public int? suspect { get; set; }
        /// <summary>
        /// 死亡数
        /// </summary>
        public int? dead { get; set; }
        /// <summary>
        /// 治愈数
        /// </summary>
        public int? heal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? deadRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double healRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
    }
 
    /// <summary>
    /// 每日新增历史
    /// </summary>
    public class DailyNewAddHistoryItem
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// 湖北数
        /// </summary>
        public int? hubei { get; set; }
        /// <summary>
        /// 国内数
        /// </summary>
        public int? country { get; set; }
        /// <summary>
        /// 非湖北数
        /// </summary>
        public int? notHubei { get; set; }
    }
    /// <summary>
    /// 每日死亡历史
    /// </summary>
    public class DailyDeadRateHistoryItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; }
       
        /// <summary>
        /// 湖北比例
        /// </summary>
        public double? hubeiRate { get; set; }
        /// <summary>
        /// 非湖北比例
        /// </summary>
        public double? notHubeiRate { get; set; }
        /// <summary>
        /// 全国比例
        /// </summary>
        public double? countryRate { get; set; }
    }
    /// <summary>
    /// 每日治愈历史
    /// </summary>
    public class DailyHealRateHistoryItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string date { get; set; } 
        /// <summary>
        /// 湖北比例
        /// </summary>
        public double? hubeiRate { get; set; }
        /// <summary>
        /// 非湖北比例
        /// </summary>
        public double? notHubeiRate { get; set; }
        /// <summary>
        /// 全国比例
        /// </summary>
        public double? countryRate { get; set; }
    }
    
    /// <summary>
    /// 今天数据
    /// </summary>
    public class Today
    {
        /// <summary>
        /// 
        /// </summary>
        public int? confirm { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? suspect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? dead { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? heal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isUpdated { get; set; }
    }

    public class Total
    {
        /// <summary>
        /// 确诊数
        /// </summary>
        public int? confirm { get; set; }
        /// <summary>
        /// 疑是数
        /// </summary>
        public int? suspect { get; set; }
        /// <summary>
        /// 死亡数
        /// </summary>
        public int? dead { get; set; }
        /// <summary>
        /// 治愈数
        /// </summary>
        public int? heal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool showRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool showHeal { get; set; }
        /// <summary>
        /// 死亡比例
        /// </summary>
        public double? deadRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? healRate { get; set; }
    }
 
     

    public class ChildrenItem
    {
        /// <summary>
        /// 地区名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 今天数据
        /// </summary>
        public Today today { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public Total total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ChildrenItem> children { get; set; }
    }

    public class AreaTreeItem
    {
        /// <summary>
        /// 地区
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Today today { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Total total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ChildrenItem> children { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ArticleListItem
    {
        /// <summary>
        /// id
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
        public DateTime publish_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? can_use { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 网址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// title
        /// 火神山医院收治患者超900人
        /// </summary>
        public string title { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DiseaseData
    {
        /// <summary>
        /// 最近更新时间
        /// </summary>
        public DateTime lastUpdateTime { get; set; }
        /// <summary>
        /// 汇总信息
        /// </summary>
        public ChinaDayListItem chinaTotal { get; set; }
        /// <summary>
        /// 新增汇总信息
        /// </summary>
        public ChinaDayListItem chinaAdd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isShowAdd { get; set; }
        /// <summary>
        /// 每日日数
        /// </summary>
        public List<ChinaDayListItem> chinaDayList { get; set; }
        /// <summary>
        /// 每日新增
        /// </summary>
        public List<ChinaDayListItem> chinaDayAddList { get; set; }
        /// <summary>
        /// 历史新增
        /// </summary>
        public List<DailyNewAddHistoryItem> dailyNewAddHistory { get; set; }
        /// <summary>
        /// 历史每日死亡比例
        /// </summary>
        public List<DailyDeadRateHistoryItem> dailyDeadRateHistory { get; set; }

        /// <summary>
        /// 历史每日死亡比例
        /// </summary>
        public List<DailyHealRateHistoryItem> dailyHealRateHistory { get; set; }
 
        /// <summary>
        /// 
        /// </summary>
        public List<AreaTreeItem> areaTree { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ArticleListItem> articleList { get; set; }
    }

    public class DiseaseResponse
    {
        public int? ret { get; set; }
        public string data { get; set; }
    }
}
