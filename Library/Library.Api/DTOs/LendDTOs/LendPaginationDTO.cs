namespace Library.Api.DTOs.LendDTOs
{
    public class LendPaginationDTO
    {
        public List<LendResultDTO> Lends { get; set; } 
        public int Count { get; set; }
    }
}
