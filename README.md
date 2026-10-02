# Employee DevOps - .NET 8 Azure DevOps CI/CD Project

A complete sample .NET 8 Web API designed for Azure DevOps CI/CD practice.

## Stack
- .NET 8 Web API
- xUnit
- Docker
- Azure Container Registry
- AKS / Kubernetes
- Azure DevOps YAML pipelines
- Optional SonarQube, Terraform, Key Vault and Dynatrace extensions

## Local run
```powershell
dotnet restore
dotnet build
dotnet test
dotnet run --project EmployeeManagement.Api
```

Swagger: http://localhost:5000/swagger (actual port is shown by `dotnet run`)
Health: http://localhost:5000/health

## Docker
```powershell
docker build -t employee-api:1.0 .
docker run -d -p 8080:8080 --name employee-api employee-api:1.0
```

Swagger: http://localhost:8080/swagger
Health: http://localhost:8080/health

## Azure placeholders to change
Update these values in `azure-pipelines.yml` and `k8s/deployment.yaml`:
- `employeeacr2026.azurecr.io`
- `docker-acr`
- `aks-employee-service`

Do not commit passwords, tokens, client secrets, or connection strings. Use Azure DevOps service connections and/or Key Vault.

## Kubernetes
```powershell
kubectl apply -f k8s/
kubectl get pods
kubectl get svc
```

## CI/CD flow
Git push -> Restore -> Build -> Unit Test -> Docker Build/Push -> ACR -> AKS deployment.
