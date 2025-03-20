# cosmosdb-nosql
Basic reference repo for helper classes and libraries focused on Azure CosmosDB NoSQL API


## Demonstrated Features
- Clean Architecture concept
- Generic class for core Cosmos DB Service usage in the project
- Create, Read, and Update operations for Cosmos DB

# Dependencies
- Docker Desktop
- Docker Compose V2
- Azure Cosmos DB Emulator - NoSQL - Windows Local installation

# Getting Started
1. Download the Cosmos DB Emulator
2. Run the solution


## Cosmos DB Emulator
Microsoft has a few options for using the Cosmos DB Eumlator, via a Docker Container or installed locally on Windows.  There a number of issues with the Docker Container, so I would not recommend that approach.

1. Follow instructions to install and setup the emulator [Cosmos DB Emulator Setup](https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=windows%2Ccsharp&pivots=api-nosql#import-the-emulators-tlsssl-certificate)

2. Start the emulator and navigate to [https://localhost:8081/_explorer/index.html](https://localhost:8081/_explorer/index.html)
```
https://localhost:8081/_explorer/index.html
```
> It can take several minutes for the emulator to startup and be ready via the localhost url

3. If needed, import the emulator's TLS/SSL certificate
> The local installation should include this


# Run the Solution
The easiest way to run this solution is to use docker compose as that will build the api project and provide containers for the data.  But there are other options as well.


## API Dockerfiles
There are 2 Dockerfiles present in the CosmosDb.NoSql.API project:
- Dockerfile
- Dockerfile_NoBuild

> Dockerfile is the initial setup default within the repository.

Each one demonstrates a different approach and potential use case.

### Dockerfile
Dockerfile is typically the default kind of file that Visual Studio auto generates with adding container support to a project.  
This example handles building the solution in a base image and then publishing the code to a runtime image.
This could be useful when wanting to debug and letting the docker runtime handle all of the work, or if you don't want to manually build and publish code before spinning up a new image and container.

### Dockerfile_NoBuild
This is a much smaller and much more simple docker file.  It requires published code to have already been produced to copy into the runtime image.
The Docker build and container spin up is much faster since it doesn't have to build the solution in the image itself.  
This scenario is useful in pipeline scenarios where the code may have already been built and published by prior tasks in a job.

To use this docker file in the solution, do the following:

1. In a command line, navigate to the directory containing the CosmosDb.NoSql.API.csproj
```
cd <path>\CosmosDb.NoSql.API
```

> Alter the path variable to match your local environment

2. Build the project either at the project or solution level
```
dotnet build
```

3. Publish the code into a directory using the Release configuration
```
dotnet publish CosmosDb.NoSql.API.csproj -c Release -o publish /p:UseAppHost=false
```

> This creates a new directory at `<path>\CosmosDb.NoSql.API\publish`

4. Update the docker-compose.yaml section for webapi.
    - Change the value of build.docker from CosmosDb.NoSql.API/Dockerfile to `CosmosDb.NoSql.API/Dockerfile_NoBuild`


## Docker Compose
1. Optional - build all containers in the compose yaml
```
docker compose build
```
> To build a specific container use `docker compose build <service-name>`

2. Compose up the containers
```
docker compose up
```
> If you do not want to debug, the add the -d parameter.  `docker compose up -d`
> docker compose up will also build all images if they do not exist, so step 1 is optional

3. Use an http client like Postman or the http files in Visual Studio to send requests to the API

4. Stop the containers when done with testing (or leave them running)
```
docker compose stop
```

> Use the start command to start the containers again
```
docker compose start
```

### Clean Up
Once containers are no longer needed you can remove them all using the compose down command
```
docker compose down
```

> Images can also be deleted using the compose down command
```
docker compose down --rmi "all"
```


# References
- [Azure CosmosDb Emulator](https://learn.microsoft.com/en-us/azure/cosmos-db/how-to-develop-emulator?tabs=windows%2Ccsharp&pivots=api-nosql)