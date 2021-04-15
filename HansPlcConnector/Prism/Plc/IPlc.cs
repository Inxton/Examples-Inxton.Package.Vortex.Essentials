namespace HansPlc
{
    public interface IPlc
    {
        IHansPlcTwinController Controller { get; }
    }
}