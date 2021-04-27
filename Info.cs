using Microsoft.OpenApi.Models;

namespace KiproshBirthdayCelebration
{
    internal class Info : OpenApiInfo
    {
        public string version { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}