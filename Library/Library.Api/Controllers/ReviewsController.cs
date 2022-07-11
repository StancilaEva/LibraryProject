using AutoMapper;
using Library.Api.DTOs.ErrorDTOs;
using Library.Api.DTOs.ReviewDTOs;
using Library.Application.Commands.ReviewCommands;
using Library.Application.Queries.ReviewQueries;
using Library.Core.Exceptions;
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
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public readonly IMapper _mapper;

        public ReviewsController(IMediator mediatr, IMapper mapper)
        {
            _mediatr = mediatr;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Rating/{id}")]
        public async Task<IActionResult> GetRatingById(int id)
        {
            var queryToSend = new GetComicBookRatingQuery()
            {
                ComicId = id
            };
            var result = await _mediatr.Send(queryToSend);
            return Ok(result);
        }

        [HttpPost]
        [Route("{comicId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddReview([FromBody] ReviewDTO review,int comicId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = Int32.Parse(identity.FindFirst("UserId").Value);
                    var queryToSend = new AddReviewCommand()
                    {
                        ComicId = comicId,
                        ClientId = userId,
                        TextReview = review.ReviewText,
                        Rating = review.Rating,
                    };
                    var result = await _mediatr.Send(queryToSend);

                    if (result == null)
                    {
                        return NotFound();
                    }

                    var lendResult = _mapper.Map<ReviewDTO>(result);

                    return Ok(lendResult);
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
            catch (InvalidReviewException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{comicId}")]
        public async Task<IActionResult> GetComicReviews(int comicId)
        {
            var queryToSend = new GetComicReviewsQuery()
            {
                ComicId = comicId
            };
            var result = await _mediatr.Send(queryToSend);
            return Ok(result);
        }
    }
}
