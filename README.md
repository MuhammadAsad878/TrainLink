# 🏋️‍♂️ TrainLink: Training & Scheduling Management Platform

[![Frontend](https://img.shields.io/badge/Frontend-Angular_19-dd0031?style=for-the-badge&logo=angular)](https://github.com/MuhammadAsad878/TrainLink-Client-Angular)
[![Backend](https://img.shields.io/badge/Backend-.NET_8_Web_API-512bd4?style=for-the-badge&logo=dotnet)](https://github.com/MuhammadAsad878/TrainLink)
[![Database](https://img.shields.io/badge/Database-MS_SQL_Server-cc292b?style=for-the-badge&logo=microsoft-sql-server)](https://github.com/MuhammadAsad878/TrainLink)
[![Deployment](https://img.shields.io/badge/Deployed_On-Vercel_%7C_MonsterASP-000000?style=for-the-badge&logo=vercel)](https://trainlink-angular.vercel.app/)

> **Live Production Environment:** [https://trainlink-angular.vercel.app/](https://trainlink-angular.vercel.app/)
> **Detailed Case Study:** [https://www.calldevx.tech]

TrainLink is a high-performance, full-stack web application designed to bridge the gap between trainers and members. Built with a decoupled architecture, it provides a centralized platform for scheduling meeting slots, managing user directories, and enforcing strict Role-Based Access Control (RBAC) using a modern Angular frontend and a secure .NET Core backend.

---

## 🏗️ System Architecture & Tech Stack

The application relies on a scalable client-server architecture, ensuring a seamless user experience across different authorization levels.

### Frontend (Client)
* **Framework:** Angular 19
* **Hosting:** Vercel (CI/CD automated deployment)
* **Features:** Dynamic dashboards, filterable data tables, and state management.

### Backend (API)
* **Framework:** .NET 8 Web API
* **Architecture:** RESTful API with MVC pattern principles
* **Hosting:** MonsterASP

### Database & Storage
* **Database:** Microsoft SQL Server (Cloud Hosted)
* **ORM:** Entity Framework Core

---

## ⚡ Core Features & Engineering Highlights

* **Role-Based Access Control (RBAC):** Engineered a secure permission system with distinct capabilities and dashboard views for **Admins** (system oversight), **Trainers** (slot creation), and **Members** (booking and viewing).
* **Dynamic Scheduling Engine:** Developed a real-time meeting slot management system allowing trainers to create time slots paired with virtual meeting links.
* **Interactive Analytics Dashboard:** Built a live analytics view tracking total users, active roles, and upcoming active slots.
* **Secure Cloud Integration:** Configured encrypted remote connection strings bridging the MonsterASP backend with the cloud-hosted MS SQL Server.
* **Strict Security Policies:** Implemented robust Cross-Origin Resource Sharing (CORS) policies to ensure secure data transmission exclusively between the Vercel-hosted frontend and the .NET backend.

---

## ⚙️ Local Development Setup

To run this project locally, ensure you have Node.js, Angular CLI, and the .NET 8 SDK installed.

### 1. Clone the Repository
```bash
git clone https://github.com/MuhammadAsad878/TrainLink.git
