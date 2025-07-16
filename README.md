# HMS

## Hotel Management System

A comprehensive and modern **Hotel Management System (HMS)** designed to streamline hotel operations, manage guest and client data, and simplify the complexities of the hospitality industry. Built on a powerful and scalable technology stack, HMS offers a seamless experience for hotel staff, managers, and administrators.

---

## ✨ Overview

This project aims to provide an all-in-one solution for hotel management. From detailed client and reservation records to dynamic room and service management, the system is engineered for operational efficiency.

By centralizing key hotel functions into a single intuitive platform, HMS reduces manual work, minimizes errors, and enhances customer satisfaction.

This repository contains the complete source code for both the backend services and the frontend web application.

---

## ⭐ Key Features

### For Hotel Staff & Management:

* **Centralized Client Management:**
  Securely manage guest data, including contact details, booking history, and preferences.

* **Dynamic Room & Service Management:**
  Track room statuses (e.g., available, occupied, under maintenance), manage room types, update availability and pricing in real-time.

* **Seamless Booking & Reservation System:**
  Create, modify, and cancel reservations with ease. View current and future occupancy and handle complex bookings smoothly.

* **Integrated Billing & Invoicing:**
  Automatically generate accurate invoices for stays, services, and miscellaneous charges—always synced with reservation data.

* **Asynchronous Notifications:**
  Use message queues for sending booking confirmations and alerts without blocking the main system.

---

## 🚀 Technology Stack

This system is built using a modern, robust, and scalable set of technologies to ensure high performance and maintainability.

### Backend

* **.NET Framework** – Core foundation for backend logic and services
* **ASP.NET Web API** – RESTful APIs for frontend-backend communication
* **Entity Framework** – ORM for secure data access and management

### Frontend

* **Angular** – Single-page application (SPA) for responsive and dynamic user experience
* **TypeScript / HTML / CSS** – Standard technologies for building and styling the UI

### Database

* **SQL Server** – Relational database for storing bookings, clients, rooms, and related hotel data

### Messaging

* **RabbitMQ** – Message broker for decoupling and handling background jobs (e.g., notifications)

### Development Tools

* **Microsoft Visual Studio** – IDE for backend development
* **Angular CLI** – Development toolkit for Angular apps

---

## 🛠️ Getting Started

To get a local copy up and running, follow these steps:

### Prerequisites

* [.NET Framework 4.8 or later](https://dotnet.microsoft.com/)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/)
* [Node.js & npm](https://nodejs.org/)
* [Angular CLI](https://angular.io/cli):

  ```sh
  npm install -g @angular/cli
  ```
* [Visual Studio](https://visualstudio.microsoft.com/) with the following workloads:

  * ASP.NET and Web Development

---

### Installation

1. **Clone the repository:**

   ```sh
   git clone https://github.com/ewceniza9009/hms.git
   ```

2. **Backend Setup:**

   * Open `HotelManagementSystem.sln` in Visual Studio.
   * Update the database connection string in `Web.config` or `appsettings.json`.
   * Build and run the backend project.

3. **Frontend Setup:**

   * Navigate to the frontend directory:

     ```sh
     cd hms/clients
     ```

   * Install dependencies:

     ```sh
     npm install
     ```

   * Update the API endpoint in:

     ```
     src/environments/environment.ts
     ```

     to match your backend URL.

   * Run the Angular app:

     ```sh
     ng serve
     ```

   * Open [http://localhost:4200](http://localhost:4200) in your browser.

---

## 🤝 Contributing

Contributions are what make the open-source community amazing. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch

   ```sh
   git checkout -b feature/AmazingFeature
   ```
3. Commit your Changes

   ```sh
   git commit -m 'Add some AmazingFeature'
   ```
4. Push to the Branch

   ```sh
   git push origin feature/AmazingFeature
   ```
5. Open a Pull Request

---

## 📜 License

Distributed by **Erwin Wilson Ceniza**.

---

## 📞 Contact

**Erwin Wilson Ceniza** – [erwinwilsonceniza@gmail.com](mailto:erwinwilsonceniza@gmail.com)

**Project Link:** [https://github.com/ewceniza9009/hms](https://github.com/ewceniza9009/hms)

---

Let me know if you'd like me to add deployment instructions, Docker support, or GitHub Actions CI/CD examples.
