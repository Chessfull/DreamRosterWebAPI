using DreamRosterBuilding.Data.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; } // -> also username
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // Setting full name from firstname and lastname
        public DateTime BirthDate { get; set; }
        public UserRole UserRole { get; set; } = UserRole.User;

    }

    public class UserConfiguration : BaseConfiguration<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Additional configs except from BaseConfiguration ▼

            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();

            builder.Ignore(p => p.Name); // -> I dont need BaseEntity name prop here, I have fullname prop for this reason

        }
    }

}
