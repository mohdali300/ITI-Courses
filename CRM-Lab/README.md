# CompanySolution — Dynamics 365

A Dynamics 365 CRM solution built with Power Apps, including tables, model-driven app, workflows, form scripts, and charts.

---

## Solution Components

- **Tables:** Company, Employee, Payment
- **Model-Driven App:** CompanyApp
- **Workflows:** Assign And Send Email WF
- **Web Resources:** Company Form Scripts
- **Charts:** Company Statistics

---

## Prerequisites

- [PAC CLI](https://learn.microsoft.com/en-us/power-platform/developer/cli/introduction) installed:
  ```bash
  dotnet tool install --global Microsoft.PowerApps.CLI.Tool
  ```
- Access to the target Dynamics 365 environment

---

## Getting Started

### 1. Authenticate
```bash
pac auth create --url https://yourorg.crm.dynamics.com
```

### 2. Clone the repo
```bash
git clone https://github.com/mohdali300/ITI-Courses.git
cd ITI-Courses
```

### 3. Pack & Deploy
```powershell
cd CRM-Lab
./pack-and-deploy.ps1
```

This will pack the solution from `/src/CompanySolution` and import it into your environment.

---

## Contributing

1. Create a new branch: `git checkout -b feature/your-feature`
2. Make your changes in Power Apps
3. Export & unpack:
   ```bash
   pac solution export --name CompanySolution --path ./export --managed false
   pac solution unpack --zipfile ./export/CompanySolution.zip --folder ./src/CompanySolution
   ```
---
#### This is for educational purpose.
