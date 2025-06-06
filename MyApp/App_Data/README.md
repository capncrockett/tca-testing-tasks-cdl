## App Data Directory

This directory contains all database and storage files used by the application.

- **SQL Server Database**:
  - The application uses SQL Server for both application data and authentication
  - Database schema is automatically created on first run
  - All user accounts (admin, manager, employee, test) are automatically created

## Management

You can manage your SQL Server database through:
- SQL Server Object Explorer in Visual Studio (View > SQL Server Object Explorer)
- The built-in admin UI at `/admin-ui/database` (login required)

## Maintenance

- **Backup**: Use SQL Server Management Studio or the backup commands in Visual Studio
- **Reset**: Delete the database through SQL Server Object Explorer and restart the application

## Default User Accounts

The following user accounts are automatically created with password `p@55wOrd`:
- **Admin**: admin@email.com (has all roles: Admin, Manager, Employee)
- **Manager**: manager@email.com (has Manager and Employee roles)
- **Employee**: employee@email.com (has Employee role)
- **Test**: new@user.com (has no special roles)

### Note

- Database files are ignored by git to prevent them from being committed
- The `.gitkeep` file ensures the directory is tracked by git
