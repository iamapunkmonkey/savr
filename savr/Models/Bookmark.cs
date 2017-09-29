using System;
using System.ComponentModel.DataAnnotations;

namespace savr.Models
{
    public class Bookmark
    {
        [Key]
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}