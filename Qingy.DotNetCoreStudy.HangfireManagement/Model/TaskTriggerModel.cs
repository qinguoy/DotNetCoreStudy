using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qingy.DotNetCoreStudy.HangfireManagement.Model
{
    public class TaskTriggerModel
    {
        public Guid id { get; set; }
        public Guid taskId { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public string cron { get; set; }
        public int status { get; set; }
        public DateTime created { get; set; }
        public DateTime lastModified { get; set; }
    }

    public class CreateTriggerModel
    { 
        public Guid taskId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string cron { get; set; }
    }
}
