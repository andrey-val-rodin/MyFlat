namespace MyFlat.Properties
{
    public class AppSettings
    {
        public const int DisplayThreshold = 2;
        private readonly ISettings _physicalSettings;

        public AppSettings(ISettings physicalSettings = null)
        {
            _physicalSettings = physicalSettings ?? new SettingsAdapter();
        }

        public bool UpdateAndCheckNecessityToDisplay(decimal globusInvoice)
        {
            bool result;
            if (globusInvoice == 0)
            {
                _physicalSettings.Reset();
                result = false;
            }
            else if (globusInvoice != _physicalSettings.Invoice)
            {
                _physicalSettings.Invoice = globusInvoice;
                _physicalSettings.DisplayCount = 1;
                result = true;
            }
            else
            {
                _physicalSettings.DisplayCount++;
                result = _physicalSettings.DisplayCount <= DisplayThreshold;
            }

            _physicalSettings.Save();
            return result;
        }
    }
}
