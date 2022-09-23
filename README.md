# Airports API
.net6 web-api project, aimed to demonstrate the skills of building scalable and resilient services

## Build
To build project and run unit tests use the flowing commands

```
dotnet build
dotnet test
```

## Run Project
To run project and call API use the following commands
````
docker compose up
curl "http://localhost:8080/Airport?source=AMS&destination=IKA"
````
