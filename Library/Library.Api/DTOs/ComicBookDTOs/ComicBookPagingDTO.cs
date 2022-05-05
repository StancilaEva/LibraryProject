namespace Library.Api.DTOs.ComicBookDTOs
{
    public class ComicBookPagingDTO
    {
        public List<ComicBookDTO> ComicBooks { get; set; }
        public int RecordCount { get; set; }
    }
}
