
/**
 * 简单通过事件实现代理
 * 这种形式的实现，要求发布方必须明确的知道接收方，并将接收方的对应方法绑定到委托中
 * 这样才能在发布方发消息时能通知到接收方
 * 这种方式的实现必须将对应类进行关联，代码偶尔度高，并且不通用，不同的消息通知要明确的绑定，也不利于扩展
 * 对于极简的功能我们可以这样实现
 * 对于复杂的系统需要对消息进行统一的分发的，则需引入事件总线
 * 
 * 所谓的事件总线是指对消息的发布，订阅作分别做统一的入口，不同模块之间进行消息通知只需通过向消息入库发送消息即可
 * 这个过程中不需要知道谁是发布者，谁是接收者。发布者通过发布入口发布消息，接收者通过参数确定是否有订阅的消息，有则进行处理
 * 消息总线一般包含事件的注册管理（注册，取消注册）。
 * 消息总线
 * 
 * 
 * 
 * 
 * 
 * 
 **/
 
using System;
using System.Collections.Generic;
using System.Text;

namespace QinGY.DotnetCoreStudy.SimpleNetCore.EventBusSystem
{ 
    public delegate void Publish(string message);
    public class Publisher
    { 
        public event Publish PublishEvent;
        private void OnPublish(string message)
        {
            if (PublishEvent != null)
            {
                PublishEvent(message);
            }
        }
        public void PublishNotify(object sender,string message)
        {
            this.OnPublish(message);
        }
    }

    public class Subcripter
    {
        public string Name { get; set; }
        public Subcripter() { }
        public Subcripter(string name) {
            this.Name = name;
        }
        public void GetMessage(string message)
        {
            Console.WriteLine($"{Name}收到+{message}");
        }
    }

    public class PublishTest
    {
        public static void Test() {
            Publisher master = new Publisher();
            Subcripter a = new Subcripter("A");
            master.PublishEvent += a.GetMessage;
            Subcripter b = new Subcripter("B");
            master.PublishEvent += b.GetMessage;
            Subcripter c = new Subcripter("C");
            master.PublishEvent += c.GetMessage;
            master.PublishNotify(null,"加工资！！");
        }
    }

}
