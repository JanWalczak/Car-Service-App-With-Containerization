#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ssjw.EAutoService.WebMechanicApp.BlazorServer/Ssjw.EAutoService.WebMechanicApp.BlazorServer.csproj", "Ssjw.EAutoService.WebMechanicApp.BlazorServer/"]
COPY ["Ssjw.EAutoService.MechanicApplication.Controller/Ssjw.EAutoService.MechanicApplication.Controller.csproj", "Ssjw.EAutoService.MechanicApplication.Controller/"]
COPY ["Ssjw.EAutoService.MechanicApplication.Utilities/Ssjw.EAutoService.MechanicApplication.Utilities.csproj", "Ssjw.EAutoService.MechanicApplication.Utilities/"]
COPY ["Ssjw.EAutoService.MechanicApplication.Model/Ssjw.EAutoService.MechanicApplication.Model.csproj", "Ssjw.EAutoService.MechanicApplication.Model/"]
COPY ["Ssjw.EAutoService.MechanicApplication.Tests/Ssjw.EAutoService.MechanicApplication.Tests.csproj", "Ssjw.EAutoService.MechanicApplication.Tests/"]
RUN dotnet restore "Ssjw.EAutoService.WebMechanicApp.BlazorServer/Ssjw.EAutoService.WebMechanicApp.BlazorServer.csproj"
COPY . .
WORKDIR "/src/Ssjw.EAutoService.WebMechanicApp.BlazorServer"
RUN dotnet build "Ssjw.EAutoService.WebMechanicApp.BlazorServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ssjw.EAutoService.WebMechanicApp.BlazorServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ssjw.EAutoService.WebMechanicApp.BlazorServer.dll"]