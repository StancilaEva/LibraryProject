namespace Library.Api.DTOs.ComicBookDTOs
{
    public class ComicBookPagingDTO
    {
        public List<ComicBookSearchDTO> ComicBooks { get; set; }
        public int RecordCount { get; set; }
    }
}
