using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class LeagueEntity:BaseEntity
    {

        // ▼ Relations ▼
        public int NationId { get; set; } // -> foreign key
        public NationEntity Nation { get; set; } // -> navigation
        public ICollection<TeamEntity> Teams { get; set; } // -> one to many relation with teams
        public ICollection<PlayerEntity> Players { get; set; } // -> one to many relation with players

    }

    public class LeagueConfiguration : BaseConfiguration<LeagueEntity>
    {
        public override void Configure(EntityTypeBuilder<LeagueEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Relation Configs ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api for more control) 

            builder.HasMany(l => l.Teams)
                   .WithOne(t => t.League)
                   .HasForeignKey(t => t.LeagueId)
                   .OnDelete(DeleteBehavior.NoAction); // // -> I use soft deleting system so this is for avoiding cascade deleting error

            builder.HasMany(l => l.Players)
                   .WithOne(p => p.League)
                   .HasForeignKey(p => p.LeagueId)
                   .OnDelete(DeleteBehavior.NoAction); // -> I use soft deleting system so this is for avoiding cascade deleting error

            //▼ Adding Seed Data ▼
            builder.HasData(
                new LeagueEntity { Id=1, NationId=1, Name= "Süper Lig", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,IsDeleted=false },
                new LeagueEntity { Id=2, NationId=2, Name="LaLiga", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,IsDeleted=false }
                );

            // ▼ Name validation config setups also coming from BaseConfiguration ▼
            NameValidation(builder); // -> using default name validation parameters on base config no need change here
        }
    }
}
