using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using OmniConf.Core.Interfaces;
using OmniConf.Web.ViewModels.Home;

namespace OmniConf.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConferenceRepository _conferenceRepository;
        public HomeController(IConferenceRepository conferenceRepository)
        {
            _conferenceRepository = conferenceRepository;
        }
        public IActionResult Index()
        {
            var conference = _conferenceRepository
                .List()
                .FirstOrDefault();
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

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
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
