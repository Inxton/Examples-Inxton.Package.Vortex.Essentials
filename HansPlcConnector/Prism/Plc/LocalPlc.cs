using Vortex.Adapters.Connector.Tc3.Adapter;

namespace HansPlc
{
    public class LocalPlc : IPlc
    {
#if DEBUG
        const bool isDebug = true;
#else
        const bool isDebug = false;
#endif
        public LocalPlc()
        {
            HansPlc = new HansPlcTwinController(Tc3ConnectorAdapter.Create(null, 851, isDebug)); ;
            HansPlc.Connector.BuildAndStart();
        }
        private HansPlcTwinController HansPlc { get; }
        public IHansPlcTwinController Controller => HansPlc;
    }
}
