using OmniConf.Core.Model;
using Microsoft.Framework.Logging;
using OmniConf.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
