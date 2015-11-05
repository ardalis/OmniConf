using OmniConf.Core.Model;
using System.Collections.Generic;

namespace OmniConf.Core.Interfaces
{
    public interface IConferenceRepository
    {
        Conference GetById(int id);
        IEnumerable<Conference> List();
    }
}
