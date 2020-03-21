using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Model
{
    public class QueryDiseaseRequest
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string name { get; set;  }
    }
}
