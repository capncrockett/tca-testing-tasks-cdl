# ServiceModel Types

This directory contains shared Data Transfer Objects (DTOs) and type definitions used throughout the application. Following the [ServiceStack Physical Project Structure](https://docs.servicestack.net/physical-project-structure) convention, we maintain shared non-Request/Response DTOs in the `ServiceModel.Types` namespace.

## Purpose

- **Shared Types**: Define common data structures used across multiple services
- **Request/Response DTOs**: Define the contract for API endpoints
- **Type Safety**: Ensure consistent data structures between frontend and backend

## Structure

- **Requests/**: Contains Request DTOs (Input DTOs)
- **Responses/**: Contains Response DTOs (Output DTOs)
- **Enums/**: Shared enumerations
- **Interfaces/**: Shared interfaces
- **Models/**: Shared data models

## Naming Conventions

- **Request DTOs**: End with `Request` suffix (e.g., `GetUserRequest`)
- **Response DTOs**: End with `Response` suffix (e.g., `GetUserResponse`)
- **Models**: Use PascalCase without any special suffix (e.g., `UserProfile`)

## Example

```csharp
// Example Request DTO
[Route("/users/{Id}", "GET")]
public class GetUserRequest : IReturn<GetUserResponse>
{
    public int Id { get; set; }
}

// Example Response DTO
public class GetUserResponse
{
    public UserProfile Result { get; set; }
    public ResponseStatus ResponseStatus { get; set; }
}

// Example Model
public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```

## Related Documentation

- [ServiceStack DTOs](https://docs.servicestack.net/autoquery/rdbms#automatic-query-optimization)
- [Physical Project Structure](https://docs.servicestack.net/physical-project-structure)
- [API Design](https://docs.servicestack.net/api-design)
