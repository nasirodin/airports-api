FROM mcr.microsoft.com/dotnet/sdk:6.0  as build
WORKDIR /app
COPY /src .
RUN dotnet restore
RUN dotnet publish -c release -o published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/airport-api/bin/Release/net6.0/ /app
#COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "/app/airport-api.dll" ]