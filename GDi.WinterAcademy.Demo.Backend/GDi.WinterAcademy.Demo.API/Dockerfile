#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GDi.WinterAcademy.Demo.API/GDi.WinterAcademy.Demo.API.csproj", "GDi.WinterAcademy.Demo.API/"]
RUN dotnet restore "GDi.WinterAcademy.Demo.API/GDi.WinterAcademy.Demo.API.csproj"
COPY . .
WORKDIR "/src/GDi.WinterAcademy.Demo.API"
RUN dotnet build "GDi.WinterAcademy.Demo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GDi.WinterAcademy.Demo.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GDi.WinterAcademy.Demo.API.dll"]