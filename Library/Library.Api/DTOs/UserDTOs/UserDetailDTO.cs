namespace Library.Api.DTOs.UserDTOs
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public AddressDTO Address { get; set; }

    }
}
