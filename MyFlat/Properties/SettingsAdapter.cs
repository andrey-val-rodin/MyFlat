namespace MyFlat.Properties
{
    public class SettingsAdapter : ISettings
    {
        private readonly Settings _settings = new Settings();

        public decimal Invoice
        {
            get => _settings.Invoice;
            set => _settings.Invoice = value;
        }

        public int DisplayCount
        {
            get => _settings.DisplayCount;
            set => _settings.DisplayCount = value;
        }

        public void Save() => _settings.Save();
        public void Reset() => _settings.Reset();
    }
}
