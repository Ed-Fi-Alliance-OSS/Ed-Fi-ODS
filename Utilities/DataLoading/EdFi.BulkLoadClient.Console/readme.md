# Command Line Switches

| Short Option |   Long Option    | Description                                                                                               |
|:------------:|:----------------:|:----------------------------------------------------------------------------------------------------------|
|      a       |      apiurl      | The web API URL (e.g., http://server/data/v3)                                                             |
|      c       | connectionlimit  | Maximum concurrent connections to api                                                                     |
|      d       |       data       | Path to folder containing the data files to be submitted                                                  |
|      f       |      force       | Force reload of metadata from metadata url                                                                |
|      i       | interchangeorder | Path to a folder containing the Ed-Fi ODS / API Interchange Order metadata files                          |
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

## Sample for running the SampleXML files
-a "http://localhost:54746/data/v3/" -r 1 -d "C:\Projects\Certica\Ed-Fi-Standard\v3.1\Samples\Sample XML" -m "http://localhost:54746/metadata" -o "http://localhost:54746"  -w "C:\temp\data\Output" -x "C:\Projects\Certica\Ed-Fi-Standard\v3.1\Schemas\Bulk" -t 50 -n -c 5 -k populatedSandbox -s populatedSandboxSecret
