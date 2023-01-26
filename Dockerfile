# escape=`
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8.1 AS builder

WORKDIR C:\src
ADD . .

RUN nuget restore WebApplication4.sln 
COPY WebApplication4\* C:\src\
RUN msbuild WebApplication4\WebApplication4.csproj /p:OutputPath=c:\Test /p:Configuration=Release

# app image
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8.1
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';"]

ENV APP_ROOT=C:\inetpub\wwwroot

WORKDIR ${APP_ROOT}
RUN New-WebApplication -Name 'app' -Site 'Default Web Site' -PhysicalPath $env:APP_ROOT

COPY --from=builder C:\Test\_PublishedWebsites\WebApplication4 ${APP_ROOT}