using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Domain.Entities;

namespace ProgrammingTest.Application.Interfaces
{
    public interface IApplicationDbContext
    {

        public DbSet<User> Users { get; }
        public DbSet<BodyRecord> BodyRecords { get; }
        public DbSet<ColumnItem> ColumnItems { get; }
        public DbSet<DateAchievement> DateAchievements { get; }
        public DbSet<Diary> Diaries { get; }
        public DbSet<Exercise> Exercises { get; }
        public DbSet<Meal> Meals { get; }
        public DbSet<UserProfile> UserProfiles { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
