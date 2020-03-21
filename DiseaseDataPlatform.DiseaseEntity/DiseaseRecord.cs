using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiseaseDataPlatform.DiseaseEntity
{
    public class DiseaseRecord
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime UpdateTime { get; set; } 

    }
}
