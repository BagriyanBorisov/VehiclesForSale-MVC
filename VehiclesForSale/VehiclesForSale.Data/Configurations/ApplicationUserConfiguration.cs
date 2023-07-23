namespace VehiclesForSale.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using Models;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(Seed());
        }

        public IEnumerable<ApplicationUser> Seed()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();

            //Seeding the User to AspNetUsers table
            ApplicationUser admin = new ApplicationUser()
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                Email = "Pesho.peshev@abv.bg",
                UserName = "Pesho",
                NormalizedUserName = "pesho",
                PasswordHash = hasher.HashPassword(null, "admin1234")
            };

            ApplicationUser user = new ApplicationUser()
            {
                Id = "a123as23-a24d-4543-a6c6-9443d048cdb9", // primary key
                Email = "Gosho.goshev@abv.bg",
                UserName = "Gosho",
                NormalizedUserName = "gosho",
                PasswordHash = hasher.HashPassword(null, "user1234")
            };

            users.Add(admin);
            users.Add(user);


            return users;
        }
    }
}
