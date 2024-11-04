using DreamRosterBuilding.Business.Operations.Icon;
using DreamRosterBuilding.Business.Operations.Player.Dtos;
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

namespace DreamRosterBuilding.Business.Operations.Player
{
    public class PlayerManager : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork; // -> Calling UOW for transactions, async saves ...
        private readonly IRepository<PlayerEntity> _playerRepository; // -> I defined my repository as generic so in PlayerManager T= PlayerEntity 
        private readonly IRepository<PlayerPositionEntity> _playerPositionRepository; // -> I will use for playerpositions table processes
        private readonly IRepository<PlayerSkillEntity> _playerSkillRepository;   // -> I will use for playerskills table processes
        private readonly IRepository<TeamEntity> _teamRepository; // -> I will use for teams table operations like I am getting only TeamId from user and with that info I will match league logic behind
        private readonly IIconService _iconService; // -> I called this service is for icon operations I mean in my scenario Icon will change according to hair color, skin etc. so I need this player an team operations like who has icon

        public PlayerManager(IUnitOfWork unitOfWork, IRepository<PlayerEntity> playerRepository, IRepository<PlayerPositionEntity> playerPositionRepository,
            IRepository<PlayerSkillEntity> playerSkillRepository, IRepository<TeamEntity> teamRepository, IIconService iconService)
        {
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
            _playerPositionRepository = playerPositionRepository;
            _playerSkillRepository = playerSkillRepository;
            _teamRepository = teamRepository;
            _iconService = iconService;
        }

        public async Task<ServiceMessage> AddPlayer(AddPlayerDto addPlayerDto)
        {

            await _unitOfWork.BeginTransaction(); // -> Starting transaction cause of several database updates below: Player, PlayerSkills, PlayerPositions

            var playerEntity = new PlayerEntity // -> Transfering from dto to my entity
            {
                Name = addPlayerDto.Name,
                BirthDate = addPlayerDto.BirthDate,
                HairColor = addPlayerDto.HairColor,
                Skin = addPlayerDto.Skin,
                Tattoo = addPlayerDto.Tattoo,
                TeamId = addPlayerDto.TeamId,
                NationId = addPlayerDto.NationId,
                ModifiedUser = addPlayerDto.ModifiedUser,
                CreatedUser = addPlayerDto.CreatedUser,
                LeagueId = _teamRepository.Get(t => t.Id == addPlayerDto.TeamId).LeagueId, // -> I m only getting team from user and matching with league behind
                IconId = _iconService.GetIconId(addPlayerDto.HairColor, addPlayerDto.Skin, addPlayerDto.Tattoo) // -> this is for find iconid from hair,skin,tattoo in my scenario
            };

            _playerRepository.Add(playerEntity); // -> Adding players database

            try
            {
                await _unitOfWork.SaveChangesAsync(); // -> First transaction
            }
            catch (Exception)
            {

                throw new Exception("There is a error while player adding...");
            }

            // ▼ Iteration on position ids and adding PlayerPosition table with generic repository that I get Dependency injection above ▼
            foreach (var positionId in addPlayerDto.PositionIds)
            {
                var playerPositions = new PlayerPositionEntity
                {
                    PlayerId = playerEntity.Id,
                    PositionId = positionId
                };

                _playerPositionRepository.Add(playerPositions);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync(); // -> // -> Second transaction
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction(); // -> If there is a error when adding playerpositions rollback and dont add player as well
                throw new Exception("There is a error while player position adding...");
            }

            // ▼ Iteration on skill ids and adding PlayerSkill table with generic repository that I define Dependency injection above ▼
            foreach (var skillId in addPlayerDto.SkillIds)
            {
                var playerSkills = new PlayerSkillEntity
                {
                    PlayerId = playerEntity.Id,
                    SkillId = skillId
                };

                _playerSkillRepository.Add(playerSkills);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync(); // -> // -> Third transaction
                await _unitOfWork.CommitTransaction(); // -> If everytransactions is ok commit with UOW
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction(); // -> If there is a error when adding playerskills rollback and dont add player and playerpositions as well
                throw new Exception("There is a error while player skill adding...");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Player added successfully..."
            };
        }

        public async Task<ServiceMessage> DeletePlayer(int id)
        {
            var deletePlayer=_playerRepository.GetById(id);
            if (deletePlayer is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "The player you want to delete is not found ..."
                };
            }

            _playerRepository.Delete(deletePlayer);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("There is a error while deleting player ...");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Delete process is succesfull ..."
            };
        }

        public async Task<List<PlayerDto>> GetAll()
        {
            var players = await _playerRepository.GetAll()
                .Select(p => new PlayerDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    CreatedUser = p.CreatedUser,
                    HairColor = p.HairColor,
                    ModifiedUser = p.ModifiedUser,
                    Skin = p.Skin,
                    Tattoo = p.Tattoo,
                    Team = p.Team.Name,
                    Nation = p.Nation.Name,
                    Skills = p.PlayerSkills.Select(ps => new PlayerSkillDto
                    {
                        Id = ps.Id,
                        Title = ps.Skill.Name
                    }).ToList(),
                    Positions = p.PlayerPositions.Select(pp => new PlayerPositionDto
                    {
                        Id = pp.Id,
                        Title = pp.Position.Name
                    }).ToList()
                }).ToListAsync();

            return players;
        }

        public async Task<PlayerDto> GetPlayer(int id)
        {
            var player = await _playerRepository.GetAll(p => p.Id == id) // -> I used my IQueryable repo
                .Select(p => new PlayerDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    CreatedUser = p.CreatedUser,
                    HairColor = p.HairColor,
                    ModifiedUser = p.ModifiedUser,
                    Skin = p.Skin,
                    Tattoo = p.Tattoo,
                    Team = p.Team.Name,
                    Nation = p.Nation.Name,
                    Skills = p.PlayerSkills.Select(ps => new PlayerSkillDto
                    {
                        Id = ps.Id,
                        Title = ps.Skill.Name
                    }).ToList(),
                    Positions = p.PlayerPositions.Select(pp => new PlayerPositionDto
                    {
                        Id = pp.Id,
                        Title = pp.Position.Name
                    }).ToList()
                }).FirstOrDefaultAsync();

            return player;
        }

        public async Task<ServiceMessage> UpdatePlayer(UpdatePlayerDto updatePlayerDto)
        {
            var playerEntity = _playerRepository.GetById(updatePlayerDto.Id);

            if (playerEntity is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "This player did not found ..."
                };
            }

            await _unitOfWork.BeginTransaction(); // -> Starting transaction cause of several database updates below

            playerEntity.BirthDate = updatePlayerDto.BirthDate;
            playerEntity.HairColor = updatePlayerDto.HairColor;
            playerEntity.Skin = updatePlayerDto.Skin;
            playerEntity.Tattoo = updatePlayerDto.Tattoo;
            playerEntity.IconId = _iconService.GetIconId(updatePlayerDto.HairColor, updatePlayerDto.Skin, updatePlayerDto.Tattoo);
            playerEntity.NationId = updatePlayerDto.NationId;
            playerEntity.LeagueId = _teamRepository.Get(t => t.Id == updatePlayerDto.TeamId).LeagueId;
            playerEntity.TeamId = updatePlayerDto.TeamId;
            playerEntity.Name = updatePlayerDto.Name;
            playerEntity.ModifiedUser = updatePlayerDto.ModifiedUser;

            _playerRepository.Update(playerEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction(); // -> If there is a error go back
                throw new Exception("There is a error while updating player ...");
            }

            // ▼ I can not apply soft delete here cause of composite key at these many to many tables so firstly I need ex one and get update one ▼
            var playerPositions = _playerPositionRepository.GetAll(pp => pp.PlayerId == updatePlayerDto.Id).ToList();

            foreach (var playerPosition in playerPositions)
            {
                _playerPositionRepository.Delete(playerPosition, false);
            }

            foreach (var positionId in updatePlayerDto.PositionIds)
            {
                var playerPosition = new PlayerPositionEntity
                {
                    PlayerId = playerEntity.Id,
                    PositionId = positionId
                };

                _playerPositionRepository.Add(playerPosition);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction(); // -> If there is a error go back
                throw new Exception("There is a error while updation player positions ...");
            }

            var playerSkills = _playerSkillRepository.GetAll(ps => ps.PlayerId == updatePlayerDto.Id).ToList();

            foreach (var playerSkill in playerSkills)
            {
                _playerSkillRepository.Delete(playerSkill, false);
            }

            foreach (var skillId in updatePlayerDto.SkillIds)
            {
                var playerSKill = new PlayerSkillEntity
                {
                    PlayerId = playerEntity.Id,
                    SkillId = skillId
                };

                _playerSkillRepository.Add(playerSKill);
            }

            try
            {
                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction(); // -> If there is a error go back
                throw new Exception("There is a error while updation player skills ...");
            }
            return new ServiceMessage
            {
                IsSucceed = true,
                Message="UpdateTeam operations completed successfully ..."
            };
        }
    }
}
