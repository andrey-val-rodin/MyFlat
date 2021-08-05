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
        public async Task LogoffAsync_CorrectCredentials_True()
        {
            var service = new MosOblEircService(new MessengerStub());
            await service.AuthorizeAsync(Config.MosOblEircUser, Config.MosOblEircPassword);
            Assert.True(await service.LogoffAsync());
        }

        [Fact]
        public async Task LogoffAsync_NotAuthorized_Exception()
        {
            var service = new MosOblEircService(new MessengerStub());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await service.LogoffAsync());
        }

        [Fact]
        public async Task GetBalanceAsync_Success()
        {
            var service = new MosOblEircService(new MessengerStub());
            await service.AuthorizeAsync(Config.MosOblEircUser, Config.MosOblEircPassword);
            Assert.NotNull(await service.GetBalanceAsync());
            await service.LogoffAsync();
        }

        [Fact]
        public async Task GetMetersAsync_Success()
        {
            var service = new MosOblEircService(new MessengerStub());
            await service.AuthorizeAsync(Config.MosOblEircUser, Config.MosOblEircPassword);
            var meters = await service.GetMetersAsync();
            
            Assert.NotNull(meters);
            Assert.True(meters.Count == 5);
            // Kitchen cold water   323381, 17523577
            Assert.Contains(meters, m => m.Id_counter == 17523577);
            // Kitchen hot water    206922, 16702145
            Assert.Contains(meters, m => m.Id_counter == 16702145);
            // Bathroom cold water  323391, 17523578
            Assert.Contains(meters, m => m.Id_counter == 17523578);
            // Bathroom hot water   204933, 16702144
            Assert.Contains(meters, m => m.Id_counter == 16702144);
            // Electricity          19843385, 14680903
            Assert.Contains(meters, m => m.Id_counter == 14680903);

            await service.LogoffAsync();
        }
    }
}
