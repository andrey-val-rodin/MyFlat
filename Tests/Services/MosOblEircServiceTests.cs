using MyFlat;
using MyFlat.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Services
{
    public class MosOblEircServiceTests
    {
        [Fact]
        public async Task Authorize_WrongCredentials_False()
        {
            var service = new MosOblEircService(new MessengerStub());
            Assert.False(await service.AuthorizeAsync("user", "some password"));
        }

        [Fact]
        public async Task Authorize_CorrectCredentials_True()
        {
            var service = new MosOblEircService(new MessengerStub());
            Assert.True(await service.AuthorizeAsync(Config.MosOblEircUser, Config.MosOblEircPassword));
        }

        [Fact]
        public async Task Logoff_NotAuthorized_Exception()
        {
            var service = new MosOblEircService(new MessengerStub());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await service.LogoffAsync());
        }
    }
}
