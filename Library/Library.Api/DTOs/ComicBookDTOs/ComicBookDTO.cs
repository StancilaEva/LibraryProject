﻿namespace Library.Api.DTOs
{
    public class ComicBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public int IssueNumber { get; set; }
        public string Cover { get; set; }
    }
}
