
using AutoMapper;
using Library.Api.DTOs;
using Library.Api.DTOs.ErrorDTOs;
using Library.Api.DTOs.LendDTOs;
using Library.Application.Commands.LendCommands;
using Library.Application.Exceptions;
using Library.Application.Paging;
using Library.Application.Queries.ClientQueries;
using Library.Application.Queries.LendQueries;
using Library.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LendsController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public readonly IMapper _mapper;

        public LendsController(IMediator mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("BorrowComic/{comicId}")]
        public async Task<IActionResult> CreateLend(int clientId, int comicId, [FromBody] LendDTO lendDTO)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var id = Int32.Parse(identity.FindFirst("UserId").Value);
                    var commandToSend = new CreateLendCommand()
                    {
                        ComicId = comicId,
                        UserId = id,
                        StartDate = lendDTO.StartDate,
                        EndDate = lendDTO.EndDate
                    };
                    var result = await _mediatR.Send(commandToSend);

                    if (result == null)
                    {
                        return NotFound();
                    }

                    var lendResult = _mapper.Map<LendResultDTO>(result);

                    return CreatedAtAction(nameof(GetLendById), new { id = result.Id }, lendResult);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch(InvalidDateException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch (BookNotAvailableException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch(LendDateNotValidException ex)
            {
                ErrorDTO err = new ErrorDTO(){ ErrorMessage = ex.Message };
                return BadRequest(err);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPatch("{lendId}")]
        public async Task<IActionResult> ExtendLend([FromBody] LendExtensionDTO lendExtensionDTO,int lendId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    var userId = Int32.Parse(identity.FindFirst("UserId").Value);
                    var commandToSend = new ExtendLendCommand()
                    {
                        EndDate = lendExtensionDTO.NewEndDate,
                        IdLend = lendId,
                        UserId = userId
                    };

                    var result = await _mediatR.Send(commandToSend);

                    if (result == null)
                    {
                        return NotFound();
                    }

                    var lendResult = _mapper.Map<LendResultDTO>(result);

                    return Ok(lendResult);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch(LendDateNotValidException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch(AlreadyExtendedException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
            catch(UnauthorizedAccessException ex)
            {
                ErrorDTO err = new ErrorDTO() { ErrorMessage = ex.Message };
                return BadRequest(err);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLendById(int id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                 {
                    var userId = Int32.Parse(identity.FindFirst("UserId").Value);
                    var queryToSend = new GetLendByIdQuery()
                    {
                        Id = id,
                        UserId = userId
                    };
                    var result = await _mediatR.Send(queryToSend);

                    if (result == null)
                    {
                        return NotFound();
                    }

                    var lendResult = _mapper.Map<LendResultDTO>(result);

                    return Ok(lendResult);
            } else {
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


        [HttpGet("Comic/{id}")]
        public async Task<IActionResult> GetLendsThatContainComic(int id)
        {
                var queryToSend = new GetAllLendsThatContainComicQuery()
                {
                    ComicBookId = id
                };
                var result = await _mediatR.Send(queryToSend);

                if (result == null)
                {
                    return NotFound();
                }

                var lendResult = _mapper.Map<List<TimePeriodDTO>>(result);

                return Ok(lendResult);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet()]
        public async Task<IActionResult> GetUserLends([FromQuery] LendPaging lendPaging)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var id = Int32.Parse(identity.FindFirst("UserId").Value);
                var queryToSend = new GetClientLendsQuery()
                {
                    IdClient = id,
                    Page = lendPaging.Page,
                    Time = lendPaging.Time
                };
                LendPage result = await _mediatR.Send(queryToSend);

                if (result.Count == 0)
                {
                    return NoContent();
                }

                var mappedResult = _mapper.Map<List<LendResultDTO>>(result.Lends);

                var userLendsDTO = new LendPaginationDTO
                {
                    Lends = mappedResult,
                    Count = result.Count
                };

                return Ok(userLendsDTO);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
