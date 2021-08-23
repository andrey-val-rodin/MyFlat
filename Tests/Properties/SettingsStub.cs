using MyFlat.Properties;

namespace Tests.Properties
{
    class SettingsStub : ISettings
    {
        public decimal Invoice { get; set; }
        public int DisplayCount { get; set; }

        public void Reset()
        {
            Invoice = 0;
            DisplayCount = 0;
        }

        public void Save()
        {
        }
    }
}
