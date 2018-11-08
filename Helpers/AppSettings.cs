using System.ComponentModel;

namespace WebApi.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        
        [Description("Session time in minutes")]
        public int SessionTime { get; set; }
    }
}