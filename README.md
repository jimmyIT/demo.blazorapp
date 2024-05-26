# Code Demo
To demo code structure, design pattern, ...

## 2023 - 12 - 22 
1.	Create code structure
	- Server: Source.Server.WebAPI
	- Client: Source.Client.BlazorServer
	- Core: Source.Server.Application, Source.Client.Application, Source.EF
	- Infrastructure: Source.Server.Infrastructure, Source.Client.Infrastructure, Source.Infrastructure.Shared
	- Shared: Source.Shared
	
2. Entity Framework - Code First
	- Add-Migration "Migration-Name"
	- Update-Database
	- Remove-Migration
Config source: If the database does not exist, it will migrate any pending migrations to Db, ensuring that the database schema matches the current mode

3. Apply Autofac to resolve all implementation classes
4. Apply Serilog to write log information/ error 
5. Apply API Versioning
6. Apply Repository Wrapper

## 2024 - 01 - 19 
1. Apply API Convention
2. Student's Controllers
3. Create a razor library project
4. Delete sample  Blazor Server's Weather Forcast
5. Blazor Server: Move default items into Shared
6. Blazor Server: Config MudBlazor
7. Blazor Server: Create student's pages
8. Blazor Server: Apply page layout and menu