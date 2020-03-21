using System;
using System.Collections.Generic;
using System.Text;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.EB
{
    public interface IMessage
    {
    }

    public interface ICommand:IMessage
    { 
    }
    /// <summary>
    /// 锁定库存
    /// </summary>
    public class LockInventoryCommand : ICommand
    { 
        /// <summary>
        /// sku id
        /// </summary>
        public Guid SkuId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 源id
        /// </summary>
        public Guid SourceId { get; set; }
    }
}
