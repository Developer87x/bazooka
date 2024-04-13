FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src

COPY "Bazooka.sln" "Bazooka.sln"
COPY "Services/Customers/Bazooka.Customers.Api/Bazooka.Customers.Api.csproj" "Services/Customers/Bazooka.Customers.Api/Bazooka.Customers.Api.csproj"
COPY "ApiGateways/ApiGateways.csproj" "ApiGateways/ApiGateways.csproj"
COPY "NuGet.config" "NuGet.config"
RUN dotnet restore "Bazooka.sln"

COPY . .
WORKDIR /src/Services/Customers/Bazooka.Customers.Api
RUN dotnet publish --no-restore -c Release -o /app

FROM build as publish

FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT [ "dotnet","Bazooka.Customers.Api.dll" ]