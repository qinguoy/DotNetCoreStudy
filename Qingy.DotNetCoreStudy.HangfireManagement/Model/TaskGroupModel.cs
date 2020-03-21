using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qingy.DotNetCoreStudy.HangfireManagement.Model
{
    public class TaskGroupModel
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// 组名
        /// </summary>
        public string groupName { get; set; }
       /// <summary>
       /// 描述
       /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime created { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime lastModified { get; set; }
    }
}
