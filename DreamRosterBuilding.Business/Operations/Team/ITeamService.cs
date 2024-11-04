using DreamRosterBuilding.Business.Operations.Team.Dtos;
using DreamRosterBuilding.Business.Types;
using DreamRosterBuilding.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Team
{
    public interface ITeamService
    {
        Task<ServiceMessage<TeamDto>> GetTeam(int id);
        Task<List<TeamDto>> GetAll();
        Task<ServiceMessage> Add(AddTeamDto addteamDto);
        Task<ServiceMessage> DeleteById(int id);
        Task<ServiceMessage> UpdateTeam(UpdateTeamDto updateTeamDto);
    }
}
