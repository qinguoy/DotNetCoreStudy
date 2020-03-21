
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Model
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserView
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid id { get; set; }  
        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string name { get; set; } 
        /// <summary>
        /// 用户密码
        /// </summary>
        public string password { get; set; } 
        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int enabled { get; set; }
    }
    /// <summary>
    /// 添加用户
    /// </summary>
    public class AddUserView {
       
        /// <summary>
        /// 用户名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }
    }
    /// <summary>
    /// 编辑用户
    /// </summary>
    public class EditUserView {
        /// <summary>
        /// ID
        /// </summary>
        public Guid id { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }
    }
}
