using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<BookingDetail> BookingDetail { get; set; }
        public DbSet<BookingSchedule> BookingSchedule { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseDetail> ExerciseDetail { get; set; }
        public DbSet<ExerciseResource> ExerciseResource { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<MedicalRecord> MedicalRecord { get; set; }
        public DbSet<Physiotherapist> Physiotherapist { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Slot> Slot { get; set; }
        public DbSet<SubProfile> SubProfile { get; set; }
        public DbSet<TypeOfSlot> TypeOfSlot { get; set; }
        public DbSet<FavoriteExercise> FavoriteExercise { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Relationship> Relationship { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Problem> Problem { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
