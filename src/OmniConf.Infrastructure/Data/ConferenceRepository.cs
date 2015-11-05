using OmniConf.Core.Interfaces;
using System.Linq;
using OmniConf.Core.Model;
using System;
using System.Collections.Generic;

namespace OmniConf.Infrastructure.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ConferenceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Conference GetById(int id)
        {
            return _dbContext.Conferences.FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Conference> List()
        {
            return _dbContext.Conferences.AsEnumerable();
        }
    }
}
