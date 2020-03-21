using DiseaseDataPlatform.DiseaseEntity;
using DiseaseDataPlatform.WebApi.Common;
using DiseaseDataPlatform.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiseaseManagementController : ControllerBase
    {
        private IHttpClientFactory _httpClientFactory = null;
        private DiseaseDataContext _diseaseDataContext = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public DiseaseManagementController(IHttpClientFactory httpClientFactory, DiseaseDataContext diseaseDataContext)
        {
            this._httpClientFactory = httpClientFactory;
            _diseaseDataContext = diseaseDataContext;
        }
        /// <summary>
        /// 同步疫情
        /// </summary>
        /// <returns></returns>
        [HttpPost("syncDiseaseData")]
        public async Task<string> SyncDiseaseData()
        {
            DiseaseAccess access = new DiseaseAccess(_httpClientFactory);
            var response = await access.GetDisease();
            if (response != null || response.ret == 0)
            {
                DateTime threeDayBefore = DateTime.Now.AddDays(-3);
                string nearlyThreeDay = $"{threeDayBefore.Month.ToString().PadLeft(2, '0')}.{threeDayBefore.Day.ToString().PadLeft(2, '0')}";

                string dataString = response.data;
                var data = JsonUtility.Deserialize<DiseaseData>(dataString);
                var existRecord = _diseaseDataContext.DiseaseRecord.FirstOrDefault(p => p.UpdateTime == data.lastUpdateTime);
                if (existRecord != null)
                {
                    return "exists,no need to sync";
                }
                var newRecord = new DiseaseRecord()
                {
                    Id = Guid.NewGuid(),
                    UpdateTime = data.lastUpdateTime,
                };
                _diseaseDataContext.DiseaseRecord.Add(newRecord);
                #region 疫情数据处理
                #region 相关报道
                if (data.articleList != null)
                {
                    List<string> cmsIdList = data.articleList.Select(p => p.cmsId).ToList();
                    var existArticleList = _diseaseDataContext.Article.Where(p => cmsIdList.Contains(p.CmsId)).ToList();
                    foreach (var articleItem in data.articleList)
                    {
                        if (existArticleList.Any(p => p.CmsId == articleItem.cmsId))
                        {
                            continue;
                        }
                        var newArticle = new Article()
                        {
                            Id = Guid.NewGuid(),
                            CmsId = articleItem.cmsId,
                            CanUse = articleItem.can_use,
                            Description = articleItem.desc,
                            Media = articleItem.media,
                            PublishTime = articleItem.publish_time,
                            Source = articleItem.source,
                            Title = articleItem.title,
                            Url = articleItem.url,
                            DiseaseRecordId = newRecord.Id,
                            Created = DateTime.Now,
                            LastModified = DateTime.Now,
                        };
                        _diseaseDataContext.Article.Add(newArticle);
                    }
                }
                #endregion 
                #region 中国疫情每日汇总数据
                List<string> dateList = data.chinaDayList.Select(p => p.date).ToList();
                var existDailyStatList = _diseaseDataContext.DiseaseDailyStatistics.Where(p => dateList.Contains(p.Date)).ToList();
                foreach (var dailyItem in data.chinaDayList)
                {
                    var dailyStat = existDailyStatList.FirstOrDefault(p => p.Date == dailyItem.date);
                    if (dailyStat == null)
                    {
                        dailyStat = new ChinaDiseaseDailyStatistics()
                        {
                            Id = Guid.NewGuid(),
                            Date = dailyItem.date,
                            ConfirmQty = dailyItem.confirm,
                            DeadQty = dailyItem.dead,
                            DeadRate = dailyItem.deadRate,
                            HealQty = dailyItem.heal,
                            HealRate = dailyItem.healRate,
                            SuspectQty = dailyItem.suspect,
                            Created = DateTime.Now,
                            LastModified = DateTime.Now,
                        };
                        _diseaseDataContext.DiseaseDailyStatistics.Add(dailyStat);
                    }
                    else
                    {

                        if (double.Parse(dailyStat.Date) >= double.Parse(nearlyThreeDay))
                        {
                            dailyStat.ConfirmQty = dailyItem.confirm;
                            dailyStat.DeadQty = dailyItem.dead;
                            dailyStat.DeadRate = dailyItem.deadRate;
                            dailyStat.HealQty = dailyItem.heal;
                            dailyStat.HealRate = dailyItem.healRate;
                            dailyStat.SuspectQty = dailyItem.suspect;
                            dailyStat.LastModified = DateTime.Now;
                        }
                    }
                }
                #endregion
                #region 中国疫情每日新增数据
                List<string> dailyAddDateList = data.chinaDayAddList.Select(p => p.date).ToList();
                var existDailyAddList = _diseaseDataContext.DiseaseDailyAdd.Where(p => dateList.Contains(p.Date)).ToList();
                foreach (var dailyAddItem in data.chinaDayAddList)
                {
                    var dailyAdd = existDailyAddList.FirstOrDefault(p => p.Date == dailyAddItem.date);
                    if (dailyAdd == null)
                    {
                        dailyAdd = new DiseaseDailyAdd()
                        {
                            Id = Guid.NewGuid(),
                            Date = dailyAddItem.date,
                            ConfirmQty = dailyAddItem.confirm,
                            DeadQty = dailyAddItem.dead,
                            DeadRate = dailyAddItem.deadRate,
                            HealQty = dailyAddItem.heal,
                            HealRate = dailyAddItem.healRate,
                            SuspectQty = dailyAddItem.suspect,
                            Created = DateTime.Now,
                            LastModified = DateTime.Now,
                        };
                        _diseaseDataContext.DiseaseDailyAdd.Add(dailyAdd);
                    }
                    else
                    {
                        if (double.Parse(dailyAdd.Date) >= double.Parse(nearlyThreeDay))
                        {
                            dailyAdd.ConfirmQty = dailyAddItem.confirm;
                            dailyAdd.DeadQty = dailyAddItem.dead;
                            dailyAdd.DeadRate = dailyAddItem.deadRate;
                            dailyAdd.HealQty = dailyAddItem.heal;
                            dailyAdd.HealRate = dailyAddItem.healRate;
                            dailyAdd.SuspectQty = dailyAddItem.suspect;
                            dailyAdd.LastModified = DateTime.Now;
                        }
                    }
                }
                #endregion
                #region 中国疫情每日新增数据
                List<string> dailyNewHistoryList = data.dailyNewAddHistory.Select(p => p.date).ToList();
                var existDailyHistoryList = _diseaseDataContext.HubeiDiseaseDaily.Where(p => dateList.Contains(p.Date)).ToList();
                foreach (var dailyHistoryItem in data.dailyNewAddHistory)
                {
                    var dailyHistory = existDailyHistoryList.FirstOrDefault(p => p.Date == dailyHistoryItem.date);
                    if (dailyHistory == null)
                    {
                        dailyHistory = new HubeiDiseaseDaily()
                        {
                            Id = Guid.NewGuid(),
                            Date = dailyHistoryItem.date,
                            HubeiAddQty = dailyHistoryItem.hubei,
                            NotHebeiAddQty = dailyHistoryItem.notHubei,
                            CountryAddQty = dailyHistoryItem.country,
                            Created = DateTime.Now,
                            LastModified = DateTime.Now,
                        };
                        var deadRateHistory = data.dailyDeadRateHistory.FirstOrDefault(p => p.date == dailyHistoryItem.date);
                        if (deadRateHistory != null)
                        {
                            dailyHistory.HubeiDeadRate = deadRateHistory.hubeiRate;
                            dailyHistory.NotHebeiDeadRate = deadRateHistory.notHubeiRate;
                            dailyHistory.CountryDeadRate = deadRateHistory.countryRate;
                        }
                        var healRateHistory = data.dailyHealRateHistory.FirstOrDefault(p => p.date == dailyHistoryItem.date);
                        if (healRateHistory != null)
                        {
                            dailyHistory.HubeiHealRate = healRateHistory.hubeiRate;
                            dailyHistory.NotHubeiHealRate = healRateHistory.notHubeiRate;
                            dailyHistory.CountryHealRate = healRateHistory.countryRate;
                        }
                        _diseaseDataContext.HubeiDiseaseDaily.Add(dailyHistory);
                    }
                    else
                    {
                        if (double.Parse(dailyHistory.Date) < double.Parse(nearlyThreeDay))
                        {
                            continue;
                        }
                        dailyHistory.HubeiAddQty = dailyHistoryItem.hubei;
                        dailyHistory.NotHebeiAddQty = dailyHistoryItem.notHubei;
                        dailyHistory.CountryAddQty = dailyHistoryItem.country;
                        var deadRateHistory = data.dailyDeadRateHistory.FirstOrDefault(p => p.date == dailyHistoryItem.date);
                        if (deadRateHistory != null)
                        {
                            dailyHistory.HubeiDeadRate = deadRateHistory.hubeiRate;
                            dailyHistory.NotHebeiDeadRate = deadRateHistory.notHubeiRate;
                            dailyHistory.CountryDeadRate = deadRateHistory.countryRate;
                        }
                        var healRateHistory = data.dailyHealRateHistory.FirstOrDefault(p => p.date == dailyHistoryItem.date);
                        if (healRateHistory != null)
                        {
                            dailyHistory.HubeiHealRate = healRateHistory.hubeiRate;
                            dailyHistory.NotHubeiHealRate = healRateHistory.notHubeiRate;
                            dailyHistory.CountryHealRate = healRateHistory.countryRate;
                        }
                        dailyHistory.LastModified = DateTime.Now;
                    }
                }
                #endregion
                #region 疫情详情
                var diseaseDataList = _diseaseDataContext.CountryDiseaseRecord.Include(p => p.ProvinceDiseaseRecordList)
                    .ThenInclude(p => p.CityDiseaseRecordList)
                    .Where(p => p.StatDate == data.lastUpdateTime.Date)
                    .ToList();
                foreach (var areaItem in data.areaTree)
                {
                    var existCountryDisease = diseaseDataList.FirstOrDefault(p => p.CountryName == areaItem.name && p.StatDate == data.lastUpdateTime.Date);
                    if (existCountryDisease == null)
                    {
                        var newCountryRecord = new CountryDiseaseRecord()
                        {
                            Id = Guid.NewGuid(),
                            CountryName = areaItem.name,
                            ProvinceDiseaseRecordList = new List<ProvinceDiseaseRecord>(),
                            //当天累计
                            ConfirmQty = areaItem.total.confirm,
                            HealQty = areaItem.total.heal,
                            HealRate = areaItem.total.healRate,
                            DeadQty = areaItem.total.dead,
                            DeadRate = areaItem.total.deadRate,
                            SuspectQty = areaItem.total.suspect,
                            ShowHeal = areaItem.total.showHeal,
                            ShowRate = areaItem.total.showRate,

                            //当天的
                            TodayconfirmQty = areaItem.today.confirm,
                            TodayDeadQty = areaItem.today.dead,
                            TodayHealQty = areaItem.today.heal,
                            TodaySuspectQty = areaItem.today.suspect,
                            IsUpdated = areaItem.today.isUpdated,
                            StatDate = data.lastUpdateTime.Date,
                            Created = DateTime.Now,
                            LastModified = DateTime.Now,
                        };
                        //省级
                        if (areaItem.children != null)
                        {
                            foreach (var provinceItem in areaItem.children)
                            {
                                var newProvinceRecord = new ProvinceDiseaseRecord()
                                {
                                    Id = Guid.NewGuid(),
                                    CountryDiseaseRecordId = newCountryRecord.Id,
                                    Province = provinceItem.name,
                                    //当天累计
                                    ConfirmQty = provinceItem.total.confirm,
                                    HealQty = provinceItem.total.heal,
                                    HealRate = provinceItem.total.healRate,
                                    DeadQty = provinceItem.total.dead,
                                    DeadRate = provinceItem.total.deadRate,
                                    SuspectQty = provinceItem.total.suspect,
                                    ShowHeal = provinceItem.total.showHeal,
                                    ShowRate = provinceItem.total.showRate,

                                    //当天的
                                    TodayConfirmQty = provinceItem.today.confirm,
                                    TodayDeadQty = provinceItem.today.dead,
                                    TodayHealQty = provinceItem.today.heal,
                                    TodaySuspectQty = provinceItem.today.suspect,
                                    IsUpdated = provinceItem.today.isUpdated,
                                    CityDiseaseRecordList = new List<CityDiseaseRecord>(),
                                    StatDate = data.lastUpdateTime.Date,
                                    Created = DateTime.Now,
                                    LastModified = DateTime.Now,
                                };
                                //市级
                                if (provinceItem.children != null)
                                {
                                    foreach (var cityItem in provinceItem.children)
                                    {
                                        var newCityRecord = new CityDiseaseRecord()
                                        {
                                            Id = Guid.NewGuid(),
                                            ProvinceDiseaseRecordId = newProvinceRecord.Id,
                                            City = cityItem.name,
                                            //当天累计
                                            ConfirmQty = cityItem.total.confirm,
                                            HealQty = cityItem.total.heal,
                                            HealRate = cityItem.total.healRate,
                                            DeadQty = cityItem.total.dead,
                                            DeadRate = cityItem.total.deadRate,
                                            SuspectQty = cityItem.total.suspect,
                                            ShowHeal = cityItem.total.showHeal,
                                            ShowRate = cityItem.total.showRate,

                                            //当天的
                                            TodayConfirmQty = cityItem.today.confirm,
                                            TodayDeadQty = cityItem.today.dead,
                                            TodayHealQty = cityItem.today.heal,
                                            TodaySuspectQty = cityItem.today.suspect,
                                            IsUpdated = cityItem.today.isUpdated,
                                            StatDate = data.lastUpdateTime.Date,
                                            Created = DateTime.Now,
                                            LastModified = DateTime.Now,
                                        };
                                        newProvinceRecord.CityDiseaseRecordList.Add(newCityRecord);
                                    }
                                }
                                newCountryRecord.ProvinceDiseaseRecordList.Add(newProvinceRecord);
                            }
                        }
                        _diseaseDataContext.CountryDiseaseRecord.Add(newCountryRecord);
                    }
                    else   //更新
                    {
                        existCountryDisease.ConfirmQty = areaItem.total.confirm;
                        existCountryDisease.HealQty = areaItem.total.heal;
                        existCountryDisease.HealRate = areaItem.total.healRate;
                        existCountryDisease.DeadQty = areaItem.total.dead;
                        existCountryDisease.DeadRate = areaItem.total.deadRate;
                        existCountryDisease.SuspectQty = areaItem.total.suspect;
                        existCountryDisease.ShowHeal = areaItem.total.showHeal;
                        existCountryDisease.ShowRate = areaItem.total.showRate;

                        //当天的
                        existCountryDisease.TodayconfirmQty = areaItem.today.confirm;
                        existCountryDisease.TodayDeadQty = areaItem.today.dead;
                        existCountryDisease.TodayHealQty = areaItem.today.heal;
                        existCountryDisease.TodaySuspectQty = areaItem.today.suspect;
                        existCountryDisease.IsUpdated = areaItem.today.isUpdated;
                        existCountryDisease.LastModified = DateTime.Now;
                        //省级
                        if (areaItem.children != null)
                        {
                            foreach (var provinceItem in areaItem.children)
                            {
                                var existProvinceDisease = existCountryDisease.ProvinceDiseaseRecordList.FirstOrDefault(p => p.Province == provinceItem.name && p.StatDate == data.lastUpdateTime.Date);
                                if (existProvinceDisease == null)
                                {
                                    var newProvinceRecord = new ProvinceDiseaseRecord()
                                    {
                                        Id = Guid.NewGuid(),
                                        CountryDiseaseRecordId = existCountryDisease.Id,
                                        Province = provinceItem.name,
                                        //当天累计
                                        ConfirmQty = provinceItem.total.confirm,
                                        HealQty = provinceItem.total.heal,
                                        HealRate = provinceItem.total.healRate,
                                        DeadQty = provinceItem.total.dead,
                                        DeadRate = provinceItem.total.deadRate,
                                        SuspectQty = provinceItem.total.suspect,
                                        ShowHeal = provinceItem.total.showHeal,
                                        ShowRate = provinceItem.total.showRate,

                                        //当天的
                                        TodayConfirmQty = provinceItem.today.confirm,
                                        TodayDeadQty = provinceItem.today.dead,
                                        TodayHealQty = provinceItem.today.heal,
                                        TodaySuspectQty = provinceItem.today.suspect,
                                        IsUpdated = provinceItem.today.isUpdated,
                                        CityDiseaseRecordList = new List<CityDiseaseRecord>(),
                                        StatDate = data.lastUpdateTime.Date,
                                        Created = DateTime.Now,
                                        LastModified = DateTime.Now,
                                    };
                                    //市级
                                    if (provinceItem.children != null)
                                    {
                                        foreach (var cityItem in provinceItem.children)
                                        {
                                            var newCityRecord = new CityDiseaseRecord()
                                            {
                                                Id = Guid.NewGuid(),
                                                ProvinceDiseaseRecordId = newProvinceRecord.Id,
                                                City = cityItem.name,
                                                //当天累计
                                                ConfirmQty = cityItem.total.confirm,
                                                HealQty = cityItem.total.heal,
                                                HealRate = cityItem.total.healRate,
                                                DeadQty = cityItem.total.dead,
                                                DeadRate = cityItem.total.deadRate,
                                                SuspectQty = cityItem.total.suspect,
                                                ShowHeal = cityItem.total.showHeal,
                                                ShowRate = cityItem.total.showRate,

                                                //当天的
                                                TodayConfirmQty = cityItem.today.confirm,
                                                TodayDeadQty = cityItem.today.dead,
                                                TodayHealQty = cityItem.today.heal,
                                                TodaySuspectQty = cityItem.today.suspect,
                                                IsUpdated = cityItem.today.isUpdated,
                                                StatDate = data.lastUpdateTime.Date,
                                                Created = DateTime.Now,
                                                LastModified = DateTime.Now,
                                            };
                                            newProvinceRecord.CityDiseaseRecordList.Add(newCityRecord);
                                        }
                                    }
                                    _diseaseDataContext.ProvinceDiseaseRecord.Add(newProvinceRecord);
                                }
                                else
                                {
                                    existProvinceDisease.ConfirmQty = provinceItem.total.confirm;
                                    existProvinceDisease.HealQty = provinceItem.total.heal;
                                    existProvinceDisease.HealRate = provinceItem.total.healRate;
                                    existProvinceDisease.DeadQty = provinceItem.total.dead;
                                    existProvinceDisease.DeadRate = provinceItem.total.deadRate;
                                    existProvinceDisease.SuspectQty = provinceItem.total.suspect;
                                    existProvinceDisease.ShowHeal = provinceItem.total.showHeal;
                                    existProvinceDisease.ShowRate = provinceItem.total.showRate;

                                    //当天的
                                    existProvinceDisease.TodayConfirmQty = provinceItem.today.confirm;
                                    existProvinceDisease.TodayDeadQty = provinceItem.today.dead;
                                    existProvinceDisease.TodayHealQty = provinceItem.today.heal;
                                    existProvinceDisease.TodaySuspectQty = provinceItem.today.suspect;
                                    existProvinceDisease.IsUpdated = provinceItem.today.isUpdated;
                                    existProvinceDisease.CityDiseaseRecordList = new List<CityDiseaseRecord>();
                                    existProvinceDisease.LastModified = DateTime.Now;
                                    if (provinceItem.children != null)
                                    {
                                        foreach (var cityItem in provinceItem.children)
                                        {
                                            var existCityDisease = existProvinceDisease.CityDiseaseRecordList.FirstOrDefault(p => p.City == cityItem.name && p.StatDate == data.lastUpdateTime.Date);
                                            if (existCityDisease == null)
                                            {
                                                var newCityRecord = new CityDiseaseRecord()
                                                {
                                                    Id = Guid.NewGuid(),
                                                    ProvinceDiseaseRecordId = existProvinceDisease.Id,
                                                    City = cityItem.name,
                                                    //当天累计
                                                    ConfirmQty = cityItem.total.confirm,
                                                    HealQty = cityItem.total.heal,
                                                    HealRate = cityItem.total.healRate,
                                                    DeadQty = cityItem.total.dead,
                                                    DeadRate = cityItem.total.deadRate,
                                                    SuspectQty = cityItem.total.suspect,
                                                    ShowHeal = cityItem.total.showHeal,
                                                    ShowRate = cityItem.total.showRate,

                                                    //当天的
                                                    TodayConfirmQty = cityItem.today.confirm,
                                                    TodayDeadQty = cityItem.today.dead,
                                                    TodayHealQty = cityItem.today.heal,
                                                    TodaySuspectQty = cityItem.today.suspect,
                                                    IsUpdated = cityItem.today.isUpdated,
                                                    StatDate = data.lastUpdateTime.Date,
                                                    Created = DateTime.Now,
                                                    LastModified = DateTime.Now,
                                                };
                                                _diseaseDataContext.CityDiseaseRecord.Add(newCityRecord);
                                            }
                                            else
                                            {
                                                //当天累计
                                                existCityDisease.ConfirmQty = cityItem.total.confirm;
                                                existCityDisease.HealQty = cityItem.total.heal;
                                                existCityDisease.HealRate = cityItem.total.healRate;
                                                existCityDisease.DeadQty = cityItem.total.dead;
                                                existCityDisease.DeadRate = cityItem.total.deadRate;
                                                existCityDisease.SuspectQty = cityItem.total.suspect;
                                                existCityDisease.ShowHeal = cityItem.total.showHeal;
                                                existCityDisease.ShowRate = cityItem.total.showRate;

                                                //当天的
                                                existCityDisease.TodayConfirmQty = cityItem.today.confirm;
                                                existCityDisease.TodayDeadQty = cityItem.today.dead;
                                                existCityDisease.TodayHealQty = cityItem.today.heal;
                                                existCityDisease.TodaySuspectQty = cityItem.today.suspect;
                                                existCityDisease.IsUpdated = cityItem.today.isUpdated;
                                                existCityDisease.LastModified = DateTime.Now;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                _diseaseDataContext.SaveChanges();
                #endregion
            }

            return "success";
        }
        /// <summary>
        /// 同步疫情保存文件
        /// </summary>
        [HttpPost("SyncToFile")]
        public async Task<string> SyncToFile()
        {
            DiseaseAccess access = new DiseaseAccess(_httpClientFactory);
            var response = await access.GetDisease();
            if (response != null || response.ret == 0)
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Disease" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json");
                string content = JsonUtility.Serialize(response);
                if (System.IO.File.Exists(filePath))
                {
                    return "文件已经存在";
                }
                using (var fileStream = System.IO.File.Open(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    var streamWriter = new StreamWriter(fileStream);
                    streamWriter.Write(content);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                return "同步成功";
            }
            return "外部接口错误";
        }

        //public async Task GetDiseaseData()
        //{


        //}

    }
}
