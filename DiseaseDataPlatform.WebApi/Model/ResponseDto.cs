using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Model
{
    /// <summary>
    /// 返回数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseDto<T>
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }
    }

    public class QueryResponse<T> : ResponseDto<T>
    { 
        /// <summary>
        /// 总记录数
        /// </summary>
       public int totalCount { get; set; }
    }
}
