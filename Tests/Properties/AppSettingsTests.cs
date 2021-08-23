using MyFlat.Properties;
using Xunit;

namespace Tests.Properties
{
    public class AppSettingsTests
    {
        [Fact]
        public void UpdateAndCheckNecessityToDisplay_InvoiceIsZero_False()
        {
            AssertValidResult(0, 0, 0, false);
        }

        [Fact]
        public void UpdateAndCheckNecessityToDisplay_InvoiceBecomesZero_False()
        {
            AssertValidResult(1234.56M, 3, 0, false, 0, 0);
        }

        [Fact]
        public void UpdateAndCheckNecessityToDisplay_NewInvoice_True()
        {
            AssertValidResult(0, 0, 3456.00M, true, 3456.00M, 1);
        }

        [Fact]
        public void UpdateAndCheckNecessityToDisplay_DisplayCountExceedsThreshold_False()
        {
            AssertValidResult(5678.56M, AppSettings.DisplayThreshold, 5678.56M, false,
                5678.56M, AppSettings.DisplayThreshold + 1);
        }

        #region Assertion method

        private void AssertValidResult(
            decimal storedInvoice, int storedDisplayCount, decimal newInvoive,
            bool expectedResult, decimal? expectedInvoice = null, int? expectedDisplayCount = null)
        {
            var physicalSettings = new SettingsStub
            {
                Invoice = storedInvoice,
                DisplayCount = storedDisplayCount
            };
            var settings = new AppSettings(physicalSettings);
            bool actualResult = settings.UpdateAndCheckNecessityToDisplay(newInvoive);

            Assert.Equal(expectedResult, actualResult);
            if (expectedInvoice != null)
                Assert.Equal(expectedInvoice, physicalSettings.Invoice);
            if (expectedDisplayCount != null)
                Assert.Equal(expectedDisplayCount, physicalSettings.DisplayCount);
        }

        #endregion
    }
}
