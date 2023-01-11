name = ""
migrate:
	dotnet ef migrations add $(name) --project src\Data\NASRAC.Persistence.Game --startup-project src\API\NASRAC.API.Game