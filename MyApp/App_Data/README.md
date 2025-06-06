## App Data Directory

This directory contains all database and storage files used by the application.

- **SQL Server LocalDB Files**:
  - Used for both application data and authentication
  - Automatically created in your LocalDB instance
  - Visual Studio provides integrated management through SQL Server Object Explorer

## Management

You can manage your SQL Server LocalDB database through:
- SQL Server Object Explorer in Visual Studio (View > SQL Server Object Explorer)
- The built-in admin UI at `/admin-ui/database` (login required)

## Maintenance

- **Backup**: Use SQL Server Management Studio or the backup commands in Visual Studio
- **Reset**: Delete the database through SQL Server Object Explorer and restart the application

### Note

- This directory is in `.gitignore` to prevent database files from being committed
- The `.gitkeep` file ensures the directory is tracked by git
