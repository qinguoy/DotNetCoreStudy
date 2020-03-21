using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qingy.DotNetCoreStudy.HangfireManagement
{
    /// <summary>
    /// 作业
    /// </summary>
    public interface IJob
    { 
        /// <summary>
        /// 执行作业
        /// </summary>
        Task Execute(object argument);
    }
    public class TestJob : IJob
    {
        /// <summary>
        /// 执行
        /// </summary>
        public async Task Execute(object argument)
        {
            Console.WriteLine($"这里再构造参数【arguemnt{argument}】发送bus");
        }
    }

    public interface ICommand
    { 
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommand<T>
    { 
    
    }
    /// <summary>
    /// 
    /// </summary>
    public class JobMessage : ICommand
    { 
        public Guid AccountId { get; set; }
        public int OffsetDay { get; set; }
    }
}
