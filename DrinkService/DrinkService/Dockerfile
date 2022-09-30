FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DrinkService/DrinkService.csproj", "DrinkService/"]
RUN dotnet restore "DrinkService/DrinkService.csproj"
COPY . .
WORKDIR "/src/DrinkService"
RUN dotnet build "DrinkService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DrinkService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrinkService.dll"]
