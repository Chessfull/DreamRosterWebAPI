using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    public class FlagEntity:BaseEntity // -> For nation flags
    {
        public string ImagePath { get; set; }
        public NationEntity Nation { get; set; }

    }

    public class FlagConfiguration : BaseConfiguration<FlagEntity>
    {
        public override void Configure(EntityTypeBuilder<FlagEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Additional config ▼
            builder.Property(p => p.ImagePath).IsRequired();

            // ▼ Relation Config ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api as well for more control) 
            builder.HasOne(f => f.Nation)
                   .WithOne(n => n.Flag)
                   .HasForeignKey<NationEntity>(n => n.FlagId);

            // ▼ Name validation config setups also coming from BaseConfiguration ▼
            NameValidation(builder); // -> using default name validation parameters on base config no need change here

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new FlagEntity {  Id=1, Name="Turkiye",ImagePath= "images/flags/Flag_of_Turkey.png", CreatedDate = DateTime.Now,ModifiedDate=DateTime.Now,IsDeleted=false },
                new FlagEntity { Id = 2, Name = "Spain", ImagePath = "images/flags/Flag_of_Spain.png", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsDeleted = false }
                );
        }
    }
}
