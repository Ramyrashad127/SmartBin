# ♻️ SmartBin API

An intelligent, AI-powered backend for modern waste management. Built with **ASP.NET Core**, this API serves as the central hub connecting user mobile applications with physical IoT Smart Bins (ESP32/Raspberry Pi). 

It features built-in Machine Learning to automatically classify waste via images, track bin fill-levels in real-time, and manage secure hardware-to-cloud communications.

## ✨ Core Features
* **🔒 Secure JWT Authentication:** Role-based access for mobile users and secure token-based authentication for physical IoT devices.
* **🧠 AI Image Classification:** Integrates a trained MobileNetV2 ONNX model to automatically detect and classify waste (Metal, Paper, Plastic) directly on the server.
* **📊 Real-Time Telemetry:** Tracks bin capacity, weight, and material fill-levels dynamically.
* **📂 Automated File Management:** Safely handles multipart/form-data image uploads and serves static files to front-end clients.
* **🚀 Modern .NET Architecture:** Utilizes .NET's newest OpenAPI document generation with Swagger UI.

## 🛠️ Tech Stack
* **Framework:** C# / ASP.NET Core 
* **Database:** SQL Server / Entity Framework Core
* **Machine Learning:** Microsoft.ML.OnnxRuntime / Keras
* **Image Processing:** SixLabors.ImageSharp
* **Authentication:** ASP.NET Core Identity / JSON Web Tokens (JWT)

---

## 🚀 Getting Started

### 1. Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) installed.
* SQL Server (LocalDB or SSMS) running.
* An ONNX model file named `smart_bin_model.onnx` located in your project's `AI_Models` folder.

### 2. Configuration (`appsettings.json`)
Before running the application, you must configure your database and JWT secrets. Ensure your `appsettings.json` looks like this:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=smartbin;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "JWT": {
    "ValidAudience": "http://localhost:5025",
    "ValidIssuer": "http://localhost:5025",
    "Secret": "YourSuperSecretKeyThatIsAtLeast32CharactersLong!"
  }
}

### 3. Database Setup
Open the Package Manager Console in Visual Studio and run the following command to build the SQL tables:
Update-Database

### 4. Folder Structure
Ensure you have a `wwwroot` folder at the root of your project to handle image uploads. The application will automatically create the `images/transactions` subfolders when the first photo is uploaded.

### 5. Run the Application
Press `F5` in Visual Studio or run `dotnet run` in the terminal. The browser will automatically open the Swagger UI page where you can test all endpoints.

---

## 📡 API Architecture & Integration

### 🤖 For Mobile / Web Developers
Users must register and log in to receive a JWT. This token must be attached as a `Bearer` token in the `Authorization` header for all requests.
* `POST /api/Auth/Register` - Create a new user.
* `POST /api/Auth/Login` - Retrieve JWT.
* `GET /api/BinSection/{BinId}` - Get real-time fill percentages for a specific bin.
* `POST /api/Bin/Assign?Token={token}` - Claim a physical bin and attach it to the logged-in user.

### ⚙️ For IoT / Hardware Developers (ESP32 / Raspberry Pi)
Physical bins do not use user accounts. They authenticate using a custom HTTP Header named `Token` containing their unique hardware UUID.
* `PUT /api/BinSection` - Update the physical weight and fill-level of the bin.
  * **Header:** `Token: <Hardware-UUID>`
* `POST /api/Transaction` - Send an image to the cloud for AI material sorting. Must be sent as `multipart/form-data`.
  * **Header:** `Token: <Hardware-UUID>`

---

## 📝 License
This project is proprietary and built for the SmartBin hardware ecosystem.
