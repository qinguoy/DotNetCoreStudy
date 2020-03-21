using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qingy.DotNetCoreStudy.HangfireJobEntity
{
    /// <summary>
    /// 
    /// </summary>
    public class HangfireTaskContext : DbContext
    {

        public HangfireTaskContext(DbContextOptions<HangfireTaskContext> options)
            : base(options)
        {
        }
        public virtual DbSet<HangfireTask> HangfireTask { get; set; }
        public virtual DbSet<HangfireTaskGroup> HangfireTaskGroup { get; set; }

        public virtual DbSet<HangfireTaskTrigger> HangfireTaskTrigger { get; set; }
    }
}
