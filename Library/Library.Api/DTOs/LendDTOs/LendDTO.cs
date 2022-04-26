using System.ComponentModel.DataAnnotations;

namespace Library.Api.DTOs
{
    public class LendDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
