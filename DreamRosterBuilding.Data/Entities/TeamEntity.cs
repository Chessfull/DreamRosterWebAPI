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
    public class TeamEntity : BaseEntity
    {
        //public IconEntity Icon { get; set; }
        public NationEntity Nation { get; set; }
        public string Image { get; set; }

        // ▼ In my scenario teams and players can be edited by users so I want logging last modifiers for viewing and also you can create AuditService for recording all actions but for now I just only need last modifiers and creaters name ▼
        public string ModifiedUser { get; set; } = "admin"; // -> as default admin
        public string CreatedUser { get; set; } = "admin";  // -> as default admin

        // ▼ Relations ▼
        //public int IconId { get; set; } // -> foreign key
        public int NationId { get; set; } // -> foreign key
        public int LeagueId { get; set; } // -> foreign key
        public LeagueEntity League { get; set; } // -> one to many relation from league
        public ICollection<PlayerEntity> Players { get; set; } // -> one to many relation to players
    }

    public class TeamConfiguration : BaseConfiguration<TeamEntity>
    {
        public override void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Relation Config ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api for more control) 
            builder.HasMany(t => t.Players)
                    .WithOne(p => p.Team)
                    .HasForeignKey(p => p.TeamId)
                    .OnDelete(DeleteBehavior.NoAction); // -> I use soft deleting system so this is for avoiding cascade deleting error

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new TeamEntity { Id=1, NationId=1, LeagueId=1, Name="Fenerbahçe", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now, IsDeleted=false,ModifiedUser="admin", CreatedUser="admin", Image= "images/teams/Fenerbahce.png" },
                new TeamEntity { Id=2, NationId=1, LeagueId=1, Name="Galatasaray", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now, IsDeleted=false,ModifiedUser="admin", CreatedUser="admin", Image= "images/teams/Galatasaray.png" },
                new TeamEntity { Id=3, NationId=2, LeagueId=2, Name="Real Madrid", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now, IsDeleted=false,ModifiedUser="admin", CreatedUser="admin", Image= "images/teams/Real_Madrid.png" },
                new TeamEntity { Id=4, NationId=2, LeagueId=2, Name="Barcelona", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now, IsDeleted=false,ModifiedUser="admin", CreatedUser="admin", Image= "images/teams/Barcelona.png" }
                
                );

            // ▼ Name validation config setups also coming from BaseConfiguration ▼
            NameValidation(builder); // -> using default name validation parameters on base config no need change here
        }
    }
}
