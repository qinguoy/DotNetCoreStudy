using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiseaseDataPlatform.DiseaseEntity
{
    /// <summary>
    /// Dbcontext
    /// </summary>
    public class DiseaseDataContext : DbContext
    {

        public DiseaseDataContext(DbContextOptions<DiseaseDataContext> options)
      : base(options)
        {
        }
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #region Entity
        public virtual DbSet<DiseaseRecord> DiseaseRecord { get; set; }
        public virtual DbSet<CountryDiseaseRecord> CountryDiseaseRecord { get; set; }
        public virtual DbSet<ChinaDiseaseDailyStatistics> DiseaseDailyStatistics { get; set; }
        public virtual DbSet<ProvinceDiseaseRecord> ProvinceDiseaseRecord { get; set; }
        public virtual DbSet<CityDiseaseRecord> CityDiseaseRecord { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<DiseaseDailyAdd> DiseaseDailyAdd { get; set; }
        public virtual DbSet<HubeiDiseaseDaily> HubeiDiseaseDaily { get; set; }

        public virtual DbSet<User> User { get; set; }
        #endregion
    }
}
