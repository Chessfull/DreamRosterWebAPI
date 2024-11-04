using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class PositionEntity : BaseEntity // -> In my scenario footballers can play several positions like Right Forward and Left Forward ...
    {

        // -> ▼ Many to many relation with footballers / each player can have multiple positions and each position can belong to many footballers ... ▼
        public ICollection<PlayerPositionEntity> PlayerPositions { get; set; }
    }

    public class PositionConfiguration : BaseConfiguration<PositionEntity>
    {
        public override void Configure(EntityTypeBuilder<PositionEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Relation Config ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api for more control) 
            builder.HasMany(p => p.PlayerPositions)
                   .WithOne(pp => pp.Position)
                   .HasForeignKey(pp => pp.PositionId);

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new PositionEntity { Id=1,Name="GK",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,IsDeleted=false},
                new PositionEntity { Id = 2, Name = "LB", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 3, Name = "LCB", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 4, Name = "RCB", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 5, Name = "RB", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 6, Name = "MOL", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 7, Name = "MOR", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 8, Name = "MOO", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 9, Name = "LF", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 10, Name = "RF", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PositionEntity { Id = 11, Name = "ST", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false }
                );

            // ▼ Name validation config setups also coming from BaseConfiguration ▼
            NameValidation(builder,3); // -> using maxlength as 2 here on position name (ST,LF,GK etc. allowed in my project for now)
        }
    }
}
