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
- [Contact](#contact)

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

## Business Layer
Operations -> Folder view and explanation
Service and Managers -> Folder view and explanation

**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

## Presentation Layer
Controllers
Filters
Middlewares
Jwt

### Endpoints
| URL           | Method | Auth | Description                       |
|---------------|--------|------|-----------------------------------|
| /api/teams    | GET    | Yes  | Retrieve a list of teams         |
| /api/teams/{id} | GET | Yes  | Retrieve a specific team by ID   |
| /api/teams    | POST   | Yes  | Create a new team                |
| /api/teams/{id} | PUT  | Yes  | Update an existing team by ID    |
| /api/teams/{id} | DELETE | Yes | Delete a team by ID              |


**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

# Using
JS samples, frontend view

**[⬆ Back to Table of Contents](#learn-more-about--table-of-contents)**

# Contact
Contact info etc.

Happy Coding ❤️
   
     



