using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using back_end.Domain.Identity;
using back_end.ServiceContracts;
using back_end.Domain.Entities;
using back_end.Enums;

namespace back_end.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
            
        }

        public virtual DbSet<NewConnectionForm> NewConnectionForms { get; set; }
        public virtual DbSet<GasBooking> GasBookings { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<AdminRequest> AdminRequests { get; set; }

        public override int SaveChanges()
        {
            UpdateTimeStamp();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateTimeStamp();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateTimeStamp()
        {
            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IAuditable && (
            e.State == EntityState.Added
            || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((IAuditable)entityEntry.Entity).UpdateDate = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IAuditable)entityEntry.Entity).CreateDate = DateTime.UtcNow;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var AdminId = "7DBD5480-1224-4288-AEE8-1249F8A94E1A";
            var UserId = "3AC53885-3553-4B1C-93D2-4DECA3B4CB54";

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                    Id = Guid.Parse(AdminId),
                    ConcurrencyStamp = AdminId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new ApplicationRole
                {
                    Id = Guid.Parse(UserId),
                    ConcurrencyStamp = UserId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            };

            modelBuilder.Entity<ApplicationRole>().HasData(roles);

            modelBuilder.Entity<NewConnectionForm>().HasData(
                new NewConnectionForm
                {
                    ConnectionNo = 123456,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Dob = new DateTime(1985, 10, 15),
                    MaritalStatus = MaritalStatus.Single,
                    MobileNo = "1234567890",
                    Gender = "Male",
                    Nationality = Nationality.Indian,
                    Address = "123 Main Street",
                    AppliedDate =DateTime.UtcNow,
                    AddressProof = "Proof of Address",
                    RationCardNo = "ABC123XYZ456",
                    ConnectionStatus = ConnectionType.Pending,
                    Related = RelatedType.Father,
                    FirstName = "Jane",
                    LastName = "Doe",
                    RelatedAddress = "456 Elm Street",
                    City = "Anytown",
                    PinCode = "12345",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow,
                    UserId= "D5A241CA-6176-492D-9917-9692A57A0FA6"
                });

            modelBuilder.Entity<GasBooking>().HasData(
                new GasBooking
                {
                    CustomerName = "John Doe",
                    CustomerAddress = "123 Main Street",
                    CustomerPhoneNumber = "1234567890",
                    DeliveryDate = DateTime.UtcNow.AddDays(7),
                    Status = BookingStatus.Pending,
                    ConnectionNo = Guid.Parse("e3f3b30b-b841-4196-a665-f3eef01d7e58"),
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                });




        }

    }
}
