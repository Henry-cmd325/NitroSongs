# 🎸 NitroSongs

**NitroSongs** is a platform designed for guitarists and songwriters who want to organize their personal collection of songs 
— whether original compositions or popular songs — using their own custom chords. The project follows the principles of **Clean Architecture**, 
enabling a modular, scalable, and maintainable codebase.

---

## 📐 Architecture

This project is built using **Clean Architecture** principles, ensuring clear separation of concerns, maintainability, and testability.

### Project Structure:
/NitroSongs  
├── NitroSongs.Api → REST API exposing HTTP endpoints  
├── NitroSongs.ApplicationLayer→ Use cases and application logic  
├── NitroSongs.Domain → Domain entities and core business rules  
├── NitroSongs.Infrastructure → Data access and external services (EF Core)  
├── NitroSongs.Common → DTOs and shared models  
├── NitroSongs.Desktop → Desktop app UI (WinUI)  


### Layers:

- **Domain**: Contains core entities like `Song`, `User`, `ChordSheet`, etc.
- **ApplicationLayer**: Orchestrates use cases and business processes.
- **Infrastructure**: Implements repositories, EF Core configuration, and service integrations.
- **Api**: Hosts REST endpoints for interacting with the system.
- **Common**: Holds shared models, response types, and DTOs.
- **Desktop (WinUI)**: A Windows desktop interface for users preferring an offline experience.

---

## 🚀 Project Goal

To build a full-featured tool for composers and guitarists, enabling them to:

- Store their original songs with lyrics and custom chords.
- Edit and personalize popular songs by modifying the chords.
- Organize songs into custom songbooks or by musical genre.
- Access their collection through a desktop app or API (and future web/mobile versions).

---

## 🛠️ Tech Stack

- **.NET 8**
- **Entity Framework Core**
- **AutoMapper**
- **ASP.NET Core Web API**
- **WinUI (XAML) for desktop interface**
- **Clean Architecture as base pattern**

---

## 📦 Installation & Setup

### Requirements:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Visual Studio 2022 (recommended)
- PostgreSQL

Developed by [Henry-cmd325]