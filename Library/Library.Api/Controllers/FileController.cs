using AutoMapper;
using Library.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public FileController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpPost("ComicCover")]
        public async Task<IActionResult> PostFile(IFormFile formFile)
        {
            var command = new FileCommand()
            {
                File = formFile
            };
            var result = await _mediatr.Send(command);

            return Ok(result);
        }
    }
}
