#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.ClientsDataUSvc.ConsoleApp/Ssjw.EAutoService.ClientsDataUSvc.ConsoleApp.csproj", "Ssjw.EAutoService.ClientsDataUSvc.ConsoleApp/"]
COPY ["Ssjw.EAutoService.ClientsDataUSvc.Logic/Ssjw.EAutoService.ClientsDataUSvc.Logic.csproj", "Ssjw.EAutoService.ClientsDataUSvc.Logic/"]
COPY ["Ssjw.EAutoService.ClientsDataUSvc.Model/Ssjw.EAutoService.ClientsDataUSvc.Model.csproj", "Ssjw.EAutoService.ClientsDataUSvc.Model/"]
COPY ["Ssjw.EAutoService.ClientsDataUSvc.RestSvc/Ssjw.EAutoService.ClientsDataUSvc.RestSvc.csproj", "Ssjw.EAutoService.ClientsDataUSvc.RestSvc/"]
COPY ["Ssjw.EAutoService.ClientsDataUSvc.RestClient/Ssjw.EAutoService.ClientsDataUSvc.RESTClient.csproj", "Ssjw.EAutoService.ClientsDataUSvc.RestClient/"]
COPY ["Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel/"]



RUN dotnet restore Ssjw.EAutoService.ClientsDataUSvc.RestSvc/Ssjw.EAutoService.ClientsDataUSvc.RestSvc.csproj
COPY . .

RUN dotnet build "Ssjw.EAutoService.ClientsDataUSvc.RestSvc/Ssjw.EAutoService.ClientsDataUSvc.RestSvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.ClientsDataUSvc.RestSvc/Ssjw.EAutoService.ClientsDataUSvc.RestSvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.ClientsDataUSvc.RestSvc.dll"]