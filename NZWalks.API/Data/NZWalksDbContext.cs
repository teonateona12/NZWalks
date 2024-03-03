using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("00f50172-e7df-4f73-9267-5c7f2e7672d0"),
                    Name = "Easy"
                },
                 new Difficulty()
                {
                    Id = Guid.Parse("6cb42f59-9288-42a3-a8be-7053a845591d"),
                    Name = "Medium"
                },
                  new Difficulty()
                {
                    Id = Guid.Parse("8544923a-9f7c-41df-9471-992802854ac8"),
                    Name = "Hard"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("be700c1e-790f-406d-9af9-91a9501869f2"),
                    Name="Auckland",
                    Code="AKL",
                    RegionImageUrl = "https://traveltimes.ru/wp-content/uploads/2022/01/okland-1.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("0c08d2ea-2946-4130-88da-98e42f77f620"),
                    Name="Northland",
                    Code="NTL",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("72c594e7-bd16-47c6-b519-909a61afefb1"),
                    Name="Bay Of Plenty",
                    Code="BOP",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("0be3ef6e-e738-49a2-918b-4ac39306b800"),
                    Name="Wellington",
                    Code="WGN",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("5cab363a-50cf-4565-86e3-0bcade0a9e86"),
                    Name="Nelson",
                    Code="NSL",
                    RegionImageUrl = null
                },
                new Region()
                {
                    Id = Guid.Parse("3b53ee0b-a80a-4e5d-8634-1c19944b5aae"),
                    Name="Southland",
                    Code="STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
