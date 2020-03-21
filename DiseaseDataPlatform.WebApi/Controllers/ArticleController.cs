using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiseaseDataPlatform.DiseaseEntity;
using DiseaseDataPlatform.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiseaseDataPlatform.WebApi.Controllers
{
    /// <summary>
    /// 相关报道
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private DiseaseDataContext _DiseaseDataContext = null;
        public ArticleController(DiseaseDataContext diseaseDataContext)
        {
            this._DiseaseDataContext = diseaseDataContext;
        }
        /// <summary>
        /// 查询文章
        /// </summary>
        /// <param name="publishTimeFrom"></param>
        /// <param name="publishTimeTo"></param>
        /// <param name="title"></param>
        /// <param name="source"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpPost("GetArticles")]
        public QueryResponse<List<ArticleView>> GetArticles(DateTime? publishTimeFrom,DateTime? publishTimeTo, string title, string media, int pageSize,int pageIndex)
        {
            var result = new QueryResponse<List<ArticleView>>() {  
                code="-1"
            };
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 20;
            }
            var query = _DiseaseDataContext.Article.AsNoTracking();
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(p => p.Title.Contains(title));
            }
            if (!string.IsNullOrEmpty(media))
            {
                query = query.Where(p => p.Source.Contains(media));
            }
            if (publishTimeFrom != null)
            {
                query = query.Where(p=>p.PublishTime>= publishTimeFrom);
            }
            if (publishTimeTo != null)
            {
                query = query.Where(p => p.PublishTime <= publishTimeTo); 
            }
            int total = query.Count();
            var data = query.OrderByDescending(p=>p.PublishTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            result.code = "0";
            result.totalCount = total;
            result.data = SwitchArticleView(data);
            return result;
        }
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="articleList"></param>
        /// <returns></returns>
        private List<ArticleView> SwitchArticleView(List<Article> articleList)
        {
            var result = new List<ArticleView>();
            if (articleList == null)
            {
                return result;
            }
            articleList.ForEach(p => result.Add(new ArticleView()
            {
                id = p.Id,
                canUse = p.CanUse,
                cmsId = p.CmsId,
                created = p.Created,
                description = p.Description,
                lastModified = p.LastModified,
                media = p.Media,
                publishTime = p.PublishTime,
                source = p.Source,
                title = p.Title,
                url = p.Url,
            }));
            return result;
        }
    }
}