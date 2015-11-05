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
        }

        private void SeedConferences()
        {
            if(!_dbContext.Conferences.Any())
            {
                _dbContext.Conferences.Add(new Conference()
                {
                    Name = "Omni Conference",
                    ConferenceStart = new DateTime(2016, 5, 1),
                    ConferenceEnd = new DateTime(2016, 5, 1),
                    RegistrationStart = new DateTime(2016, 4, 1)
                });
            }
            _dbContext.SaveChanges();
        }

    }
}
