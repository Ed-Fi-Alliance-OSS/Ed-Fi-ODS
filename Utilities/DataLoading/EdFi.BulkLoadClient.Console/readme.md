# Command Line Switches

| Short Option |   Long Option    | Description                                                                                               |
|:------------:|:----------------:|:----------------------------------------------------------------------------------------------------------|
|      b       |      base        | The base web API URL (e.g., http://server) **_REQUIRED_**                                               |
|      a       |      apiurl      | The web API URL (e.g., http://server/data/v3)                                                             |
|      c       | connectionlimit  | Maximum concurrent connections to api                                                                     |
|      d       |       data       | Path to folder containing the data files to be submitted                                                  |
|      f       |      force       | Force reload of metadata from metadata url                                                                |
|      k       |       key        | The web API OAuth key                                                                                     |
|      l       |   maxRequests    | Max number of simultaneous API requests                                                                   |
|      m       |   metadataurl    | The metadata URL (e.g., http://server/metadata)                                                           |
|      n       |   novalidation   | No argument. Do not validate the XML document against the XSD before processing                           |
|      o       |     oauthurl     | The OAuth URL (e.g., http://server/oauth); the default OAuth URL for the ODS / API is http://server/oauth |
|      p       |     profile      | The name of an API profile to use (optional)                                                              |
|      r       |     retries      | The number of times to retry submitting a resource                                                        |
|      s       |      secret      | The web API OAuth secret                                                                                  |
|      t       |   taskcapacity   | Maximum concurrent tasks to be buffered                                                                   |
|      w       |     working      | Path to a writable folder containing the working files, such as the swagger metadata cache and hash cache |
|      x       |       xsd        | Path to a folder containing the Ed-Fi Data Standard XSD Schema files                                      |
|      y       |       year       | The target school year for the web API (e.g., 2018)                                                       |

## New for 5.2.0
* Passing in the base url to the Ods/Api is now required.
* The application will use the base url and determine the endpoints for ApiUrl, MetadataUrl, and OAuthUrl. 
* Settings can be set in the appsettings.json and/or passed in by command line arguments. Command line arguments will override any settings in the appsettings.json.

## Sample for running the SampleXML files
-b "http://localhost:54746" -r 1 -d "c:/Ed-Fi-Standard/Samples/Sample XML" -w "C:/temp/data/Output" -x "C:/Ed-Fi-Standard/Schemas/Bulk" -k populatedSandbox -s populatedSandboxSecret
