using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class PlayerPositionEntity:BaseEntity // -> Join table for many to many relation between players and positions
    {
        public int PlayerId { get; set; }
        public int PositionId { get; set; }
        public PlayerEntity Player { get; set; }
        public PositionEntity Position { get; set; }
    }

    public class PlayerPositionConfiguration : BaseConfiguration<PlayerPositionEntity>
    {
        public override void Configure(EntityTypeBuilder<PlayerPositionEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Additional config ▼
            builder.Ignore(p=>p.Id); // -> I defined composite key so I ignored base id property
            builder.Ignore(p=>p.Name); // -> I dont need name prop here so I ignored base name prop

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new PlayerPositionEntity { PlayerId = 1, PositionId=1,CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,IsDeleted=false},
                new PlayerPositionEntity { PlayerId = 2, PositionId = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 3, PositionId = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 4, PositionId = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 5, PositionId = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 6, PositionId = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 7, PositionId = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 8, PositionId = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 9, PositionId = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 10, PositionId = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false },
                new PlayerPositionEntity { PlayerId = 11, PositionId = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false }
                );

            builder.HasKey("PlayerId", "PositionId"); // -> Composite Key

        }
    }
}
