FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


EXPOSE 5147 
ENV ASPNETCORE_URLS=http://*:5147
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY . .
RUN dotnet restore "Blazor.UI/Blazor.UI.csproj"
RUN dotnet build "Blazor.UI/Blazor.UI.csproj" -c $configuration -o /app/build

FROM build AS publish 
RUN dotnet publish "Blazor.UI/Blazor.UI.csproj" -c $configuration -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "Blazor.UI.dll" ]