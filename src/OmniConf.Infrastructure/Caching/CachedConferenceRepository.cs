using OmniConf.Core.Interfaces;
using System.Collections.Generic;
using OmniConf.Core.Model;
using OmniConf.Infrastructure.Data;
using Microsoft.Framework.Logging;
using Cachify;

namespace OmniConf.Infrastructure.Caching
{
    public class CachedConferenceRepository : IConferenceRepository
    {
        private readonly ConferenceRepository _underlyingRepository;
        private readonly ILogger<CachedConferenceRepository> _logger;
        private readonly Cacher _cacher;
        public CachedConferenceRepository(ConferenceRepository conferenceRepository,
            ILogger<CachedConferenceRepository> logger,
            Cacher cacher)
        {
            _underlyingRepository = conferenceRepository;
            _logger = logger;
            _cacher = cacher;
        }
        public Conference GetById(int id)
        {
            _logger.LogInformation($"{nameof(CachedConferenceRepository.GetById)}({id}) called.");
            return _cacher.CacheAction<Conference>(()=>_underlyingRepository.GetById(id));
        }

        public IEnumerable<Conference> List()
        {
            _logger.LogInformation($"{nameof(CachedConferenceRepository.List)}() called.");

            return _cacher.CacheAction(() => _underlyingRepository.List());
        }
    }
}
