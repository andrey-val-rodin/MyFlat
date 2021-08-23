namespace MyFlat.Properties
{
    public interface ISettings
    {
        decimal Invoice { get; set; }
        int DisplayCount { get; set; }

        void Save();
        void Reset();
    }
}
