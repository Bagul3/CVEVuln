using Newtonsoft.Json;

namespace CVEVuln.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
