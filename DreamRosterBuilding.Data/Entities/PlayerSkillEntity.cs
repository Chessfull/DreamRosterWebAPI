using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class PlayerSkillEntity: BaseEntity // -> Join table for many to many relation between players and skills
    {
        public int PlayerId { get; set; }
        public int SkillId { get; set; }
        public PlayerEntity Player { get; set; }
        public SkillEntity Skill { get; set; }

    }

    public class PlayerSkillConfiguration : BaseConfiguration<PlayerSkillEntity>
    {
        public override void Configure(EntityTypeBuilder<PlayerSkillEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Additional config ▼
            builder.Ignore(p => p.Id); // -> I defined composite key so I ignored base id property
            builder.Ignore(p => p.Name); // -> I dont need name prop here so I ignored base name prop

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new PlayerSkillEntity { PlayerId = 1, SkillId = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false }
                );

            builder.HasKey("PlayerId", "SkillId"); // -> Composite Key
        }
    }
}
