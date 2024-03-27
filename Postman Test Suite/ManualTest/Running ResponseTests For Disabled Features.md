# Running the ResponseTests For Disabled Features Tests

Before running TestHarness, disable the following features in `appsettings.json`

```json
  "ApiSettings": {
    "Features": [
      {
        "Name": "ChangeQueries",
        "IsEnabled": false
      }
    ]
  }
```

Execute the test suite in the same way you execute the non-manual Postman tests.