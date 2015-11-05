using OmniConf.Core.Model;
using System;

namespace OmniConf.Core.Model
{
    public class Conference : BaseEntity
    {
        public string Name { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime ConferenceStart { get; set; }
        public DateTime ConferenceEnd { get; set; }

        public bool IsSoldOut { get; set; }
    }
}
