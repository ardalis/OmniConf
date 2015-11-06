using OmniConf.Core.Interfaces;
using System.Linq;
using OmniConf.Core.Model;
using System.Collections.Generic;
using Microsoft.Framework.Logging;

namespace OmniConf.Infrastructure.Data
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ConferenceRepository> _logger;
        public ConferenceRepository(ApplicationDbContext dbContext,
            ILogger<ConferenceRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public Conference GetById(int id)
        {
            _logger.LogInformation($"{nameof(GetById)}({id}) called.");
            return _dbContext.Conferences.FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Conference> List()
        {
            _logger.LogInformation($"{nameof(List)}() called.");
            return _dbContext.Conferences.AsEnumerable();
        }
    }
}
