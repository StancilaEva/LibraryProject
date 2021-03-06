using ComicBook.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComicBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPatch("{id}/Address/{addressId}")]
        public async Task<IActionResult> ChangeAddress([FromBody] AddressDTO addressDTO)
        {
            throw new NotImplementedException();
        }
    }
}
