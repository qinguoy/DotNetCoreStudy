using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Common
{
    /// <summary>
    /// json序列化帮助类 
    /// </summary>
    public class JsonUtility
    {
        /// <summary>
        /// json序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// json序列化并自动缩进
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeFormat<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public static T DeserializeWithDateTimeFormat<T>(string value, string timeformatString)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = timeformatString;
            return JsonConvert.DeserializeObject<T>(value, timeFormat);

        }
    }
}
