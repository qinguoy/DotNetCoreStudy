using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Qingy.DotNetCoreStudy.HangfireJobEntity
{
    /// <summary>
    /// 
    /// </summary>
    public class HangfireTaskGroup
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string GroupName { get; set; } 
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
