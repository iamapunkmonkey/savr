using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace savr.Models
{
    public class RssItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime PubDate { get; set; }
        public bool Active { get; set; } = true;
    }
}