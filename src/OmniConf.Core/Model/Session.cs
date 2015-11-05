using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniConf.Core.Model
{
    public class Session : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
