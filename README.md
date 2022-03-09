## Basic Kanban board App

A .NET Core console app for demonstrating basic programming techniques by building a Kanban board app.
	

## Code Logic

* I created a class ClientRepository with methods SaveClient, GetClients, RemoveClientByName, to allow separation of concerns.
* I updated class TaskRepository to include method PerformOrderingonTasks and updated method GetTasks to include ClientName property while initializing the object of Task among other updates.
* I updated class TaskEngine's methods such as SaveTask, RetrieveTaskById, SaveClient, GetClients and PerformReOrderingOnTasks.
    
    
## Technologies

Project uses:
* .Net Core 3.1 console
* Linq


## Setup

To run this project, 
* Install .NET Core 3.1 locally
* Clone/download the project and launch locally using visual studio code or visual studio
* Open terminal on the project directory and run **dotnet run** or run debug using the IDE.
