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
Content of the dlayer
Entities and Relations -> Picture
Repositories -> Tell logic of repositories
UnitOfWork -> Tell logic of UnitOfWork

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
   
     



