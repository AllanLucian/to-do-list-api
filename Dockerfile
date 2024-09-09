FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
# COPY to-do-list-api/*.csproj .
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /runtime-app
COPY --from=build-env /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "to-do-list-api.dll"]