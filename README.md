# .NET Learning Project

This project is a project I have been using to learn .NET. It is a simple API built with Clean Architecture principles in mind. This is not meant to be illustrative as I am still learning, so none of the implementation of this project should be considered best practice.

## Rationale

The project is built with the idea of good separation of concerns in mind. The project is split into multiple layers, each with its own responsibility. The layers are as follows:

- *Domain*: This layer contains the core business logic of the application. It is responsible for defining the entities, value objects, and domain services that make up the application.
- *Application*: This layer contains the application logic of the application. It is responsible for defining the use cases, commands, and queries that make up the application.
- *Infrastructure*: This layer contains the implementation details of the application. It is responsible for defining the data access, external services, and other infrastructure concerns of the application.
- *Presentation(API)*: This layer contains the presentation logic of the application. It is responsible for defining the controllers and other presentation concerns of the application.

Each layer owns its own data concerns and parts can be swapped out as needed. An intentional choice was made to allow duplicate model definition for each layer part so that parts can change independently of each other. When changing a part, only mappings need to be updated to reflect the changes.

## Running the Project

This project is built using .NET 10 and can be run using the .NET CLI or Visual Studio. To run the project using the .NET CLI, navigate to the root directory of the project and run the following commands:

```bash
# Restore the project
dotnet restore

# Start the PostgresDB
docker-compose up -d db

# Apply the database migrations
dotnet ef database update --project Tracker.Infrastructure --startup-project Tracker.Api --context TrackerDbContext -- --environment Development

# Run the project
dotnet run --project Tracker.Api
```

The project is also Dockerised and can be run completely in Docker. To do this, simply run:

```bash
docker-compose up -d --build
```
