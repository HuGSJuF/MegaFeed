using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace megaSite_feed.Models
{
    public class NewsConvert
    {
        public virtual List<NewConvert> News { get; set; }

    }
    public class NewConvert
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "headline")]
        public string Headline { get; set; }

        [JsonProperty(PropertyName = "kicker")]
        public string Kicker { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "inserted")]
        public DateTime Inserted { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTime Modified { get; set; }

        [JsonProperty(PropertyName = "pic_src")]
        public string Pic_src { get; set; }

        [JsonProperty(PropertyName = "pic_width")]
        public int Pic_width { get; set; }

        [JsonProperty(PropertyName = "pic_height")]
        public int Pic_height { get; set; }

        [JsonProperty(PropertyName = "pic_caption")]
        public string Pic_caption { get; set; }
    }


}
