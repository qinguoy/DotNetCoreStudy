using QinGY.DotnetCoreStudy.SimpleNetCore.EventBusSystem;
using QinGY.DotnetCoreStudy.SimpleNetCore.FileSystem;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace QinGY.DotnetCoreStudy.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //  PublishTest.Test();
            //FileSystemTester tester = new FileSystemTester();
            //tester.TestPhysicalFile();
            //Console.WriteLine("Hello World!");


            TestHttpClient();
            Console.Read();
        }

        private async static void TestHttpClient()
        {
            for (int i = 0; i < 15; i++)
            {
                using (HttpClient client = new HttpClient())
                {
                    var result = await client.GetAsync("http://aspnetmonsters.com/");
                    Console.WriteLine(result.StatusCode);
                }
            }
        }

        private static void ShowInfo(Action<string,DateTime> show)
        {
            int index = 0;
            GetData("");   
            //定义方法递归
            void GetData(string name)
            {
                Dictionary<string, DateTime> dicInfo = new Dictionary<string, DateTime>();
                dicInfo.Add("dingtang",new DateTime(2013,6,1));
                dicInfo.Add("yinghua", new DateTime(2016, 6, 1));
                dicInfo.Add("jiejing", new DateTime(2017 ,4 , 16));
                //ToDo 根据string获取数据...
                foreach (var item in dicInfo)
                {
                    if (item.Key == "jiefen")
                    {
                        GetData(item.Key);
                    }
                    else
                    {
                        show(item.Key, item.Value);
                    }
                }
            }
        }
    }
}
