using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class NationEntity : BaseEntity
    {


        // ▼ Relations ▼
        public int FlagId { get; set; } // -> Foreign key for flag
        public FlagEntity Flag { get; set; } // -> navigation
        public ICollection<LeagueEntity> Leagues { get; set; }  // -> one to many relation with leagues
        public ICollection<TeamEntity> Teams { get; set; }  // -> one to many relation with teams
        public ICollection<PlayerEntity> Players { get; set; }  // -> one to many relation with players
    }

    public class NationConfiguration : BaseConfiguration<NationEntity>
    {
        public override void Configure(EntityTypeBuilder<NationEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Relation Configs ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api for more control) 

            builder.HasMany(n => n.Leagues)
                    .WithOne(l => l.Nation)
                    .HasForeignKey(l => l.NationId);

            builder.HasMany(n => n.Teams)
                   .WithOne(t => t.Nation)
                   .HasForeignKey(t => t.NationId)
                   .OnDelete(DeleteBehavior.NoAction); // -> I use soft deleting system so this is for avoiding cascade deleting error

            builder.HasMany(n => n.Players)
                   .WithOne(p => p.Nation)
                   .HasForeignKey(p => p.NationId)
                   .OnDelete(DeleteBehavior.NoAction); // -> I use soft deleting system so this is for avoiding cascade deleting error

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new NationEntity {Id=1, FlagId=1,Name="Türkiye",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,IsDeleted=false},
                new NationEntity {Id=2, FlagId=2,Name="Spain",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,IsDeleted=false}
                );

            // ▼ Name validation config setups also coming from BaseConfiguration ▼
            NameValidation(builder); // -> using default name validation parameters on base config no need change here
        }
    }
}
