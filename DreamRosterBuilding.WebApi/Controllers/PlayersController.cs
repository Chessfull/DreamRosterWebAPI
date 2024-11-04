using Azure;
using Azure.Identity;
using DreamRosterBuilding.Business.Operations.Player;
using DreamRosterBuilding.Business.Operations.Player.Dtos;
using DreamRosterBuilding.Data.Enums;
using DreamRosterBuilding.WebApi.Jwt;
using DreamRosterBuilding.WebApi.Models.Player;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DreamRosterBuilding.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        #region GetPlayer - HttpGet
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerService.GetPlayer(id); // -> Sending id to service

            if (player is null)
            { return NotFound(); }
            else
            {
                return Ok(player);
            }
        }
        #endregion

        #region GetPlayers - HttpGet
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _playerService.GetAll();

            return Ok(players);
        }
        #endregion

        #region AddPlayer - HttpPost
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddPlayer(AddPlayerRequest playerRequest)
        {
            var username = HttpContext.User.FindFirst(JwtClaimNames.Email).Value; // -> In my scenario emailadress is username

            var addedPlayerDto = new AddPlayerDto // -> Request to Dto, and dto to entity later in service
            {
                BirthDate = playerRequest.BirthDate,
                Name = playerRequest.Name,
                HairColor = playerRequest.HairColor,
                PositionIds = playerRequest.PositionIds,
                SkillIds = playerRequest.SkillIds,
                Skin = playerRequest.Skin,
                Tattoo = playerRequest.Tattoo,
                NationId = playerRequest.NationId,
                TeamId = playerRequest.TeamId,
                CreatedUser = username,
                ModifiedUser = username
            };

            var serviceResult = await _playerService.AddPlayer(addedPlayerDto);

            if (serviceResult.IsSucceed is false)
            {
                return BadRequest(serviceResult.Message);
            }
            else
            {
                return Ok();
            }
        }
        #endregion

        #region DeletePlayer - HttpDelete - Admin
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // -> Delete processes can only made by admins
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var serviceResult = await _playerService.DeletePlayer(id);
            if (serviceResult.IsSucceed is false)
            {
                return NotFound(serviceResult.Message);
            }
            else
            {
                return Ok(serviceResult.Message);
            }
        }
        #endregion

        #region UpdatePlayer - HttpPut
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePlayer(int id, UpdatePlayerRequest request)
        {
            var username = HttpContext.User.FindFirst(JwtClaimNames.Email).Value; // -> In my scenario emailadress is username
            
            var updatePlayerDto = new UpdatePlayerDto // -> Request to DTO, DTO to Entity. Single responsibility!
            {
                Id = id,
                BirthDate = request.BirthDate,
                HairColor = request.HairColor,
                Name = request.Name,
                NationId = request.NationId,
                TeamId = request.TeamId,
                PositionIds = request.PositionIds,
                SkillIds = request.SkillIds,
                Skin = request.Skin,
                Tattoo = request.Tattoo,
                ModifiedUser = username
            };

            var serviceResult = await _playerService.UpdatePlayer(updatePlayerDto);

            if (serviceResult.IsSucceed is false)
            {
                return NotFound(serviceResult.Message);
            }
            else
            {
                return Ok(serviceResult.Message);
            }
        }
        #endregion

        #region PatchPlayer - HttpPatch
        // For now in my scenario I dont need changes on specific fields, partial updates 
        //[HttpPatch("{id}")] 
        //public async Task<IActionResult> PatchPlayer(int id,JsonPatchDocument<PatchPlayerRequest> request)
        //{

        //}
        #endregion

        #region GetPlayerHairColor - HttpGet
        [HttpGet("hair-colors")] // -> In my scenario in frontend part hair colors will be selected from dropdown and get datas with this api
        public IActionResult GetHairColors()
        {
            var hairColors = Enum.GetValues(typeof(HairColor))
                .Cast<HairColor>()
                .Select(h => new
                {
                    Value = (int)h,
                    Name = h.ToString()
                })
                .ToList();

            return Ok(hairColors);
        }
        #endregion
    }
}
