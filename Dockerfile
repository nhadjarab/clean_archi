FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SalesReporterKata/SalesReporterKata.csproj", "SalesReporterKata/"]
RUN dotnet restore "SalesReporterKata/SalesReporterKata.csproj"
COPY . .
WORKDIR "/src/SalesReporterKata"
RUN dotnet build "SalesReporterKata.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalesReporterKata.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalesReporterKata.dll"]
