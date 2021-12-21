namespace AdventInfi.Types
{
    public class waarheid
    {
        public static waarheid WAAR = new waarheid(true);
        public static waarheid ONWAAR = new waarheid(false);

        private bool _waarheid;
        private waarheid(bool waarheid) => _waarheid = waarheid;

        public static bool operator ==(waarheid eerste, waarheid tweede) => eerste._waarheid == tweede._waarheid;
        public static bool operator !=(waarheid eerste, waarheid tweede) => eerste._waarheid != tweede._waarheid;

        public static implicit operator bool(waarheid waarheid) => waarheid._waarheid;

        public override int GetHashCode() => _waarheid ? 1 : 0;
        public override bool Equals(object obj) => ReferenceEquals(this, obj);
        public override string ToString() => _waarheid ? "waar" : "onwaar";
    }
}
