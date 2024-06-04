FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
EXPOSE 8080
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR "/src/"
COPY ["*.sln", "."]
COPY ["WorkingTime.Application/WorkingTime.Application.csproj", "./WorkingTime.Application/"]
COPY ["WorkingTime.Domain/WorkingTime.Domain.csproj", "./WorkingTime.Domain/"]
COPY ["WorkingTime.Persistence/WorkingTime.Persistence.csproj", "./WorkingTime.Persistence/"]
COPY ["WorkingTime.WebAPI/WorkingTime.WebAPI.csproj", "./WorkingTime.WebAPI/"]
RUN dotnet restore "WorkingTime.WebAPI/WorkingTime.WebAPI.csproj"
COPY ["WorkingTime.Application/", "./WorkingTime.Application/"]
COPY ["WorkingTime.Domain/", "./WorkingTime.Domain/"]
COPY ["WorkingTime.Persistence/", "./WorkingTime.Persistence/"]
COPY ["WorkingTime.WebAPI/", "./WorkingTime.WebAPI/"]
RUN dotnet build "WorkingTime.WebAPI/WorkingTime.WebAPI.csproj" -c release -o /app/build --no-restore

FROM build as publish
RUN dotnet publish "WorkingTime.WebAPI/WorkingTime.WebAPI.csproj" -c release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish  .
ENTRYPOINT ["dotnet", "WorkingTime.WebAPI.dll"]
