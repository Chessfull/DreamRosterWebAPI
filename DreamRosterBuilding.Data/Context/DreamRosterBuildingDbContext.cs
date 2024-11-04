using DreamRosterBuilding.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.Context
{
    public class DreamRosterBuildingDbContext:DbContext
    {

        // ▼ Sending DbContext constructor to project dbcontext with base(options) -> Second step for ef core building
        public DreamRosterBuildingDbContext(DbContextOptions<DreamRosterBuildingDbContext> options):base(options)
        {
            
        }

        // ▼ Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ▼ Applying config I sets ▼
            modelBuilder.ApplyConfiguration(new FlagConfiguration()); 
            modelBuilder.ApplyConfiguration(new IconConfiguration()); 
            modelBuilder.ApplyConfiguration(new LeagueConfiguration()); 
            modelBuilder.ApplyConfiguration(new NationConfiguration()); 
            modelBuilder.ApplyConfiguration(new PlayerConfiguration()); 
            modelBuilder.ApplyConfiguration(new PlayerPositionConfiguration()); 
            modelBuilder.ApplyConfiguration(new PlayerSkillConfiguration()); 
            modelBuilder.ApplyConfiguration(new PositionConfiguration()); 
            modelBuilder.ApplyConfiguration(new SkillConfiguration()); 
            modelBuilder.ApplyConfiguration(new TeamConfiguration()); 
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            // ▼ Seed data for setting will use on middleware ▼
            modelBuilder.Entity<SettingEntity>().HasData(
                new SettingEntity
                {
                    Id = 1,
                    Name="Maintenance",
                    MaintenanceMood=false,
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        // ▼ Defining Tables -> First step for ef core building ▼
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<FlagEntity> Flags => Set<FlagEntity>();
        public DbSet<NationEntity> Nations => Set<NationEntity>();
        public DbSet<LeagueEntity> Leagues => Set<LeagueEntity>();
        public DbSet<TeamEntity> Teams => Set<TeamEntity>();
        public DbSet<PlayerEntity> Players => Set<PlayerEntity>();
        public DbSet<PositionEntity> Positions => Set<PositionEntity>();
        public DbSet<SkillEntity> Skills => Set<SkillEntity>();
        public DbSet<PlayerPositionEntity> PlayerPositions => Set<PlayerPositionEntity>();
        public DbSet<PlayerSkillEntity> PlayerSkills => Set<PlayerSkillEntity>();
        public DbSet<IconEntity> Icons => Set<IconEntity>();
        public DbSet<SettingEntity> Settings  => Set<SettingEntity>();

    }
}
