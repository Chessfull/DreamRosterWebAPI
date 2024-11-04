using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Entities
{
    // ▼ BaseEntity for entity classes common props ▼
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } // -> For soft delete processes
    }

    // ▼ Base configs for databases, common fluent apis with generic way I defined ▼
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        // ▼ Base configurations for all derived class ▼
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) // -> Virtual key for override this and extra if need additional configs
        {
            builder.HasQueryFilter(q => q.IsDeleted == false); // -> For using this filter on all database queries soft delete check with common way
        }

        // ▼  I will make this validation on my all entities so I defined here to use for maintenance, reuseability like I can define required false or maxLength default later and only change here etc.
        public void NameValidation(EntityTypeBuilder<TEntity> builder, int maxLength=50,bool nameRequired=true)
        {
            builder.Property(p=>p.Name).HasMaxLength(maxLength);
            builder.Property(p=>p.Name).IsRequired(nameRequired);
        }
    }
}
