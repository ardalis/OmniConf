using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniConf.Core.Model
{
    public class Speaker : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageFile { get; set; }
        public string Bio { get; set; }
        public int ConferenceId { get; set; }
    }
}
