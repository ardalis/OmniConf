using OmniConf.Core.Model;
using System.Collections.Generic;

namespace OmniConf.Core.Interfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        IEnumerable<Session> ListForConferenceId(int conferenceId);
    }
}
