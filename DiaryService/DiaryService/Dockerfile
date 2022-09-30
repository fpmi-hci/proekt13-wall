FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DiaryService/DiaryService.csproj", "DiaryService/"]
RUN dotnet restore "DiaryService/DiaryService.csproj"
COPY . .
WORKDIR "/src/DiaryService"
RUN dotnet build "DiaryService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiaryService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiaryService.dll"]
