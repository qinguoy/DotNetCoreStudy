/*
 * 1、EventBus实现了对于事件的注册以及取消注册的管理
 * 2、EventBus内部维护了一份事件源与事件处理程序的对应关系，并且通过这个对应关系在事件发布的时候可以找到对应的处理程序去执行
 * 3、EventBus应该要支持默认就注册事件源与处理程序的关系，而不需要开发人员手动去注册（这里也可以让开发人员去控制自动还是手动）
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.EventBusSystem
{

    /// <summary>
    ///
    /// </summary>
    public interface IEventBus
    {
    }
}
