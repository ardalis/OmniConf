using OmniConf.Core.Model;
using System.Collections.Generic;

namespace OmniConf.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> List();
    }
}
