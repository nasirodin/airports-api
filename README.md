# Airports API
.net6 web-api project, aimed to demonstrate the skills of building scalable and resilient services

## Build
You can run unit tests and build the project by using the following commands


```
dotnet build
dotnet test
```

## Run Project
Use the following commands to run the project and call the API
````
docker compose up
curl "http://localhost:8080/Airport?source=AMS&destination=IKA"
````
