using System;

namespace OmniConf.Core.Interfaces
{
    public interface IConferenceSelector
    {
        int GetCurrentConference(DateTime? forDate);
    }
}
