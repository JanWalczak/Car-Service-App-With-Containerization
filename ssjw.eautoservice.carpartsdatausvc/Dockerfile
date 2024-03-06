#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.CarPartsDataUSvc.ConsoleApp/Ssjw.EAutoService.CarPartsDataUSvc.ConsoleApp.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.ConsoleApp/"]
COPY ["Ssjw.EAutoService.CarPartsDataUSvc.Logic/Ssjw.EAutoService.CarPartsDataUSvc.Logic.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.Logic/"]
COPY ["Ssjw.EAutoService.CarPartsDataUSvc.Model/Ssjw.EAutoService.CarPartsDataUSvc.Model.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.Model/"]
COPY ["Ssjw.EAutoService.CarPartsDataUSvc.RestSVC/Ssjw.EAutoService.CarPartsDataUSvc.RestSVC.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.RestSVC/"]
COPY ["Ssjw.EAutoService.CarPartsDataUSvc.RestClient/Ssjw.EAutoService.CarPartsDataUSvc.RestClient.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.RestClient/"]
COPY ["Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel/Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.csproj", "Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel/"]







RUN dotnet restore Ssjw.EAutoService.CarPartsDataUSvc.RestSVC/Ssjw.EAutoService.CarPartsDataUSvc.RestSVC.csproj
COPY . .

RUN dotnet build "Ssjw.EAutoService.CarPartsDataUSvc.RestSVC/Ssjw.EAutoService.CarPartsDataUSvc.RestSVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.CarPartsDataUSvc.RestSVC/Ssjw.EAutoService.CarPartsDataUSvc.RestSVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.CarPartsDataUSvc.RestSVC.dll"]