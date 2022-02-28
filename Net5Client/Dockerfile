FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Net5Client/Net5Client.csproj", "Net5Client/"]
RUN dotnet restore "Net5Client/Net5Client.csproj"
COPY . .
WORKDIR "/src/Net5Client"
RUN dotnet build "Net5Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net5Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net5Client.dll"]
