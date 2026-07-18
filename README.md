# ⚽ TeamMaker WebApp

A modern ASP.NET Core MVC web application for creating balanced football teams quickly and efficiently. TeamMaker allows users to manage players, upload player photos, and generate random teams with just a few clicks.

## 📖 Overview

TeamMaker is designed to simplify team selection for football matches. Instead of manually dividing players, the application automatically distributes selected players into balanced teams.

The application features a modern responsive interface, player management, image uploads, and automatic team generation.

## ✨ Features

- ✅ Add new players
- ✅ Edit player information
- ✅ Delete players
- ✅ View player details
- ✅ Upload player profile images
- ✅ Default image support
- ✅ Random team generation
- ✅ Select 2–4 teams
- ✅ Select specific players
- ✅ Responsive modern UI
- ✅ Professional homepage
- ✅ Generated team view

## 🛠 Built With

### Frontend

- HTML5
- CSS3
- Bootstrap 5
- JavaScript
- Razor Views

### Backend

- ASP.NET Core MVC
- C#
- Entity Framework Core

### Database

- Microsoft SQL Server

---

## 📂 Project Structure


TeamMaker_WebApp
│
├── Controllers
│   ├── HomeController
│   ├── PlayerController
│   └── TeamController
│
├── Models
│   ├── Player
│   ├── Team
│   └── ViewModels
│
├── Views
│   ├── Home
│   ├── Player
│   ├── Team
│   └── Shared
│
├── wwwroot
│   ├── css
│   ├── js
│   ├── images
│   └── uploads
│
└── Data
    └── ApplicationDbContext


## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022
- .NET 8 SDK 
- SQL Server
- SQL Server Management Studio

---

### Installation

Clone the repository

bash
git clone https://github.com/yourusername/TeamMaker_WebApp.git


Navigate to the project

bash
cd TeamMaker_WebApp


Restore packages

bash
dotnet restore


Update the database

bash
dotnet ef database update


Run the project

bash
dotnet run


Or simply open the solution in Visual Studio and press **F5**.

## 📸 Screenshots

You can add screenshots here.
## 📸 Screenshots

| Home | Players |
|------|---------|
| ![](Images/Screenshots/Home.png) | ![](Images/Screenshots/Players.png) |

| Add Player | Generated Teams |
|------------|-----------------|
| ![](Images/Screenshots/Players.png) | ![](Images/Screenshots/Generated-Teams.png) |

Player Details
## 📋 Main Functionalities

### Player Management

- Add players
- Upload profile images
- Edit player information
- Delete players
- View player details

### Team Generation

- Select players
- Choose number of teams
- Generate balanced random teams
- View generated teams

---

## 📌 Future Improvements

- Player skill ratings
- Position-based balancing
- Team captain selection
- Match scheduling
- Export generated teams as PDF
- User authentication
- Admin dashboard
- Team history
- Drag-and-drop team editing

---

## 💻 Technologies Used

| Technology | Purpose |
|------------|---------|
| ASP.NET Core MVC | Web Framework |
| Entity Framework Core | ORM |
| SQL Server | Database |
| Bootstrap 5 | UI Framework |
| JavaScript | Client-side Functionality |
| CSS3 | Styling |

---

## 👨‍💻 Author

**Michah Mithun Saha**

Computer Science Graduate

University of Liberal Arts Bangladesh (ULAB)

GitHub: https://github.com/Mithun324

LinkedIn: https://linkedin.com/in/michah-mithun-saha

---

## 📄 License

This project is developed for educational and portfolio purposes.

---

⭐ If you found this project useful, consider giving it a star.
