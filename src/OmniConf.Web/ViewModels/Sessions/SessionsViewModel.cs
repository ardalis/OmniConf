using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniConf.Web.ViewModels.Sessions
{
    public class SessionsViewModel
    {
        public List<SessionViewModel> Sessions { get; set; } = new List<SessionViewModel>();
        public class SessionViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
