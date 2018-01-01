# oracleClientCore-Sample
Small app for test .Net Core Oracle client.
Based on [ericmend](https://github.com/ericmend)  [oracleClientCore-2.0](https://github.com/ericmend/oracleClientCore-2.0) library
([Nuget](https://www.nuget.org/packages/dotNetCore.Data.OracleClient))



### Requrements

* [Install .NET Core SDK 2.0](https://www.microsoft.com/net/download/core)
* [Install OCI - Client Oracle](http://www.oracle.com/technetwork/database/features/instant-client/index-097480.html) or full Oracle client.

* (linux) Unzip the files and declare the environment variables. eg: LD_LIBRARY_PATH="/opt/oracle/instantclient"; 
  OCI_HOME="/opt/oracle/instantclient"; OCI_LIB_DIR="/opt/oracle/instantclient"; PATH=$PATH:"/opt/oracle/instantclient"
* (windows) Unzip the files and declare the environment variables. eg: LD_LIBRARY_PATH="C:\instantclient_12_2\"; 
  OCI_HOME="C:\instantclient_12_2\"; OCI_LIB_DIR="C:\instantclient_12_2\"; PATH=%PATH%;"C:\instantclient_12_2\"
*  Set NLS_LANG settings, if it is not setteted correctly eg: in windows: SET NLS_LANG=SLOVAK_SLOVAKIA.EE8MSWIN1250 ( or set registry key), in Linux you can use: export NLS_LANG=SLOVAK_SLOVAKIA.UTF8 . 
More resources: [NLS_LANG FAQ](http://www.oracle.com/technetwork/database/database-technologies/globalization/nls-lang-099431.html#_Toc110410555)


### Note:

Work has been done to work on Windows / Linux / MacOsX. Tested so far only Windows (Win10) and Linux (Ubuntu 17.10, CentOS 7).
