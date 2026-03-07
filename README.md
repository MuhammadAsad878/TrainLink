# 🏋️‍♂️ TrainLink: Enterprise Training & Scheduling Platform

[![Frontend](https://img.shields.io/badge/Frontend-Angular_19-dd0031?style=for-the-badge&logo=angular)](https://github.com/MuhammadAsad878/TrainLink-Client-Angular)
[![Backend](https://img.shields.io/badge/Backend-.NET_8_Web_API-512bd4?style=for-the-badge&logo=dotnet)](https://github.com/MuhammadAsad878/TrainLink)
[![Database](https://img.shields.io/badge/Database-MS_SQL_Server-cc292b?style=for-the-badge&logo=microsoft-sql-server)](https://github.com/MuhammadAsad878/TrainLink)
[![Deployment](https://img.shields.io/badge/Deployed_On-Vercel_%7C_MonsterASP-000000?style=for-the-badge&logo=vercel)](https://trainlink-angular.vercel.app/)

> **Live Production Environment:** [https://trainlink-angular.vercel.app/](https://trainlink-angular.vercel.app/)
> **Portfolio and Detailed Case Study:** https://www.calldevx.tech

TrainLink is a high-performance, full-stack scheduling and user management platform. Built with a decoupled architecture, it bridges the gap between trainers and members through a highly secure, role-driven ecosystem. The system leverages an optimized Angular frontend and a blazing-fast .NET Core Web API driven by raw SQL stored procedures.

---

## 📸 System Previews

<div align="center">
  <img src="https://github.com/user-attachments/assets/5ecf3ac0-85ad-415b-ab2c-77032683ee47" alt="Admin Dashboard" width="19%" />
  <img src="https://github.com/user-attachments/assets/0e83aa43-8098-4ce8-a59f-966aadb48f5d" alt="Admin Dashboard" width="19%" />
  <img src="https://github.com/user-attachments/assets/58eb4397-01ba-454f-a290-45536fe3655a" alt="User Directory" width="19%" />
  <img src="https://github.com/user-attachments/assets/4bdcb5ab-cf01-4f8f-8b80-6d980cad42cf" alt="Meeting Slots" width="19%" />
  <img src="https://github.com/user-attachments/assets/e266d7ad-1a4c-4fbf-a90c-16c5094b6fad" alt="Dark Theme View" width="19%" />
</div>

---

## 🏗️ System Architecture & Tech Stack

### Frontend Architecture (Angular 19)
* **Performance:** Implemented **Lazy Loading** to split code into manageable chunks, drastically reducing initial load times.
* **State & Data Flow:** Utilized centralized Angular **Services** for state management and API communication.
* **Security & Auth:** Configured HTTP **Interceptors** to silently attach JWT tokens to outgoing requests and handle global error responses.
* **UI/UX:** Built reusable **Routing Layouts**, **Meaningful Tostr notifications** and a fully responsive **Dark/Light Theme** toggle.

### Backend Architecture (.NET 8 Web API)
* **Authentication:** Secured endpoints using industry-standard **JWT (JSON Web Tokens)**.
* **Data Validation:** Enforced strict, scalable data integrity rules using **Fluent Validations** before requests hit the database.
* **Data Access Layer:** Bypassed heavy ORMs in favor of **Dapper**, executing highly optimized, pre-compiled **Stored Procedures** directly against the SQL Server.
* **Hosting:** MonsterASP with strict **CORS** policies restricted to the Vercel frontend.

---

## ⚡ Core Features & Engineering Highlights

* **Advanced Role-Based Access Control (RBAC):** Engineered a secure permission hierarchy with entirely distinct dashboard layouts and capabilities for **Admins** (system oversight), **Trainers** (slot creation), and **Members** (booking).
* **High-Performance Database Operations:** Shifted heavy data processing to the database layer using custom Stored Procedures, achieving near-instantaneous query execution via Dapper.
* **Dynamic Scheduling Engine:** Real-time meeting slot management allowing trainers to broadcast availability and virtual meeting links securely.
* **Seamless Theming:** Integrated a persistent dark/light mode preference across all role layouts.

---

## ⚙️ Local Development Setup

To run this project locally, ensure you have Node.js, Angular CLI, and the .NET 8 SDK installed.

### 1. Backend Setup (.NET 8)
```bash
git clone https://github.com/MuhammadAsad878/TrainLink.git
