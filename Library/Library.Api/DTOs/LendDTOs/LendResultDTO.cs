namespace Library.Api.DTOs.LendDTOs
{
    public class LendResultDTO
    {
        public int LendId { get; set; }
        public int ComicBookId { get; set; }
        public string ComicBookTitle { get; set; }
        public int ClientId { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
