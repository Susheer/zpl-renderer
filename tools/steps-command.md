Create a console project
dotnet new console -n ZplRenderer.Test -o managed/ZplRenderer.Test

Reference the Core project
cd 

## To Build

 ### From the repository root:
 ```
dotnet build managed/ZplRenderer.Test/ZplRenderer.Test.csproj
dotnet build managed/ZplRenderer.Core/ZplRenderer.Core.csproj
```
or 

```
dotnet run --project managed\ZplRenderer.Test
```

### Run
```
    dotnet run --project managed/ZplRenderer.Test
    dotnet run --project managed/ZplRenderer.Test
```

Expected output
If everything is wired correctly, you should see something like:
Parsing...

{
  ...
}

## Release 
```
dotnet publish managed/ZplRenderer.Core/ZplRenderer.Core.csproj -c Release
```

### Verify the exports
dumpbin /exports managed\ZplRenderer.Core\bin\Release\net8.0\publish\ZplRenderer.Core.dll