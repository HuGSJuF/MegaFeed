using SQLite;
using System;

namespace megaSite_feed.Models
{
    [Table("News")]
    public class News
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Kicker { get; set; }
        public string Url { get; set; }
        public DateTime Inserted { get; set; }
        public DateTime Modified { get; set; }
        public string Pic_src { get; set; }
        public int Pic_width { get; set; }
        public int Pic_height { get; set; }
        public string Pic_caption { get; set; }
    }
}
