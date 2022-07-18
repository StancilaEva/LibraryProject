using AutoMapper;
using Library.Application;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FileController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IMediator _mediatr;

        public FileController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
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
