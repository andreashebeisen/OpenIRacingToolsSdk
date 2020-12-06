namespace OpenIRacingTools.Sdk.Model
{
    public class RadioFrequency
    {
        public int FrequencyNum { get; private set; }
        public string FrequencyName { get; private set; }
        public int Priority { get; private set; }
        public int CarIdx { get; private set; }
        public int EntryIdx { get; private set; }
        public int ClubID { get; private set; }
        public bool CanScan { get; private set; }
        public bool CanSquawk { get; private set; }
        public bool Muted { get; private set; }
        public bool IsMutable { get; private set; }
        public bool IsDeletable { get; private set; }
    }
}
