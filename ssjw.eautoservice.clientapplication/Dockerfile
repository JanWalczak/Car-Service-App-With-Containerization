#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.WebClientApplication.BlazorServer/Ssjw.EAutoService.WebClientApplication.BlazorServer.csproj", "Ssjw.EAutoService.WebClientApplication.BlazorServer/"]
COPY ["Ssjw.EAutoService.ClientApplication.Controller/Ssjw.EAutoService.ClientApplication.Controller.csproj", "Ssjw.EAutoService.ClientApplication.Controller/"]
COPY ["Ssjw.EAutoService.ClientApplication.Utilities/Ssjw.EAutoService.ClientApplication.Utilities.csproj", "Ssjw.EAutoService.ClientApplication.Utilities/"]
COPY ["Ssjw.EAutoService.ClientApplication.Model/Ssjw.EAutoService.ClientApplication.Model.csproj", "Ssjw.EAutoService.ClientApplication.Model/"]
COPY ["Ssjw.EAutoService.ClientApplication.Tests/Ssjw.EAutoService.ClientApplication.Tests.csproj", "Ssjw.EAutoService.ClientApplication.Tests/"]
COPY ["Ssjw.EAutoService.ClientAppUSvc.RestClient/Ssjw.EAutoService.ClientAppUSvc.RestClient.csproj", "Ssjw.EAutoService.ClientAppUSvc.RestClient/"]
COPY ["Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel/Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel/"]


RUN dotnet restore Ssjw.EAutoService.WebClientApplication.BlazorServer/Ssjw.EAutoService.WebClientApplication.BlazorServer.csproj
COPY . .

RUN dotnet build "Ssjw.EAutoService.WebClientApplication.BlazorServer/Ssjw.EAutoService.WebClientApplication.BlazorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.WebClientApplication.BlazorServer/Ssjw.EAutoService.WebClientApplication.BlazorServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.WebClientApplication.BlazorServer.dll"]