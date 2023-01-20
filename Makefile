name = ""
migrate:
	dotnet ef migrations add $(name) --project src\Data\NASRAC.Persistence.Game --startup-project src\API\NASRAC.API.Game

update_db:
	dotnet ef database update --project src\Data\NASRAC.Persistence.Game --startup-project src\API\NASRAC.API.Game