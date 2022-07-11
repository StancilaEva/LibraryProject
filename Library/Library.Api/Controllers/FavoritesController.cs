using AutoMapper;
using Library.Api.DTOs.ComicBookDTOs;
using Library.Api.DTOs.ErrorDTOs;
using Library.Application.Commands.FavoritesCommands;
using Library.Application.Commands.ReviewCommands;
using Library.Application.Queries.FavoriteQueries;
using Library.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        public readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FavoritesController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetAllFavorites([FromQuery]int page)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = Int32.Parse(identity.FindFirst("UserId").Value);
                    var queryToSend = new GetAllFavoritesQuery()
                    {
                        Page = page,
                        ClientId = userId,
                    };
                    var result = await _mediator.Send(queryToSend);

                    var mappedResult = _mapper.Map<List<ComicBook>, List<ComicBookSearchDTO>>(result.Comics);

                    ComicBookPagingDTO comicBookPagingResult = new ComicBookPagingDTO()
                    {
                        ComicBooks = mappedResult,
                        RecordCount = result.PageCount
                    };

                    return Ok(comicBookPagingResult);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO
                {
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("{comicId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetFavorite(int comicId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = Int32.Parse(identity.FindFirst("UserId").Value);
                    var queryToSend = new GetFavoriteQuery()
                    {
                        ComicId = comicId,
                        ClientId = userId,
                    };
                    var result = await _mediator.Send(queryToSend);

                    if (result != null)
                        return Ok(result);
                    else
                        return NoContent();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO
                {
                    ErrorMessage = ex.Message
                });
            }
        }
    

        [HttpDelete]
        [Route("{comicId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> RemoveFavorite(int comicId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = Int32.Parse(identity.FindFirst("UserId").Value);
                    var commandToSend = new RemoveFavoriteCommand()
                    {
                        ComicId = comicId,
                        UserId = userId
                    };
                    var result = await _mediator.Send(commandToSend);
                    if (result == true)
                            return Ok();
                    else
                     return NoContent();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO
                {
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("{comicId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddFavorite(int comicId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = Int32.Parse(identity.FindFirst("UserId").Value);
                    var queryToSend = new AddFavoriteCommand()
                    {
                        ComicId = comicId,
                        ClientId = userId,
                    };
                    var result = await _mediator.Send(queryToSend);

                    if (result != null)
                        return Ok(result);
                    else
                        return NoContent();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new ErrorDTO
                {
                    ErrorMessage = ex.Message
                });
            }
        }
    }

}
