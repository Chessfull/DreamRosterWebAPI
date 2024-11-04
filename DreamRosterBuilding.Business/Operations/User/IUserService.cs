using DreamRosterBuilding.Business.Operations.User.Dtos;
using DreamRosterBuilding.Business.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Business.Operations.User
{
    public interface IUserService // -> Service interface for I will use User operations
    {
        Task<ServiceMessage> AddUser(AddUserDto userDto); // -> 'ServiceMessage' is object I defined for I need return bool like succeed or not, I need message and also somewhere I can be need data as well.
        Task<ServiceMessage<UserInfoDto>> LoginUser(LoginUserDto userDto); // -> I used generic service message here cause I will use logined user infos which I use this with data transfer object I created
        UserInfoDto GetUser(int id);
    }
}
