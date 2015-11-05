using Moq;
using OmniConf.Core.Interfaces;
using OmniConf.Core.Model;
using OmniConf.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OmniConf.UnitTests.Core.Services
{
    public class ConferenceSelectorServiceShould
    {
        private readonly Mock<IConferenceRepository> _mockRepo;
        public ConferenceSelectorServiceShould()
        {
            _mockRepo = new Mock<IConferenceRepository>();
        }

        [Fact]
        public void ReturnFirstActiveConference()
        {
            _mockRepo.Setup(m => m.List()).Returns(ListTestConferences());
            var service = new ConferenceSelectorService(_mockRepo.Object);

            int confId = service.GetCurrentConference(new DateTime(2016, 1, 1));

            Assert.Equal(2, confId);

        }

        private IEnumerable<Conference> ListTestConferences()
        {
            return new List<Conference>()
            {
                new Conference()
                {
                    IsActive=false,
                    ConferenceStart=new DateTime(2016,4,1),
                    ConferenceEnd = new DateTime(2016,4,2),
                    Id=1
                },

                new Conference()
                {
                    IsActive=true,
                    ConferenceStart=new DateTime(2016,3,1),
                    ConferenceEnd = new DateTime(2016,3,2),
                    Id=2
                }
            };
        }
    }
}
