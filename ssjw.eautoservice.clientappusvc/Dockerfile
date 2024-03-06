#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.ClientAppUSvc.ConsoleApp/Ssjw.EAutoService.ClientAppUSvc.ConsoleApp.csproj", "Ssjw.EAutoService.ClientAppUSvc.ConsoleApp/"]
COPY ["Ssjw.EAutoService.ClientAppUSvc.Logic/Ssjw.EAutoService.ClientAppUSvc.Logic.csproj", "Ssjw.EAutoService.ClientAppUSvc.Logic/"]
COPY ["Ssjw.EAutoService.ClientAppUSvc.Model/Ssjw.EAutoService.ClientAppUSvc.Model.csproj", "Ssjw.EAutoService.ClientAppUSvc.Model/"]
COPY ["Ssjw.EAutoService.ClientAppUSvc.RestSvc/Ssjw.EAutoService.ClientAppUSvc.RestSvc.csproj", "Ssjw.EAutoService.ClientAppUSvc.RestSvc/"]
COPY ["Ssjw.EAutoService.ClientAppUSvc.RestClient/Ssjw.EAutoService.ClientAppUSvc.RestClient.csproj", "Ssjw.EAutoService.ClientAppUSvc.RestClient/"]
COPY ["Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel/Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel/"]



COPY ["RestConnection/Ssjw.EAutoService.CarPartsDataUSvc.RestClient/Ssjw.EAutoService.CarPartsDataUSvc.RestClient.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.RestClient/"]
COPY ["RestConnection/Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel/"]

COPY ["RestConnection/Ssjw.EAutoService.CarsDataUSvc.RestClient/Ssjw.EAutoService.CarsDataUSvc.RestClient.csproj", "Ssjw.EAutoService.CarsDataUSvc.RestClient/"]
COPY ["RestConnection/Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel/"]

COPY ["RestConnection/Ssjw.EAutoService.ClientsDataUSvc.RestClient/Ssjw.EAutoService.ClientsDataUSvc.RestClient.csproj", "Ssjw.EAutoService.ClientsDataUSvc.RestClient/"]
COPY ["RestConnection/Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel/"]

COPY ["RestConnection/Ssjw.EAutoService.EmployeesDataUSvc.RestClient/Ssjw.EAutoService.EmployeesDataUSvc.RestClient.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.RestClient/"]
COPY ["RestConnection/Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel/"]

COPY ["RestConnection/Ssjw.EAutoService.ServicesDataUSvc.RestClient/Ssjw.EAutoService.ServicesDataUSvc.RestClient.csproj", "Ssjw.EAutoService.ServicesDataUSvc.RestClient/"]
COPY ["RestConnection/Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel/"]




RUN dotnet restore Ssjw.EAutoService.ClientAppUSvc.RestSvc/Ssjw.EAutoService.ClientAppUSvc.RestSvc.csproj
COPY . .

RUN dotnet build "Ssjw.EAutoService.ClientAppUSvc.RestSvc/Ssjw.EAutoService.ClientAppUSvc.RestSvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.ClientAppUSvc.RestSvc/Ssjw.EAutoService.ClientAppUSvc.RestSvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.ClientAppUSvc.RestSvc.dll"]