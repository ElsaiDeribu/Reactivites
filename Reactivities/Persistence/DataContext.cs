using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityAttendee> ActivityAttendees { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ActivityAttendee>(x => x.HasKey(aa => new {aa.AppUserId, aa.ActivityId}));
                        

            builder.Entity<ActivityAttendee>()
                           .HasOne(ca => ca.AppUser)
                           .WithMany(ca => ca.Activities)
                           .HasForeignKey(ca => ca.AppUserId);


            builder.Entity<ActivityAttendee>() 
                           .HasOne(ca => ca.Activity)
                           .WithMany(ca => ca.Attendees)
                           .HasForeignKey(ca => ca.ActivityId);
        }

    }
}