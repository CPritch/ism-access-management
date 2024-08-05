# Access Control Management System

A web-based UI built using C# / ASP.NET Core and MudBlazor for managing access control (door) states.

## Features

- Displays a list of doors with their current states (Open/Closed, Locked/Unlocked, Alarmed/Inactive).
- Allows users to change the state of each door through interactive buttons.
- Real-time updates: Changes made on one client are instantly reflected on all connected clients using SignalR.
- Visually highlights doors that are in an alarmed state.
- Responsive UI for all screen sizes

## Getting Started

### Prerequisites

- .NET 8 SDK or later

### Installation & Running

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/CPritch/ism-access-management
    ```
2.  **Navigate to the project directory:**
    ```bash
    cd ism-access-management/AccessManager
    ```
3.  **Restore NuGet packages:**
    ```bash
    dotnet restore
    ```
4.  **Run the application:**
    ```bash
    dotnet run
    ```
5.  **Open in browser:**
    - The application should now be running at `https://localhost:7198`. 
    - Open multiple browser windows or tabs to see the real-time updates in action.

