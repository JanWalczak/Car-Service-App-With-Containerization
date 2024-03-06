#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.ServicesDataUSvc.ConsoleApp/Ssjw.EAutoService.ServicesDataUSvc.ConsoleApp.csproj", "Ssjw.EAutoService.ServicesDataUSvc.ConsoleApp/"]
COPY ["Ssjw.EAutoService.ServicesDataUSvc.Logic/Ssjw.EAutoService.ServicesDataUSvc.Logic.csproj", "Ssjw.EAutoService.ServicesDataUSvc.Logic/"]
COPY ["Ssjw.EAutoService.ServicesDataUSvc.Model/Ssjw.EAutoService.ServicesDataUSvc.Model.csproj", "Ssjw.EAutoService.ServicesDataUSvc.Model/"]
COPY ["Ssjw.EAutoService.ServicesDataUSvc.RestSvc/Ssjw.EAutoService.ServicesDataUSvc.RestSvc.csproj", "Ssjw.EAutoService.ServicesDataUSvc.RestSvc/"]
COPY ["Ssjw.EAutoService.ServicesDataUSvc.RestClient/Ssjw.EAutoService.ServicesDataUSvc.RestClient.csproj", "Ssjw.EAutoService.ServicesDataUSvc.RestClient/"]
COPY ["Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel/"]



RUN dotnet restore Ssjw.EAutoService.ServicesDataUSvc.RestSvc/Ssjw.EAutoService.ServicesDataUSvc.RestSvc.csproj
COPY . .

RUN dotnet build "Ssjw.EAutoService.ServicesDataUSvc.RestSvc/Ssjw.EAutoService.ServicesDataUSvc.RestSvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.ServicesDataUSvc.RestSvc/Ssjw.EAutoService.ServicesDataUSvc.RestSvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.ServicesDataUSvc.RestSvc.dll"]