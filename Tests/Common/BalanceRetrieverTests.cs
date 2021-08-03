using MyFlat.Common;
using MyFlat.Dto;
using System;
using Xunit;

namespace Tests.Common
{
    public class BalanceRetrieverTests
    {
        static private readonly string _html = @"
<!DOCTYPE html>
<html>
	<head>
		<meta name=""viewport"" content=""width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no"">
		<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
<meta name=""keywords"" content=""жкх управляющая компания коммунальные услуги капитальный ремонт"">
<meta name=""description"" content=""Мы поставляем отопление и ГВС в жилые дома и коммерческую недвижимость."">
        <div class=""personal-account__title-debt"">
            Задолженность по счету        </div>
        <div class=""personal-account__debt"">
            <span v-if=""arrayResult.DEBT"">{{arrayResult.DEBT.DEBT_END}} руб.</span>
            <span v-else="""">0.00 руб.</span>
        </div>
        <div class=""personal-account__title-address"">
            Адреc        </div>
        <div class=""personal-account__address"">
            {{arrayResult.CURRENT.ADDRESS}}
        </div>
        <div class=""personal-account__pay-button"">
            <a href=""/personal/payment/"">
                <button class=""form-variable__button form-variable__saved link-theme-default"">
                    Оплатить                </button>
            </a>
        </div>
    </div>
</div>


<!--'start_frame_cache_4arKOO'--><script>
	var arrayResultForJs = {""ACCOUNTS"":[{""TYPE"":""1"",""DEBT"":{""DEBT_END"":""1023.17"",""~DEBT_END"":""0.00""}};
	</body>
</html>";

        [Fact]
        public void TryGetBalance_LiveHtml_Success()
        {
            Assert.True(BalanceRetriever.TryGetBalance(_html, out decimal result));
            Assert.Equal(1023.17M, result);
        }

        [Fact]
        public void TryGetBalance_EmptyString_False()
        {
            Assert.False(BalanceRetriever.TryGetBalance("", out _));
        }
    }
}
