win-x64:
  dotnet publish -c Release -r win10-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeAllContentForSelfExtract=true -p:PublishTrimmed=True -p:TrimMode=CopyUsed
