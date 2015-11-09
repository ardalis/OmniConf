using Microsoft.Framework.Logging;
using OmniConf.Core.Interfaces;
using OmniConf.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace OmniConf.Infrastructure.Data
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext dbContext,
ILogger<SessionRepository> logger) : base(dbContext, logger)
        {
        }

        public IEnumerable<Session> ListForConferenceId(int conferenceId)
        {
            return base._dbContext.Sessions
                .Where(s => s.ConferenceId == conferenceId)
                .AsEnumerable();
        }
    }
}
