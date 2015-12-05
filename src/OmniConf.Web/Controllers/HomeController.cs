using System;
using Microsoft.AspNet.Mvc;
using OmniConf.Core.Interfaces;
using OmniConf.Web.ViewModels.Home;
using Microsoft.Extensions.OptionsModel;

namespace OmniConf.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ISiteSettings _settings;
        public HomeController(IConferenceRepository conferenceRepository,
            IOptions<SiteSettings> siteSettingsAccessor)
        {
            _conferenceRepository = conferenceRepository;
            _settings = siteSettingsAccessor.Value;
        }
        public IActionResult Index()
        {
            var confId = (int)HttpContext.Items[SiteConstants.CurrentConferenceKey];
            var conference = _conferenceRepository
                .GetById(confId);
            if(conference == null)
            {
                throw new Exception("No conference found");
            }

            var viewmodel = new HomeViewModel()
            {
                ConferenceName = conference.Name,
                StartDate = conference.ConferenceStart
            };

            return View(viewmodel);
        }

        public IActionResult Sessions()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Speakers()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
