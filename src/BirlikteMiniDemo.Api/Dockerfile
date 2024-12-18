FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/BirlikteMiniDemo.Api/BirlikteMiniDemo.Api.csproj", "src/BirlikteMiniDemo.Api/"]
COPY ["src/BirlikteMiniDemo.Application/BirlikteMiniDemo.Application.csproj", "src/BirlikteMiniDemo.Application/"]
COPY ["src/BirlikteMiniDemo.Domain/BirlikteMiniDemo.Domain.csproj", "src/BirlikteMiniDemo.Domain/"]
COPY ["src/BirlikteMiniDemo.Infrastructure/BirlikteMiniDemo.Infrastructure.csproj", "src/BirlikteMiniDemo.Infrastructure/"]
COPY ["src/BirlikteMiniDemo.Persistence/BirlikteMiniDemo.Persistence.csproj", "src/BirlikteMiniDemo.Persistence/"]
RUN dotnet restore "src/BirlikteMiniDemo.Api/BirlikteMiniDemo.Api.csproj"

COPY . .
WORKDIR "/src/src/BirlikteMiniDemo.Api"
RUN dotnet build "BirlikteMiniDemo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BirlikteMiniDemo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BirlikteMiniDemo.Api.dll"]
