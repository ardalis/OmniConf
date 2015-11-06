using OmniConf.Core.Interfaces;
using System.Linq;
using OmniConf.Core.Model;
using System.Collections.Generic;
using Microsoft.Framework.Logging;
using System;

namespace OmniConf.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<Repository<T>> _logger;
        public Repository(ApplicationDbContext dbContext,
            ILogger<Repository<T>> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public T GetById(int id)
        {
            _logger.LogInformation($"{nameof(GetById)}({id}) called.");

            return _dbContext.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
    }
}
