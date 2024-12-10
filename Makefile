name = ""
migrate:
	dotnet ef migrations add $(name) --project src/Data --startup-project src/API

update:
	dotnet ef database update --project src/Data --startup-project src/API