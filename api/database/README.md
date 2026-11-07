# Database setup

Two ways to get the `Plugg` database set up locally. Either works — pick whichever is easier for you.

## Option A — run the SQL script (no .NET tooling needed)

1. Open `schema.sql` in SQL Server Management Studio / Azure Data Studio, connected to your local SQL Server instance.
2. Create an empty database named `Plugg` (or let the script's `CREATE TABLE` statements run against whichever database you're connected to).
3. Run the whole script. It's idempotent — safe to re-run, it skips anything already applied.

## Option B — use EF Core migrations (if you have the `dotnet-ef` tool)

```
dotnet tool install --global dotnet-ef   # one-time, skip if already installed
dotnet ef database update --project src/Infrastructure --startup-project src/Api
```

This reads `src/Api/appsettings.json`'s `ConnectionStrings:DefaultConnection` and creates/updates the `Plugg` database to match the latest migration in `src/Infrastructure/Persistence/Migrations`.

## Connection string

Defaults to `Server=localhost\SQLEXPRESS;Database=Plugg;Trusted_Connection=True;TrustServerCertificate=True;` in `src/Api/appsettings.json` — edit that (or override via `appsettings.Development.json` / user secrets) if your local SQL Server instance name or auth differs.

## After the schema exists

There's no seed data yet — tables will be empty until products are added through the vendor side or a seed script is written.

Whenever a new EF Core migration is added, regenerate this script so it stays in sync:

```
dotnet ef migrations script --project src/Infrastructure --startup-project src/Api --idempotent -o database/schema.sql
```
