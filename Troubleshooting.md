# Troubleshooting .NET 6 on Linux
For Omnisharp support in VS Code using .NET 6 (installed via apt), the following solved [these](https://github.com/OmniSharp/omnisharp-vscode/issues/2937) two [issues](https://github.com/dotnet/sdk/issues/17461).
- Add the following environment variables to `.bashrc`:
```
export MSBuildSDKsPath="/usr/share/dotnet/sdk/$(dotnet --version)/Sdks"
export MSBuildEnableWorkloadResolver=false
```
 
 # Current Working Version
 - VS Code, installed with the `code` package in the software center:
    - Channel: `latest/stable`
    - Version: `ccbaa2d2`
    - Source: `snapcraft.io` (not installed via snap, `~/snap/dotnet-sdk/` is empty
 - `which dotnet`: `/usr/bin/dotnet` 
 - `dotnet --info`:
 ```
 .NET SDK (reflecting any global.json):
 Version:   6.0.100
 Commit:    9e8b04bbff

Runtime Environment:
 OS Name:     ubuntu
 OS Version:  21.10
 OS Platform: Linux
 RID:         ubuntu.21.10-x64
 Base Path:   /usr/share/dotnet/sdk/6.0.100/

Host (useful for support):
  Version: 6.0.0
  Commit:  4822e3c3aa

.NET SDKs installed:
  6.0.100 [/usr/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 6.0.0 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 6.0.0 [/usr/share/dotnet/shared/Microsoft.NETCore.App]
 ```
