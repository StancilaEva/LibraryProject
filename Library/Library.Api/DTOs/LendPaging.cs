using Library.Core;

namespace Library.Api.DTOs
{
    public class LendPaging
    {
        public TimePeriod? Time { get; set; }
        public int Page { get; set; }
    }
}
