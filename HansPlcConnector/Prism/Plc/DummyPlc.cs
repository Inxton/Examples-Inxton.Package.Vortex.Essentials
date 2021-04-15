using Vortex.Connector;

namespace HansPlc
{
    public class DummyPlc : IPlc
    {
        public IHansPlcTwinController Controller => new HansPlcTwinController(new ConnectorAdapter(typeof(DummyConnectorFactory)));
    }
}
