using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OmniConf.Core.Interfaces;
using OmniConf.Web.ViewModels.Home;
using Microsoft.Framework.OptionsModel;
using OmniConf.Web.ViewModels.Sessions;

namespace OmniConf.Web.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly ISiteSettings _settings;
        public SessionsController(ISessionRepository sessionRepository,
            IOptions<SiteSettings> siteSettingsAccessor)
        {
            _sessionRepository = sessionRepository;
            _settings = siteSettingsAccessor.Value;
        }
        public IActionResult Index()
        {
            var confId = (int)HttpContext.Items[SiteConstants.CurrentConferenceKey];
            var sessions = _sessionRepository.ListForConferenceId(confId);
            if(sessions == null)
            {
                throw new Exception("No sessions found");
            }

            var viewmodel = new SessionsViewModel()
            {
                Sessions = sessions.Select(s => new SessionsViewModel.SessionViewModel()
                {
                    Description = s.Description,
                    Title = s.Title,
                    Id = s.Id
                }).ToList()
            };

            return View(viewmodel);
        }
    }
}
