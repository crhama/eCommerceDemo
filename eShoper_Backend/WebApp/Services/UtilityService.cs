using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.CommonViewModels;

namespace WebApp.Services
{
    public static class UtilityService
    {
        public static string SetImageUrl(this Guid? imageId)
        {
            return $"https://localhost:44322/images/products/{imageId.ToString()}.jpg";
        }

        public static IEnumerable<KeyValue> GetKeyValueFromEnum<T>()
        {
            var kvList = new List<KeyValue>();
            foreach (int i in Enum.GetValues(typeof(T)))
            {
                String name = Enum.GetName(typeof(T), i);
                var kv = new KeyValue
                {
                    Key = i.ToString(),
                    Value = name
                };
                kvList.Add(kv);
            }
            return kvList;
        }
    }
}
