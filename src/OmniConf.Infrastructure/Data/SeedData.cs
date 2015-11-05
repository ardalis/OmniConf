using OmniConf.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniConf.Infrastructure.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _dbContext;
        public SeedData(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SeedAll()
        {
            SeedConferences();
            SeedSpeakers();
            SeedSessions();
        }

        private void SeedSessions()
        {
            _dbContext.Sessions.Add(new Session()
            {
                Title = "Getting Started with ASP.NET 5",
                Description = "A talk about what's new in ASP.NET 5 and how to get started building applications using this new framework."
            });
            _dbContext.Sessions.Add(new Session()
            {
                Title = "Improving the Design of Existing Software",
                Description = "Software tends to suffer from bit rot over time, sometimes collapsing the weight of hacks, spaghetti code, and big ball of mud architecture. Learn how to incrementally improve your application's quality, reversing the trend and saving your project from declaring technical bankruptcy."
            });
            _dbContext.SaveChanges();
        }

        private void SeedSpeakers()
        {
            _dbContext.Speakers.Add(new Speaker()
            {
                FirstName = "Steve",
                LastName = "Smith",
                Bio = "Steve is a software craftsman, mentor, speaker, and trainer.",
                ImageFile="SteveSmith.jpg"
            });
            _dbContext.SaveChanges();
        }

        private void SeedConferences()
        {
            if(!_dbContext.Conferences.Any())
            {
                _dbContext.Conferences.Add(new Conference()
                {
                    Name = "Stir Trek 2016",
                    ConferenceStart = new DateTime(2016, 5, 6),
                    ConferenceEnd = new DateTime(2016, 5, 7),
                    RegistrationStart = new DateTime(2016, 4, 1),
                    StandardPrice = 99.0m,
                    IsActive=true
                });
            _dbContext.Conferences.Add(new Conference()
            {
                Name = "Stir Trek : Avengers Age of Ultron",
                ConferenceStart = new DateTime(2015, 5, 1),
                ConferenceEnd = new DateTime(2015, 5, 2),
                RegistrationStart = new DateTime(2015, 4, 1),
                StandardPrice = 75m,
                IsSoldOut = true,
                IsActive=false
                });
            }
            _dbContext.SaveChanges();
        }

    }
}
