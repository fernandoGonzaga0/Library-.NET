using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? Thumbnail { get; set; }
        public int YearPublished { get; set; }
        public int NumberOfPages { get; set; }
    }
}