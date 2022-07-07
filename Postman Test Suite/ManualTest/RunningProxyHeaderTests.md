# Running the Proxy Header Tests

Before starting the ODS/API, set these values in `appsettings.development.json`:

```json
    "ApiSettings": {
        "UseReverseProxyHeaders": true,
        "DefaultForwardingHostServer": "chooseYourOwnAdventure",
        "DefaultForwardingHostPort": "54746"
    },
```

In your Postman environment, be sure setup the following variables (or change to
test in an environment other than localhost):

```json
ApiServer = localhost
ApiPort = 54746
ApiScheme = http
ApiBaseUrl = http://localhost:54746
ApiSettingsHost = chooseYourOwnAdventure:54746
```

