using OmniConf.Core.Model;
using System;
using System.Linq;
using GenFu;

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
            A.Configure<BaseEntity>()
    .Fill(s => s.Id, () => 0);

            SeedConferences();
            SeedSpeakers();
            SeedSessions();
        }

        private void SeedSessions()
        {
            var sessions = A.ListOf<Session>(40);
            _dbContext.AddRange(sessions);
            
            _dbContext.SaveChanges();
        }

        private void SeedSpeakers()
        {
            A.Configure<Speaker>()
                .Fill(s => s.ImageFile).AsFirstName();
            
            var speakers = A.ListOf<Speaker>(40);
            _dbContext.AddRange(speakers);

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
