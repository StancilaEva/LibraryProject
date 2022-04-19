namespace Library.Api.DTOs
{
    public class ComicBookPaging
    {
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public string? Order { get; set; }
        public int Page { get; set; }
    }
}
