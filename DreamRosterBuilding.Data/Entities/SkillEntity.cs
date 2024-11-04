using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class SkillEntity : BaseEntity // -> In my scenario footballer will have strong skills like Roberto Carlos very good at shooting etc.
    {


        // -> ▼ Many to many relation with footballers / each player can have multiple skills and each skill can belong to many footballers ... ▼
        public ICollection<PlayerSkillEntity> PlayerSkills { get; set; }
    }

    public class SkillConfiguration : BaseConfiguration<SkillEntity>
    {
        public override void Configure(EntityTypeBuilder<SkillEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Relation Config ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api for more control) 
            builder.HasMany(s => s.PlayerSkills)
                   .WithOne(ps => ps.Skill)
                   .HasForeignKey(ps => ps.SkillId);

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new SkillEntity { Id = 1, Name = "Keeping", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false }
                );

            // ▼ Name validation config setups also coming from BaseConfiguration ▼
            NameValidation(builder,20); // -> using maxlength as 20 here on skill allowed my project for now (Shooting, tackle, strength etc.)
        }
    }
}
