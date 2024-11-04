using DreamRosterBuilding.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class PlayerEntity : BaseEntity
    {
        public DateTime BirthDate { get; set; }
        public HairColor HairColor { get; set; } // -> Enum, static values in my scenario
        public Skin Skin { get; set; } // -> Enum, static values in my scenario
        public Tattoo? Tattoo { get; set; } // -> Enum, static values in my scenario

        // ▼ In my scenario teams and players can be edited by users so I want logging last modifiers for viewing and also you can create AuditService for recording all actions but for now I just only need last modifiers and creaters name ▼
        public string ModifiedUser { get; set; } = "admin"; // -> as default admin
        public string CreatedUser { get; set; } = "admin";  // -> as default admin


        // ▼ Relations ▼
        public int IconId { get; set; } // -> foreign key
        public IconEntity Icon { get; set; } // -> According to user hair, skin and tattoo choices will be icon represent this. 
        public int NationId { get; set; } // -> foreign key
        public NationEntity Nation { get; set; } // -> navigation, each footballer belong one nation and nation can have multiple footballers
        public int LeagueId { get; set; } // -> foreign key
        public LeagueEntity League { get; set; } // -> navigation, each footballer belong one League and Leauge can have multiple footballers
        public int TeamId { get; set; } // -> foreign key
        public TeamEntity Team { get; set; } // -> navigation, each footballer belong one Team and Team can have multiple footballers

        // ▼ Many to many Relations ▼
        public ICollection<PlayerSkillEntity> PlayerSkills { get; set; } // -> each player can have multiple skills and each skill can belong to many footballers ...

        public ICollection<PlayerPositionEntity> PlayerPositions { get; set; } // ->  each player can have multiple positions and each position can belong to many footballers ...
    }

    public class PlayerConfiguration : BaseConfiguration<PlayerEntity>
    {
        public override void Configure(EntityTypeBuilder<PlayerEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Additional config ▼
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.HairColor).IsRequired();
            builder.Property(p => p.Skin).IsRequired();
            builder.Property(p => p.Tattoo).IsRequired(false);

            // ▼ Relation Configs ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api for more control) 

            builder.HasMany(p => p.PlayerSkills)
                   .WithOne(ps => ps.Player)
                   .HasForeignKey(ps => ps.PlayerId);

            builder.HasMany(p => p.PlayerPositions)
                   .WithOne(pp => pp.Player)
                   .HasForeignKey(pp => pp.PlayerId);

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new PlayerEntity {Id=1, BirthDate=DateTime.Now, HairColor=HairColor.Black,Skin=Skin.Medium,Tattoo=null,IconId=1,NationId=2, LeagueId=2,TeamId=4,Name="Mert Topcu", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now, IsDeleted=false,ModifiedUser="admin",CreatedUser="admin" },
                
                new PlayerEntity { Id = 2, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Roberto Carlos", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" }, 
                
                new PlayerEntity { Id = 3, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Paulo Maldini", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 4, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Lucio", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 5, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Cafu", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 6, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Stevan Gerrard", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 7, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Philip Lahm", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 8, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Ronaldinho", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 9, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Cristiana Ronaldo", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 10, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Lionel Messi", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" },

                new PlayerEntity { Id = 11, BirthDate = DateTime.Now, HairColor = HairColor.Black, Skin = Skin.Medium, Tattoo = null, IconId = 1, NationId = 2, LeagueId = 2, TeamId = 4, Name = "Ronaldo Nazario", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false, ModifiedUser = "admin", CreatedUser = "admin" }

                );


            // ▼ Name validation config setups also coming from BaseConfiguration ▼
            NameValidation(builder, 30); // -> using maxlength as 100 here on player name
        }
    }
}
