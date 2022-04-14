namespace ComicBook.Api.DTOs
{
    public class ComicBookPagingDTO
    {
        public String Publisher { get; set; }
        public String Genre { get; set; }
        public String Order { get; set; } 
        public int Page { get; set; }
    }
}
