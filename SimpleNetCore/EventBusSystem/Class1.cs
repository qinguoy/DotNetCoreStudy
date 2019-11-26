using System;
using System.Collections.Generic;
using System.Text;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.EventBusSystem
{
    public class IEventCommand
    {
        public Guid Id
        {
            get; set;
        }
        public DateTime Time { get; set; }

        public object EventData { get; set; }
    }
}
