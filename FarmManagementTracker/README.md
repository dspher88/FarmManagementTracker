# FarmManagementTracker

A full-featured ASP.NET Core MVC web application to help small farmers track livestock, supplies, vaccinations, and recurring tasks.

## 🐄 Features

- Animal records (create/edit/delete)
- Vaccination logs linked by Animal ID
- Feed & supply inventory management
- Recurring task scheduling (e.g., cleanings)
- CSV export for data backups
- Admin panel for user roles and permissions
- Low balance supply alerts
- Modern dark-themed UI with grouped sections

## 🧰 Tech Stack

- ASP.NET Core MVC (.NET 6)
- Entity Framework Core
- SQLite (.mdf support via migrations)
- Identity for user authentication
- Bootstrap + custom CSS for UI styling

## 🔐 User Roles

- **Admin**: Full access, can manage users
- **Viewer**: Read-only access to all pages
- **Default**: Standard user with edit rights

## 📸 Screenshots

*Add screenshots here using Markdown once you upload them.*

```markdown
![Dashboard](screenshots/dashboard.png)
