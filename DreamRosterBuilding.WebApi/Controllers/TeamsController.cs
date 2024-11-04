using DreamRosterBuilding.Business.Operations.Team;
using DreamRosterBuilding.Business.Operations.Team.Dtos;
using DreamRosterBuilding.WebApi.Jwt;
using DreamRosterBuilding.WebApi.Models.Player;
using DreamRosterBuilding.WebApi.Models.Team;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamRosterBuilding.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        #region GetTeamById - HttpGet
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var serviceResult = await _teamService.GetTeam(id); // -> Sending service to id to find and get team

            if (serviceResult.IsSucceed is false)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult.Data);
        }
        #endregion

        #region GetTeams - HttpGet
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var serviceResult = await _teamService.GetAll();

            return Ok(serviceResult);
        }
        #endregion

        #region AddTeam - HttpPost
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddTeam(AddTeamRequest request)
        {
            var username = HttpContext.User.FindFirst(JwtClaimNames.Email).Value; // -> In my scenario emailadress is username

            var addTeamDto = new AddTeamDto // -> request to DTO, DTO to entity
            {
                Image = request.Image,
                LeaugeId = request.LeaugeId,
                Name = request.Name,
                NationId = request.NationId,
                CreatedUser = username,
                ModifiedUser = username
            };

            var serviceResult = await _teamService.Add(addTeamDto);

            if (serviceResult.IsSucceed is false)
            {
                return BadRequest(serviceResult.Message);
            }

            return Ok(serviceResult.Message);
        }
        #endregion

        #region DeleteTeam - HttpDelete - Admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // -> Only admins
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var serviceResult = await _teamService.DeleteById(id);

            if (serviceResult.IsSucceed is false)
            {
                return BadRequest(serviceResult.Message);
            }
            else
            {
                return Ok(serviceResult.Message);
            }
        }
        #endregion

        #region UpdateTeam - HttpPut
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateTeam(int id, UpdateTeamRequest request)
        {
            var username = HttpContext.User.FindFirst(JwtClaimNames.Email).Value; // -> In my scenario emailadress is username

            var updateTeamDto = new UpdateTeamDto // -> request to DTO, DTO to entity in service
            {
                Id=id,
                Name = request.Name,
                Image = request.Image,
                LeaugeId = request.LeaugeId,
                NationId = request.NationId,
                ModifiedUser = username
            };

            var serviceResult= await _teamService.UpdateTeam(updateTeamDto);

            if(serviceResult.IsSucceed is false)
            {
                return NotFound(serviceResult.Message);
            }
            else
            {
                return Ok(serviceResult.Message);
            }
        }
        #endregion

        #region PatchTeam - HttpPatch
        //  I my scenario I dont need changes on specific fields, partial updates so for now no need patch
        #endregion

    }
}
