# Dream Roster Web API | ASP.NET Core 
[![.NET](https://img.shields.io/badge/.NET-6.0%2C%207.0%2C%208.0-512BD4)](https://docs.abblix.com/docs/technical-requirements)
[![language](https://img.shields.io/badge/language-C%23-239120)](https://learn.microsoft.com/ru-ru/dotnet/csharp/tour-of-csharp/overview)
[![getting started](https://img.shields.io/badge/getting_started-guide-1D76DB)](#using)

The Dream Roster is a **Web API** designed with a **3-layer architecture** to enable users to **build custom football rosters and manage existing leagues, teams, and players**. It provides **CRUD operations** on these entities, offering a reliable backend for management and customization. Let's dive a little deeper together 🚀





# Learn more about | Table of Contents
- [Project Overview](#project-overview)
  *  [Data Layer](#data-layer)
  *  [Business Layer](#business-layer)
  *  [Presentation Layer](#presentation-layer)
- [Using](#using)
- [Contact](#incoming_envelope-contact-information-incoming_envelope)

# Project Overview
<div>
	<code><img width="30" src="https://user-images.githubusercontent.com/25181517/192108372-f71d70ac-7ae6-4c0d-8395-51d8870c2ef0.png" alt="Git" title="Git"/></code>
	<code><img width="30" src="https://user-images.githubusercontent.com/25181517/121405384-444d7300-c95d-11eb-959f-913020d3bf90.png" alt="C#" title="C#"/></code>
	<code><img width="30" src="https://user-images.githubusercontent.com/25181517/121405754-b4f48f80-c95d-11eb-8893-fc325bde617f.png" alt=".NET Core" title=".NET Core"/></code>
	<code><img width="30" src="https://github.com/marwin1991/profile-technology-icons/assets/19180175/3b371807-db7c-45b4-8720-c0cfc901680a" alt="MSSQL" title="MSSQL"/></code>
 <code><img width="30" src="https://www.gencayyildiz.com/blog/wp-content/uploads/2019/08/ef-core.png" alt="MSSQL" title="Entity Framework Core"/></code>
</div>
<br>

Web API built with ASP.NET Core that allows users to create and manage custom football leagues, teams, and player rosters. 
Designed with a 3-layer architecture (Data, Business, and Presentation layers). 

Through the Dream Roster API, you can:
- Create and manage leagues, teams, and players.
- Customize player attributes and assign them to teams.
- Query and filter teams and players within leagues.
- The project includes user authentication to ensure secure access and modify permissions, and it supports soft deletes to maintain data integrity. With well-defined endpoints and clear documentation, the Dream Roster API is easy to integrate with -frontend applications for seamless roster-building functionality.

**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

________________________________________________________________________________________________________________________

## Data Layer

### Entities 

![Entity-diagram](https://github.com/user-attachments/assets/f64f3e04-fb45-4d67-84f9-32b84d3eb864)

### Repository Pattern

A generic (TEntity) and reusable data access layer for handling CRUD operations with the database. Built on the Repository Pattern, it abstracts and encapsulates data access logic, making it easier to work with data in a more organized way. Lets look more closer below ▼

**1. Generic Type TEntity:** The Repository class is generic, where TEntity represents any entity type that inherits from BaseEntity. This allows the same repository logic to handle different types of entities (such as Player, Team, League) without duplicating code.

**2. DreamRosterBuildingDbContext and DbSet:** The _context field represents the database context for Entity Framework Core operations, while _dbSet corresponds to the specific entity set, providing direct access to the database table for each entity type.

**3. CRUD Operations:**

- **Add:** Adds a new entity to the database. The method automatically sets `CreatedDate` and `ModifiedDate` before adding the entity.

- **Delete:** Supports soft delete by default, setting an entity’s `IsDeleted` flag to true and updating `ModifiedDate`. Hard delete is also an option, which removes the entity entirely.

- **DeleteById:** Finds and deletes an entity by its unique identifier, `id`.

- **Get:** Retrieves the first entity that matches a given condition (`linqQuery`) using `FirstOrDefault`.

- **GetAll:** Returns an `IQueryable` of entities, either all or filtered by a specified condition.  
  This approach enables Eager Loading by combining the query with related entities as needed.

- **GetById:** Finds an entity by its ID.

- **Update:** Updates an existing entity and sets the `ModifiedDate`.

- **Flexible Querying with IQueryable:** By using `IQueryable`, the repository can compose queries that are not immediately executed in the database.  
  This enables Eager Loading for related entities, as well as selective querying like filtering or projecting data before fetching it, which can optimize data retrieval and improve performance.

**4. Repository Pattern Benefits:**
Let me give explanation advantages of using repository pattern with 3 titles below.

Separation of Concerns: The repository abstracts away database operations, allowing the service layer to focus on business logic.

Testability: By isolating data access, it’s easier to create unit tests using mock repositories.

DRY Principle: Reduces redundancy by consolidating data access code, making it reusable across different parts of the application.


### UnitOfWork Pattern

Implements the Unit of Work pattern which is essential for managing database operations in an organized and transaction-safe manner. The primary goal of the Unit of Work pattern is to group multiple operations into a single transaction, allowing either all operations to succeed and in case of an error, to revert them all. This ensures data consistency and integrity. 

**1. IDbContextTransaction:** The _transaction field represents an EF Core transaction. Transactions ensure that a sequence of operations either completes fully or, if any operation fails, all changes are reverted. This is especially crucial when multiple changes to the database are made in a single workflow, as it maintains data consistency.

**2. Key Methods:**

- **BeginTransaction:** Initiates a database transaction using `BeginTransactionAsync`, allowing multiple operations to be committed as a single unit. This approach supports transaction handling in cases where multiple actions need to succeed or fail together.

- **CommitTransaction:** Commits the current transaction using `CommitAsync`. This ensures that all database changes within the transaction are saved.

- **RollBackTransaction:** Rolls back any changes made during the transaction if an error occurs. This reverts the database state to its original form before the transaction started, preserving data integrity.

- **SaveChangesAsync:** Saves changes made to the context asynchronously with `SaveChangesAsync`. It commits the modifications in a non-blocking manner, optimizing performance in asynchronous operations.

- **Dispose:** Disposes of the context, signaling to the .NET garbage collector to manage memory efficiently by freeing resources tied to the context.

**4. Unit of Work Benefits:**
Let me give explanation advantages of using Unit of Work pattern with 4 titles below.

Consistency Across Multiple Repositories: By coordinating multiple repositories within a single transaction, the Unit of Work ensures that changes across different entities are consistently applied or reverted.

Error Handling: Rolling back a transaction on error helps prevent partial updates that could lead to data inconsistencies.

Efficient Resource Management: The Dispose method helps manage resources efficiently by allowing the context to be disposed of correctly when no longer needed.

Simplified Commit/Rollback Logic: The Unit of Work pattern centralizes commit and rollback logic, simplifying transaction management across the application.

**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

________________________________________________________________________________________________________________________

## Business Layer

The Business Layer serves as the intermediary **between** the **Data Layer** and **Presentation Layer**, applying business logic and managing application-specific processes. It encapsulates the core functionality of the application, ensuring separation of concerns and a cleaner, more organized architecture.

### Operations

I managed services and managers according to each operations like Operations -> Team -> ITeamService, TeamManager.

### Service and Managers

- **Services:** Provide application logic and coordinate data flow between the repository and other components. Services handle actions such as creating, reading, updating, and deleting entities, ensuring validation and applying business rules as needed.

- **Managers:** Focus on domain-specific operations, organizing more complex or specific tasks that involve several entities or cross-cutting concerns (e.g., calculating player skills or team stats). This layer may call multiple services or repositories as part of its operations.

### Example Usage
In the context of this project:
  - **TeamService:** Manages team-related operations, such as creating a team, updating team information, or fetching teams with related players and league data.
  - **PlayerService:** Handles operations like adding players to a team, updating player stats, and retrieving players by different criteria.
  
### Dependency Injection

The Business Layer is registered for dependency injection, making it easy to configure and use across the application. This approach promotes modularity, testability, and a clear separation of concerns by allowing services to be injected where needed, without requiring direct instantiation.

**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

________________________________________________________________________________________________________________________

## Presentation Layer

The Presentation Layer is the API interface of the Dream Roster application. It exposes endpoints that allow clients to interact with the application, handling incoming requests, processing them, and returning responses. This layer communicates with the Business Layer to retrieve, modify, or delete data and applies security and request management features to ensure efficient and safe operations. With Controllers, Filters, Middleware, and JWT Authentication, ensures the Dream Roster API is secure, well-structured, and capable of handling complex client interactions efficiently.

### Controllers

Controllers serve as the entry point for client requests, defining **endpoints** that interact with different parts of the application. Each controller is responsible for handling HTTP requests for a specific entity, such as teams or players, by calling appropriate services within the Business Layer. Lets look into some of endpoints together.
 
 #### Endpoints
| URL           | Method | Description                       |
|---------------|--------|------
| /api/teams    | GET    |  Retrieve a list of teams         |
| /api/teams/{id} | GET |  Retrieve a specific team by ID   |
| /api/teams    | POST   |  Create a new team                |
| /api/teams/{id} | PUT  |  Update an existing team by ID    |
| /api/teams/{id} | DELETE |  Delete a team by ID              |
| /api/players    | GET    |  Retrieve a list of players         |
| /api/players/{id} | GET |  Retrieve a specific player by ID   |
| /api/players    | POST   |  Create a new player                |
| /api/players/{id} | PUT  |  Update an existing player by ID    |
| /api/players/{id} | DELETE |  Delete a player by ID              |

### Filters

**Filters** provide a way to handle cross-cutting concerns, such as validation, logging, and error handling, across multiple endpoints without duplicating code. Some commonly used filters include:
  - **Authorization Filters**: To verify user permissions for specific actions.
  - **Timecontrol Filters**: I created action filter in this project for time range of project works.

### Middleware

**Middleware** components process requests as they pass through the application pipeline. They manage tasks that must occur for all requests, such as:
  - **Maintenance**: I created maintenance middleware with controlling toggle-action on and off.
  - **Middleware Extension**: For using service like .Net default -> app.UseMaintenanceMode();

### JWT Authentication

**JWT (JSON Web Token)** Authentication secures the API by providing a stateless method of authentication. The Presentation Layer verifies the token on each request to ensure that users are authorized. Key aspects include:
  - **Token Generation**: Issuing JWT tokens after successful login, which contain user information and a timestamp.
  - **Token Validation**: Checking each incoming request for a valid token before granting access to secure endpoints.
  - **Role-Based Access**: Determining user access levels by decoding JWTs, allowing or restricting actions based on user roles.

**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

________________________________________________________________________________________________________________________

# Using

Lets look a example of using this web api on frontend below as video and fetch api samples with codes. You can use other actions with replacing url part. I used pure javascript below but I can advise search 'Axios' for fetching api operations.

https://github.com/user-attachments/assets/fe1f3517-a850-4d1c-a2ca-64f8709f0ea4

```javascript
// Example of getting teams
async function fetchTeams() { // Fetch is a asynchronous operation ( return promise ) in JavaScript so you need to use .then or async, await keyword approach.
  try {
    const response = await fetch('https://localhost:7084/api/teams', {
      method: 'GET',
      headers: {
        'Authorization': `Bearer YOUR_JWT_TOKEN`, // Replace with your JWT token
        'Content-Type': 'application/json'
      }
    });
    
    if (!response.ok) {
      throw new Error('Error at getting response ...');
    }

    const teams = await response.json();
    console.log(teams); // Display the list of teams
  } catch (error) {
    console.error('Error at fetching teams:', error);
  }
}

```

**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

________________________________________________________________________________________________________________________

# :incoming_envelope: Contact Information :incoming_envelope:

For any questions or further information, please don't hesitate to contact me :pray:

Email: merttopcu.dev@gmail.com

LinkedIn: https://www.linkedin.com/in/mert-topcu/

Happy Coding ❤️
   
     



