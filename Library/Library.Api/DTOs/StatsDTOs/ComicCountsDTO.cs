using Library.Core;

namespace Library.Api.DTOs.StatsDTO
{
    public class ComicCountsDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
