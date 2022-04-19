namespace ComicBook.Api.DTOs
{
    public class ComicBookPagingDTO
    {
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public string? Order { get; set; } 
        public int Page { get; set; }
    }
}
