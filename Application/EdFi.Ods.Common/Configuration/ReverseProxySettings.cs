using System;

namespace EdFi.Ods.Common.Configuration
{
    public class ReverseProxySettings
    {
        const string ForwardingConfigurationError = "UseReverseProxyHeaders has been set, but there is no appsettings value for one or both of DefaultForwardingHostServer and DefaultForwardingHostPort. Set these and re-run the application";

        public bool UseReverseProxyHeaders { get; private set; }

        public string DefaultForwardingHostServer { get; private set; }

        public int DefaultForwardingHostPort { get; private set; }

        public ReverseProxySettings(bool? useReverseProxyHeaders, string defaultForwardingHostServer, int? defaultForwardingHostPort)
        {
            if (useReverseProxyHeaders.HasValue
                && useReverseProxyHeaders.Value
                && (string.IsNullOrWhiteSpace(defaultForwardingHostServer)
                    || !defaultForwardingHostPort.HasValue)
                )
            {
                throw new ArgumentException(ForwardingConfigurationError);
            }

            // Setting default values that should never be used, so that the properties do not need to be nullabe.
            this.UseReverseProxyHeaders = useReverseProxyHeaders ?? false;
            this.DefaultForwardingHostPort = defaultForwardingHostPort ?? 0;
            this.DefaultForwardingHostServer = defaultForwardingHostServer;
        }

    }
}
