FROM ubuntu:c27987afd3fd

RUN useradd −u 8877 nonroot
USER nonroot

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /
COPY ./ /

RUN dotnet restore "./src/CursoResidencia.Api/CursoResidencia.Api.csproj"
RUN dotnet build "./src/CursoResidencia.Api/CursoResidencia.Api.csproj"
RUN dotnet test "CursoResidencia.Api.sln"

FROM build AS publish
RUN dotnet publish "./src/CursoResidencia.Api/CursoResidencia.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CursoResidencia.Api.dll"]