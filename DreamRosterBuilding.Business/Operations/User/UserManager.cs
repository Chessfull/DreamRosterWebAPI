using DreamRosterBuilding.Business.DataProtection;
using DreamRosterBuilding.Business.Operations.User.Dtos;
using DreamRosterBuilding.Business.Types;
using DreamRosterBuilding.Data.Entities;
using DreamRosterBuilding.Data.Enums;
using DreamRosterBuilding.Data.Repositories;
using DreamRosterBuilding.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.User
{
    public class UserManager : IUserService // -> Service Manager of User operations
    {
        private readonly IUnitOfWork _unitOfWork; // -> Calling UOW for transactions, async saves ...
        private readonly IRepository<UserEntity> _userRepository; // -> I defined my repository as generic so in UserManager T= UserEntity 
        private readonly IDataProtection _dataProtection;

        public UserManager(IUnitOfWork unitOfWork, IRepository<UserEntity> userRepository, IDataProtection dataProtection)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _dataProtection = dataProtection;
        }
        public async Task<ServiceMessage> AddUser(AddUserDto userDto)
        {
            var emailCheck = _userRepository.GetAll(u => u.Email.ToLower() == userDto.Email.ToLower()); //->Checking email is already in our database or not

            if (emailCheck.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = $"Sorry this email '{userDto.Email}' already registered."
                };
            }

            var userEntity = new UserEntity() // -> For adding database I need UserEntity so 'DTO to Entity'
            {
                Email = userDto.Email,
                Password = _dataProtection.Crypt(userDto.Password), // -> crypt password for security with business layer DataProtection service
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                BirthDate = userDto.Birthdate,
                UserRole = UserRole.User
            };

            _userRepository.Add(userEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync(); // -> Saving database with UOW
            }
            catch (Exception)
            {
                throw new Exception("There is a mistake along user registration");
            }

            return new ServiceMessage
            {
                IsSucceed = true,
                Message = "Registration is successfull"
            };
        }

        public async Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto userDto)
        {
            var userEntity = _userRepository.Get(u => u.Email.ToLower() == userDto.Email.ToLower()); //->Checking email is already in our database or not

            if (userEntity is null)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = $"Sorry we can not find user with registered this email '{userDto.Email}'."
                };
            }

            var encryptPassword = _dataProtection.Encrypt(userEntity.Password); // -> Encrypt password for check

            // ▼ Checking password, is okay get UserInfoDto in service message as well ▼
            if (encryptPassword == userDto.Password)
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = true,
                    Data = new UserInfoDto
                    {
                        Email = userEntity.Email,
                        FirstName = userEntity.FirstName,
                        LastName = userEntity.LastName,
                        UserRole = userEntity.UserRole

                    }
                };
            }
            else
            {
                return new ServiceMessage<UserInfoDto>
                {
                    IsSucceed = false,
                    Message = $"Sorry password or email is incorrect."
                };
            }
        }

        public UserInfoDto GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            var userInfo = new UserInfoDto { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, UserRole = user.UserRole };
            return userInfo;
        }
    }
}
