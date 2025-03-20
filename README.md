# ScaleElite

ScaleElite is a **real-time industry management system** built with **C#** and **ASP.NET Core Web API**. The system tracks vehicles, weighbridges, users, drivers, and transactions in real time, ensuring seamless data synchronization. It also provides dynamic reporting with export options in **CSV**, **PDF**, and **Excel**, and features interactive dashboards with graphs and pie charts to visualize transactions efficiently.

![_- visual selection](https://github.com/user-attachments/assets/bc269c7f-5467-44ba-b733-3f70d6882361)


## Key Features

- **Real-Time Tracking**: Monitor vehicles, weighbridges, users, drivers, and transactions as they occur, providing instant business insights.
- **Dynamic Reporting**: Generate reports with export options in **CSV**, **PDF**, and **Excel** to suit various business needs.
- **Interactive Dashboards**: Use graphs and pie charts to visualize transaction data, improving decision-making and operational efficiency.
- **Data Synchronization**: Real-time data synchronization ensures that your business operations are always up-to-date and accurate.
- **User Management**: Administer user roles and permissions to control access to system features and data.

## Tech Stack

- **Backend**: **C#**, **ASP.NET Core Web API**
- **Database**: **MySQL**
- **Frontend**: **React**
- **Reporting**: Export functionality for **CSV**, **PDF**, and **Excel**
- **Data Sync**: Real-time synchronization for smooth business operations

## Installation

### Prerequisites

Before you begin, ensure you have the following installed:

- **.NET Core SDK**: [Download here](https://dotnet.microsoft.com/download)
- **MySQL**: [Download here](https://dev.mysql.com/downloads/installer/)
- **Visual Studio** (or preferred C# IDE): [Download here](https://visualstudio.microsoft.com/)

### Steps

1. **Clone the repository:**
   ```bash
   git clone https://github.com/dsnahil/ScaleElite.git
   ```

2. **Navigate to the project directory:**
   ```bash
   cd ScaleElite
   ```

3. **Restore dependencies:**
   If using Visual Studio, this is done automatically, but you can also use the following command:
   ```bash
   dotnet restore
   ```

4. **Set up MySQL database**:
   - Create a new database in MySQL (e.g., `scaleelite_db`).
   - Modify the `appsettings.json` file in the `ScaleElite` project to match your MySQL server connection string.

5. **Run the application:**
   ```bash
   dotnet run
   ```

6. **Access the API**:  
   The application will be accessible at `http://localhost:5000` (or the port specified in the application settings).

## Usage

- **API Endpoints**: ScaleElite provides several API endpoints to interact with the system. These include endpoints for tracking vehicles, generating reports, and retrieving transaction data.
- **Dashboards**: Use the frontend (if applicable) to visualize transaction data through interactive dashboards featuring graphs and pie charts.

## Contribution

We welcome contributions to ScaleElite! If you would like to contribute, please follow these steps:

1. **Fork the repository**.
2. **Clone your fork**:  
   ```bash
   git clone https://github.com/your-username/ScaleElite.git
   ```
3. **Create a new branch**:  
   ```bash
   git checkout -b feature-branch
   ```
4. **Make your changes**.
5. **Commit your changes**:  
   ```bash
   git commit -am 'Add new feature'
   ```
6. **Push to the branch**:  
   ```bash
   git push origin feature-branch
   ```
7. **Submit a pull request**.

## Contact

For any questions or support, feel free to reach out to me via [GitHub](https://github.com/dsnahil) or email me at [dsnahil@gmail.com].
