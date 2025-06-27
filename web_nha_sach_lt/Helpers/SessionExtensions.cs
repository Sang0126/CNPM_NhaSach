using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace web_nha_sach_lt.Helpers
{
    public static class SessionExtensions
    {
        // Lưu object vào session dưới dạng JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Lấy object từ session và deserialize JSON
        public static T? GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
