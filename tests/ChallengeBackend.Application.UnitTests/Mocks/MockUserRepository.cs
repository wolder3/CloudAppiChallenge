using AutoFixture;
using ChallengeBackend.Domain;
using ChallengeBackend.Insfrastucture.Persistence;
using ChallengeBackend.Insfrastucture.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeBackend.Application.UnitTests.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<UserRepository> GetUnitRepository()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{dbContextId}")
                .Options;

            var streamerDbContextFake = new DbContextMock(options);
            streamerDbContextFake.Database.EnsureDeleted();
            var mockUserRepository = new Mock<UserRepository>(streamerDbContextFake);

            return mockUserRepository;
        }


        public static void AddDataUserRepository(UserDbContext userDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var users = fixture.CreateMany<User>().ToList();

            var user = fixture.Build<User>()
               .With(tr => tr.Id, 8001)
               .Create();

            user.Address.Id = 8001;

            users.Add(user);

            userDbContextFake.Users!.AddRange(users);
            userDbContextFake.SaveChanges();

        }

        public class DbContextMock : UserDbContext
        {
            public DbContextMock(DbContextOptions<UserDbContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>().Property(e => e.Id).ValueGeneratedNever();
                modelBuilder.Entity<Address>().Property(e => e.Id).ValueGeneratedNever();
            }
        }

    }
}
