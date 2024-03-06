#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.EmployeesDataUSvc.ConsoleApp/Ssjw.EAutoService.EmployeesDataUSvc.ConsoleApp.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.ConsoleApp/"]
COPY ["Ssjw.EAutoService.EmployeesDataUSvc.Logic/Ssjw.EAutoService.EmployeesDataUSvc.Logic.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.Logic/"]
COPY ["Ssjw.EAutoService.EmployeesDataUSvc.Model/Ssjw.EAutoService.EmployeesDataUSvc.Model.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.Model/"]
COPY ["Ssjw.EAutoService.EmployeesDataUSvc.RestSvc/Ssjw.EAutoService.EmployeesDataUSvc.RestSvc.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.RestSvc/"]
COPY ["Ssjw.EAutoService.EmployeesDataUSvc.RestClient/Ssjw.EAutoService.EmployeesDataUSvc.RestClient.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.RestClient/"]
COPY ["Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel/"]



RUN dotnet restore Ssjw.EAutoService.EmployeesDataUSvc.RestSvc/Ssjw.EAutoService.EmployeesDataUSvc.RestSvc.csproj
COPY . .

RUN dotnet build "Ssjw.EAutoService.EmployeesDataUSvc.RestSvc/Ssjw.EAutoService.EmployeesDataUSvc.RestSvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.EmployeesDataUSvc.RestSvc/Ssjw.EAutoService.EmployeesDataUSvc.RestSvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.EmployeesDataUSvc.RestSvc.dll"]