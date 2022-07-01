
namespace EdFi.Ods.Common.Configuration
{
    public class ReverseProxySettings
    {
        public bool UseReverseProxyHeaders { get; private set; }

        public string OverrideForForwardingHostServer { get; private set; }

        public int? OverrideForForwardingHostPort { get; private set; }

        public ReverseProxySettings(bool? useReverseProxyHeaders, string overrideForForwardingHostServer, int? overrideForForwardingHostPort)
        {
            this.UseReverseProxyHeaders = useReverseProxyHeaders ?? false;
            this.OverrideForForwardingHostPort = overrideForForwardingHostPort;
            this.OverrideForForwardingHostServer = overrideForForwardingHostServer;
        }
    }
}
