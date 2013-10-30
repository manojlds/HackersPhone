using Newtonsoft.Json;

namespace HackersPhone.ViewModels
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonProperty("url")]
        public string Link { get; set; }
        public string PostedBy { get; set; }
        public string PostedAgo { get; set; }
        public int Points { get; set; }
        public int CommentCount { get; set; }
    }
}
