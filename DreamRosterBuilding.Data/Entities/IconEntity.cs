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
    public class IconEntity : BaseEntity// -> For using Icon Images like team icon, player icon
    {
        public string ImagePath { get; set; }
        public HairColor HairColor { get; set; }
        public Skin Skin { get; set; }
        public Tattoo? Tattoo { get; set; }
        public ICollection<PlayerEntity> Players { get; set; }
       
    }

    public class IconConfiguration : BaseConfiguration<IconEntity>
    {
        public override void Configure(EntityTypeBuilder<IconEntity> builder)
        {
            // ▼ Base config ▼
            base.Configure(builder);

            // ▼ Additional config ▼
            builder.Property(p => p.ImagePath).IsRequired();

            // ▼ Relation Configs ▼ 
            //(With right naming EF Core can aumatically define relations but I mostly choose define with Fluent Api as well for more control) 

            builder.HasMany(I => I.Players)
                   .WithOne(p => p.Icon)
                   .HasForeignKey(p => p.IconId)
                   .OnDelete(DeleteBehavior.NoAction); // -> I use soft deleting system so this is for avoiding cascade deleting error

            // ▼ Adding Seed Data ▼
            builder.HasData(
                new IconEntity { Id=1,Name="BlackHairMediumSkinNoTattoo", HairColor= HairColor.Black,Skin=Skin.Medium, ImagePath= "images/icons/icon-default.png", CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,IsDeleted=false,Tattoo=null }
                );
        }
    }
}
