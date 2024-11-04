using DreamRosterBuilding.Data.Enums;
using System.Reflection.Metadata.Ecma335;

namespace DreamRosterBuilding.WebApi.Jwt
{
    public class JwtDto // -> for transfering in generatetoken
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole UserRole { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireMinutes { get; set; }

    }
}
