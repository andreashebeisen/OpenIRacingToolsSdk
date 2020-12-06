namespace OpenIRacingTools.Sdk.Model.Types
{
    public struct Temperature
    {
        public Temperature(double celcius)
        {
            Celcius = celcius;
        }

        public double Celcius { get; private set; }
    }
}
