using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qingy.DotNetCoreStudy.HangfireManagement
{
    public class SyncAmazonListingJob:IJob
    { 

        public async  Task Execute(object argument)
        {
            System.Console.WriteLine("同步亚马逊listing"+argument==null?"":argument.ToString());
        }
    }
}
