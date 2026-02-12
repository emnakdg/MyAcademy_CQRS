# 🍞 MyAcademy_CQRS - Bakery E-Commerce Project

A comprehensive E-Commerce Web Application built with **ASP.NET Core 9.0**, designed to demonstrate modern software architecture patterns including **CQRS**, **Mediator**, **Observer**, and **Unit of Work**.

This project simulates a real-world "Bakery" business, featuring a robust Admin Panel for management and a user-friendly UI for customers to browse products, read testimonials, and place orders.

## 🚀 Key Features

*   **CQRS Architecture**: Separation of Read (Query) and Write (Command) operations for scalability and maintainability.
*   **Mediator Pattern**: Decoupled request/response handling using `MediatR` library.
*   **Design Patterns:**
    *   **Unit of Work**: Centralized transaction management.
    *   **Observer**: Event-driven architecture for logging/notifications (Order, Contact, Campaign events).
    *   **Repository**: Abstraction layer for data access.
*   **Cloudinary Integration**: Cloud-based image storage and management for products and gallery.
*   **AutoMapper**: Efficient object-to-object mapping for entities and DTOs.
*   **Modern Admin Panel**: User-friendly dashboard for managing all aspects of the application.
*   **Dynamic UI**: Responsive frontend built with Razor Views and custom CSS.

## 🛠️ Tech Stack & Libraries

*   **Framework**: .NET 9.0 (ASP.NET Core MVC)
*   **Database**: Microsoft SQL Server (Entity Framework Core 9.0 - Code First)
*   **CQRS & Mediator**: `MediatR` (v12.5.0)
*   **Mapping**: `AutoMapper` (v13.0.1)
*   **Cloud Storage**: `CloudinaryDotNet` (v1.28.0)
*   **Frontend**: Razor Views, Bootstrap, HTML5, CSS3, jQuery
*   **IDE**: Visual Studio 2022

## 📦 Modules & Entities

The application allows full management of the following entities:

*   **🛒 Products & Categories**: Manage bakery items and their categories.
*   **📦 Orders**: Track customer orders and status.
*   **🖼️ Photo Gallery**: Upload and manage gallery images (stored in Cloudinary).
*   **📢 Campaigns & Promotions**: Create special offers and marketing campaigns.
*   **💬 Testimonials**: Manage customer reviews and feedback.
*   **slider**: Customize homepage sliders.
*   **📞 Contact**: View and manage customer messages.
*   **Other**: Services, Our History, Three Step Service modules.

## ⚙️ Installation & Setup

1.  **Clone the repository**
    ```bash
    git clone https://github.com/your-username/MyAcademy_CQRS.git
    ```

2.  **Configure Database**
    *   Update the connection string in `appsettings.json` (or `appsettings.Development.json`) to point to your SQL Server instance.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER;Database=MyAcademyCQRSDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
    }
    ```

3.  **Configure Cloudinary (Optional)**
    *   If you want to use image upload features, add your Cloudinary credentials to `appsettings.Development.json` (this file is git-ignored for security).
    ```json
    "Cloudinary": {
      "CloudName": "YOUR_CLOUD_NAME",
      "ApiKey": "YOUR_API_KEY",
      "ApiSecret": "YOUR_API_SECRET"
    }
    ```

4.  **Run Migrations (Optional)**
    *   The project is configured to potentially auto-create the DB or you can run:
    ```bash
    dotnet ef database update
    ```

5.  **Run the Application**
    *   Open the solution in Visual Studio and run the project (`Ctrl + F5`).
    *   The application includes a **Data Seeder** that will populate the database with sample Turkish data (Categories, Products, Testimonials, etc.) on the first run.

## 🏗️ Architecture Overview

The project structure follows a clean separation of concerns:

*   **CQRSProject**: Main Web Application
    *   `CQRSPattern`: Contains `Commands`, `Queries`, `Handlers` and `Results` (DTOs).
    *   `Entities`: Database models.
    *   `Context`: EF Core DbContext.
    *   `Patterns`: Implementations of UnitOfWork, Observer, etc.
    *   `Services`: External services like Cloudinary.
    *   `Mappings`: AutoMapper profiles.

---
*Developed by [Emin]*
