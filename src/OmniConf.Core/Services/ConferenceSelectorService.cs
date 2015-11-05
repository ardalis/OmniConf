using OmniConf.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniConf.Core.Services
{
    public class ConferenceSelectorService : IConferenceSelector
    {
        private readonly IConferenceRepository _conferenceRepository;
        public ConferenceSelectorService(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }
        public int GetCurrentConference(DateTime? forDate)
        {
            var forDateToUse = forDate ?? DateTime.Now;
            return _conferenceRepository
                .List()
                .Where(c => c.IsActive && c.ConferenceEnd > forDateToUse)
                .OrderBy(c => c.ConferenceStart)
                .FirstOrDefault()
                .Id;
        }
    }
}
