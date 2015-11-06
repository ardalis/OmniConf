using OmniConf.Core.Model;
using Microsoft.Framework.Logging;

namespace OmniConf.Infrastructure.Data
{
    public class ConferenceRepository : Repository<Conference>
    {
        public ConferenceRepository(ApplicationDbContext dbContext,
            ILogger<ConferenceRepository> logger) : base(dbContext,logger)
        {
        }
    }
}
