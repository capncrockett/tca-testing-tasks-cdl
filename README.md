# TCA Testing Tasks

A Vue.js and .NET 8.0 application for managing testing tasks.

A repository rehosted from https://github.com/NetCoreTemplates/vue-spa used as a Vue and .Net template for AI Code Assistant

## Getting Started with Visual Studio

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (Community edition or higher)
  - Select these workloads during installation:
    - ASP.NET and web development
    - .NET desktop development
    - Node.js development (or install [Node.js LTS](https://nodejs.org/) separately)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Git](https://git-scm.com/)

### Setup Instructions

1. **Clone the repository**

   - Open Visual Studio
   - Click "Clone a repository"
   - Enter the repository URL: `https://github.com/your-username/tca-testing-tasks.git`
   - Choose a local path and click "Clone"

2. **Restore .NET dependencies**

   - Open the solution file (`tca-testing-tasks.sln`)
   - Right-click the solution in Solution Explorer
   - Select "Restore NuGet Packages"

3. **Install Node.js dependencies**

   - Open a terminal in Visual Studio (View > Terminal)
   - Navigate to the ClientApp directory:
     ```
     cd ClientApp
     ```
   - Install npm packages:
     ```
     npm install
     ```

4. **Configure the application**

   - In the `appsettings.json` file, update any connection strings or settings as needed

5. **Run the application**
   - In Visual Studio, ensure the startup project is set to the web project
   - Press F5 or click the "Start" button to run the application
   - This will:
     1. Start the .NET backend
     2. Launch the Vue.js development server
     3. Open your default browser to `https://localhost:5001`

### Development Workflow

- **Frontend Development**:

  - Work with Vue components in the `ClientApp/src` directory
  - The development server supports hot-reload for instant feedback

- **Backend Development**:
  - Controllers and services are in the `.Server` project
  - API endpoints are automatically reloaded when you make changes

### Building for Production

To create a production build:

1. In Visual Studio:

   - Right-click the solution
   - Select "Publish..."
   - Choose your publishing target (Azure, Folder, etc.)
   - Follow the wizard to complete the publish process

2. Or from the command line:
   ```
   cd ClientApp
   npm run build
   dotnet publish -c Release
   ```

---

## Original Template Information

This project was created using the vue-spa template:

# vue-spa

.NET 8.0 vue-spa Pages Tailwind Website

[![](https://raw.githubusercontent.com/ServiceStack/Assets/master/csharp-templates/vue-spa.png)](http://vue-spa.web-templates.io)

> Browse [source code](https://github.com/NetCoreTemplates/vue-spa), view live demo [vue-spa.web-templates.io](http://vue-spa.web-templates.io) and install with [dotnet-new](https://docs.servicestack.net/dotnet-new):

    $ dotnet tool install -g x
    $ x new vue-spa ProjectName

Alternatively write new project files directly into an empty repository, using the Directory Name as the ProjectName:

    $ git clone https://github.com/<User>/<ProjectName>.git
    $ cd <ProjectName>
    $ x new vue-spa
