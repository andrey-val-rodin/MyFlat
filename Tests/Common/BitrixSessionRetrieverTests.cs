using MyFlat.Common;
using Xunit;

namespace Tests.Common
{
    public class BitrixSessionRetrieverTests
    {
        static private readonly string _html = 
            "SOME TEXT,'bitrix_sessid' : 'e99d80bdec5bb435a74a132b66d0de5f'});</script>";

        [Fact]
        public void TryGetBalance_LiveHtml_Success()
        {
            Assert.True(BitrixSessionRetriever.TryGetSessionId(_html, out string result));
            Assert.Equal("e99d80bdec5bb435a74a132b66d0de5f", result);
        }

        [Fact]
        public void TryGetBalance_EmptyString_False()
        {
            Assert.False(BalanceRetriever.TryGetBalance("", out _));
        }
    }
}
