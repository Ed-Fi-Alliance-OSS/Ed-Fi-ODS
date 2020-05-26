# EdFi.XmlLookup.Console Application
This utility is used to resolve lookup references in Ed-Fi XML interchange files against a working Ed-Fi ODS API endpoint.

## Processing Steps
1. XSD and API type information are loaded from disk disk or Url sources
2. Mappings are created between these sources for
  * XML Reference Lookup to ODS API GetByExample resources
  * ODS API Resources (from GetByExample result) to XML Reference Identity resources
3. Source XML files are loaded and scanned for all *unique* Reference Lookup elements
4. The Reference Lookup Elements attributes are converted into GetByExample names and types
5. GetByExample is called and valid results are stored (invalid results are logged)
6. The GetByExample results are converted into XML Reference Identity Elements
7. The Source XML files are copied to the output directory, inserting XML Reference Identity Elements next to their corresponding XML Reference Lookups
  * The *Output* directory contains the updated files
  * Comments in the updated files identify the inserted Reference Identity Elements

Typically, either Reference Lookup or Reference Identity types are supplied in a Reference, but both may exist. 
Reference Identities are never overwritten, if they are provided in the source XML files. 
If an identity is provided, it is assumed to be correct.

## Command Line arguments
The command line syntax may be retrieved by providing a /? --Help command line argument. The available command line arguments are:
| Short Argument | Long Argument | Purpose | Example |
| --- | --- |:--- | --- |
| -a | --apiurl | The ODS API Base Url | http://server/v3 |
| -y | --year | The target school year for the ODS API | 2016 |
| -k | --key | Your ODS API OAuth Key | |
| -s | --secret | Your ODS API OAuth Secret | |
| -o | --oauthurl | The Oauth Url | http://server/oauth |
| -d | --data | the path to the source XML files | c:\data |
| -w | --working | the path to where temporary working files are stored | |
| -x | --x | the path to where the Ed-Fi ODS XSD files are stored | |
| -m | --m | the Ed-Fi ODS metadata Url (not the swagger front-end website) | http://server/metadata |

## Configuration
The .config file located in the same directory as the executable may contain any of the command line arguments.

## Performance
The utility is extremely efficient:
* It identifies duplicate lookups, and resolves them to identities only once. 
* It performs as many GetByExample lookups in parallel as the client and server allow
* It does not load the entire source XML document into memory when reading the source files or writing the results

## Troubleshooting
The default configuration of the .config file writes error information to the console and to a rolling log file. 
Because only distinct lookups are submitted to the ODS API, there will only be one error message per identical lookup value if an error occurs.
Some interchanges may have mismapped attributes, causing consistent errors for a given lookup type. 
In this case, the code may need to be updated to accomodate this instance. 
See the Mapping classes and appropriate unit tests to work through these issues.

Ultimately, a single MetaEd mapping file should be generated and used to authoritatively map between the types instead of using a best-guess effort between the XSD and JSON attribute definitions.