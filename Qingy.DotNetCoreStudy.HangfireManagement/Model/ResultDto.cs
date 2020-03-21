using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qingy.DotNetCoreStudy.HangfireManagement.Model
{
    public class ResultDto<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 额外数据
        /// </summary>
        public object extraData { get; set; }
    }
}
