using DreamRosterBuilding.Business.Operations.Player.Dtos;
using DreamRosterBuilding.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Player
{
    public interface IPlayerService
    {
        Task<ServiceMessage> AddPlayer(AddPlayerDto addPlayerDto);
        Task<PlayerDto> GetPlayer(int id);
        Task<List<PlayerDto>> GetAll();

        Task<ServiceMessage> UpdatePlayer(UpdatePlayerDto updatePlayerDto);
        Task<ServiceMessage> DeletePlayer(int id);
    }
}
