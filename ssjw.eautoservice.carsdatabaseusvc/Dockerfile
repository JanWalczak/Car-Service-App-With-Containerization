#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.CarsDataUSvc.ConsoleApp/Ssjw.EAutoService.CarsDataUSvc.ConsoleApp.csproj", "Ssjw.EAutoService.CarsDataUSvc.ConsoleApp/"]
COPY ["Ssjw.EAutoService.CarsDataUSvc.Logic/Ssjw.EAutoService.CarsDataUSvc.Logic.csproj", "Ssjw.EAutoService.CarsDataUSvc.Logic/"]
COPY ["Ssjw.EAutoService.CarsDataUSvc.Model/Ssjw.EAutoService.CarsDataUSvc.Model.csproj", "Ssjw.EAutoService.CarsDataUSvc.Model/"]
COPY ["Ssjw.EAutoService.CarsDataUSvc.RestSvc/Ssjw.EAutoService.CarsDataUSvc.RestSvc.csproj", "Ssjw.EAutoService.CarsDataUSvc.RestSvc/"]
COPY ["Ssjw.EAutoService.CarsDataUSvc.RestClient/Ssjw.EAutoService.CarsDataUSvc.RestClient.csproj", "Ssjw.EAutoService.CarsDataUSvc.RestClient/"]
COPY ["Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel/"]







RUN dotnet restore Ssjw.EAutoService.CarsDataUSvc.RestSvc/Ssjw.EAutoService.CarsDataUSvc.RestSvc.csproj
COPY . .

RUN dotnet build "Ssjw.EAutoService.CarsDataUSvc.RestSvc/Ssjw.EAutoService.CarsDataUSvc.RestSvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.CarsDataUSvc.RestSvc/Ssjw.EAutoService.CarsDataUSvc.RestSvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.CarsDataUSvc.RestSvc.dll"]