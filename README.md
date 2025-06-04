# TCA Testing Tasks

A Vue.js and .NET 8.0 application for managing testing tasks.

A repository rehosted from [vue-spa](https://github.com/NetCoreTemplates/vue-spa) used as a Vue and .NET template for AI Code Assistant.

## Development Setup

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (LTS version recommended)
- For Windows:
  - [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with ASP.NET and web development workload
  - SQL Server LocalDB (included with Visual Studio)
- For Mac/Linux:
  - [Visual Studio Code](https://code.visualstudio.com/) or your preferred IDE
  - SQLite (included with most systems)

### Getting Started

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-org/tca-testing-tasks.git
   cd tca-testing-tasks
   ```

2. **Install frontend dependencies**

   ```bash
   cd ClientApp
   npm install
   cd ..
   ```

3. **Run the application**
   ```bash
   dotnet watch
   ```
   This will:
   - Start the .NET backend with hot reload
   - Start the Vite dev server for the frontend
   - Open the app in your default browser

### Database Setup

The application uses two database systems:

1. **Application Data (OrmLite with SQLite)**

   - Used for: Bookings, Coupons, etc.
   - Automatically created at `App_Data/app.db`
   - No setup required

2. **Authentication (EF Core)**
   - **Windows**: Uses SQL Server LocalDB (included with Visual Studio)
   - **Mac/Linux**: Uses SQLite (no setup required)

#### First Run

On first run, the application will:

1. Create the databases if they don't exist
2. Run all necessary migrations
3. Seed sample data including:
   - Test users (admin@email.com / p@55wOrd)
   - Sample bookings
   - Coupon codes (5% to 70% off)

### Accessing the Admin UI

1. Navigate to `/admin-ui/database` in your browser
2. Log in with admin credentials:
   - Email: `admin@email.com`
   - Password: `p@55wOrd`

### Development Workflow

- **Frontend**: The Vite dev server runs on `https://localhost:5173` with hot module replacement
- **Backend**: The .NET API runs on `https://localhost:5001` (or similar)
- **API Explorer**: Available at `/swagger`

### Troubleshooting

1. **Database Issues**

   - **Windows**: Ensure SQL Server LocalDB is installed (comes with Visual Studio)
   - **Mac/Linux**: Ensure write permissions to the `App_Data` directory

2. **Reset the Database**

   - **Windows**:
     - Delete the database using SQL Server Management Studio or run `sqllocaldb delete MSSQLLocalDB`
     - Delete `App_Data/app.db`
   - **Mac/Linux**: Delete the `App_Data` directory

3. **Port Conflicts**
   - If ports 5001 or 5173 are in use, update the ports in:
     - `Properties/launchSettings.json` (backend)
     - `ClientApp/vite.config.ts` (frontend)

---

## Project Structure

- `ClientApp/` - Vue 3 frontend with Vite
- `MyApp/` - .NET 8 backend
  - `ServiceModel/` - Request/response DTOs
  - `ServiceInterface/` - Service implementations
  - `Migrations/` - Database migrations

## License

This project is based on the [vue-spa](https://github.com/NetCoreTemplates/vue-spa) template which is licensed under the terms of the MIT license.
