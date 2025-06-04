## App Data Directory

This directory contains:

- **SQLite Database Files**:
  - `app.db`: Main application database
  - `*.db-journal`: SQLite journal files (automatically managed)

### Database Management

#### First Time Setup

The database is automatically created when you first run the application. If you encounter issues:

```bash
# Navigate to the project root
cd /path/to/project/MyApp

# Delete existing database (if needed)
rm -f App_Data/app.db

# Create and apply migrations
dotnet ef database update
```

#### Resetting the Database

To start fresh:

```bash
# Delete the database file
rm -f App_Data/app.db

# Recreate the database
dotnet ef database update
```

### Note

- This directory is in `.gitignore` to prevent database files from being committed
- The `.gitkeep` file ensures the directory is tracked by git
