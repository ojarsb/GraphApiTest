using FluentAssertions;
using GraphApi.Core.Helpers;
using GraphApi.Core.Identity;
using GraphApi.Core.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace GraphApi.Test
{
    [TestFixture]
    public class GroupTests
    {
        [Test]
        public void GetGroups()
        {
            var service = TestServiceLocator.GetGroupService();
            var apps = service.GetGroups();

            apps.Result.List.Should().NotBeNull();
            apps.Result.List.Should().NotBeEmpty();
        }
    }
}