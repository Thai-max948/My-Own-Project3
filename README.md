# RepFlow

RepFlow is a 30-day workout journey application. This repository currently contains architecture scaffolding only; product features have not been implemented.

## Repository structure

```text
frontend/                         React, TypeScript, Tailwind CSS
backend/RepFlow.Api/              HTTP entry point and future controllers
backend/RepFlow.Application/      Future services and use-case logic
backend/RepFlow.Domain/           Core domain model
backend/RepFlow.Infrastructure/   Future EF Core and external integrations
tests/RepFlow.Application.Tests/  xUnit tests for application services
```

Dependencies flow inward:

```text
Api -> Application -> Domain
Api -> Infrastructure -> Application + Domain
Tests -> Application + Domain
```

## Prerequisites

- .NET SDK 10
- A Node.js version supported by Vite 8, with npm

## Run locally

Backend:

```powershell
dotnet restore RepFlow.slnx
dotnet run --project backend/RepFlow.Api
```

Frontend:

```powershell
cd frontend
npm install
npm run dev
```

## Verify

```powershell
dotnet build RepFlow.slnx
dotnet test RepFlow.slnx --no-build
```

```powershell
cd frontend
npm run build
```

