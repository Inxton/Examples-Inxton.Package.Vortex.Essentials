using Vortex.Adapters.Connector.Tc3.Adapter;

namespace HansPlc
{
    public class DevelopmentPlc : IPlc
    {

#if DEBUG
        const bool isDebug = true;
#else
        const bool isDebug = false;
#endif
        public DevelopmentPlc()
        {
            HansPlc = new HansPlcTwinController(Tc3ConnectorAdapter.Create("172.20.10.2.1.1", 851, isDebug)); ;
            HansPlc.Connector.BuildAndStart();
        }

        private HansPlcTwinController HansPlc { get; } 
        public IHansPlcTwinController Controller => HansPlc;
    }
}