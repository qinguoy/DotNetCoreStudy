using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DiseaseDataPlatform.DiseaseEntity
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(80)]
        public string Password { get; set; }
        [MaxLength(120)]
        public string Email { get; set; }
        public int Sex { get; set; }
        public int Status { get; set; }
        public int Enabled { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
