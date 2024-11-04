using DreamRosterBuilding.Business.Operations.Icon;
using DreamRosterBuilding.Business.Operations.Team.Dtos;
using DreamRosterBuilding.Business.Types;
using DreamRosterBuilding.Data.Entities;
using DreamRosterBuilding.Data.Repositories;
using DreamRosterBuilding.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.Team
{
    public class TeamManager : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork; // -> Calling UOW for transactions, async saves ...
        private readonly IRepository<TeamEntity> _teamRepository; // -> I defined my repository as generic so T repository
        private readonly IRepository<LeagueEntity> _leagueRepository;
        private readonly IRepository<NationEntity> _nationRepository;
        private readonly IRepository<PlayerEntity> _playerRepository;

        public TeamManager(IUnitOfWork unitOfWork, IRepository<TeamEntity> repository, IRepository<LeagueEntity> leagueRepository, IRepository<NationEntity> nationRepository, IRepository<PlayerEntity> playerRepository)

        {
            _unitOfWork = unitOfWork;
            _teamRepository = repository;
            _leagueRepository = leagueRepository;
            _nationRepository = nationRepository;
            _playerRepository = playerRepository;
        }

        public async Task<ServiceMessage> Add(AddTeamDto addteamDto)
        {
            var teamEntity = new TeamEntity // -> Transfering data from dto to entity for saving database.
            {
                CreatedUser = addteamDto.CreatedUser,
                Image = addteamDto.Image,
                LeagueId = addteamDto.LeaugeId,
                NationId = addteamDto.NationId,
                ModifiedUser = addteamDto.ModifiedUser,
                Name = addteamDto.Name,
            };

            _teamRepository.Add(teamEntity); // -> Adding database with repository

            try
            {
                await _unitOfWork.SaveChangesAsync(); // -> I created my SaveChanges in my UnitOfWork layer
            }
            catch (Exception)
            {

                throw new Exception("There is a error while team adding...");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Team is added successfully ..."
            };
        }

        public async Task<ServiceMessage> DeleteById(int id)
        {
            var deleteTeam = _teamRepository.GetById(id); // -> Firstly check logic is there deleted team in db or not
            if (deleteTeam is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "The team you want to delete is not found ..."
                };
            }

            // ▼ This part for sending deleted team players to No Team that I created in database - You can think like when team deleted what happened to players? In my scenario I created 'No Team' ▼
            var playersToUpdate = await _playerRepository.GetAll(p => p.TeamId == id).ToListAsync();
            playersToUpdate.ForEach(p => p.TeamId = 6);

            _teamRepository.Delete(deleteTeam); // -> Deleting team with repository

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("There is a error while deleting team ...");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Delete process is succesfull ..."
            };
        }

        public async Task<List<TeamDto>> GetAll()
        {
            var teams = await _teamRepository.GetAll() // -> use IQueryable from repository I create can helps for Eager Loading
                                      .Select(t => new TeamDto
                                      {
                                          CreatedUser = t.CreatedUser,
                                          Image = t.Image,
                                          ModifiedUser = t.ModifiedUser,
                                          League = t.League.Name,
                                          Name = t.Name,
                                          Nation = t.Nation.Name,
                                          Players = t.Players.Select(tp => new TeamPlayerDto { Name = tp.Name }).ToList()
                                      }).ToListAsync();

            return teams;
        }

        public async Task<ServiceMessage<TeamDto>> GetTeam(int id)
        {
            var team = await _teamRepository.GetAll(t => t.Id == id) // -> use IQueryable from repository I create can helps for Eager Loading
                                      .Select(t => new TeamDto
                                      {
                                          CreatedUser = t.CreatedUser,
                                          Image = t.Image,
                                          ModifiedUser = t.ModifiedUser,
                                          League = t.League.Name,
                                          Name = t.Name,
                                          Nation = t.Nation.Name,
                                          Players = t.Players.Select(tp => new TeamPlayerDto { Name = tp.Name }).ToList()
                                      }).FirstOrDefaultAsync();

            if (team is null)
            {
                return new ServiceMessage<TeamDto>
                {
                    IsSucceed = false,
                    Message = "The team you are trying to find is not found ..."
                };
            }

            return new ServiceMessage<TeamDto>
            {
                IsSucceed = true,
                Data = team
            };
        }

        public async Task<ServiceMessage> UpdateTeam(UpdateTeamDto dto)
        {
            var updatedTeam = _teamRepository.GetById(dto.Id); // -> Finding updated team first
            if (updatedTeam is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "The team you are trying to update did not found ..."
                };
            }

            // ▼ Update part from dto to entity ▼
            updatedTeam.NationId = dto.NationId;
            updatedTeam.LeagueId = dto.LeaugeId;
            updatedTeam.Name = dto.Name;
            updatedTeam.ModifiedUser = dto.ModifiedUser;
            updatedTeam.Image = dto.Image;

            _teamRepository.Update(updatedTeam);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("There is a error while deleting team ...");
            }

            return new ServiceMessage
            {
                Message = "Team is updated successfully ..."
            };
        }
    }
}
