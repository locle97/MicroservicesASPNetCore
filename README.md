# Mechanical Keyboard Enthusiasts Platform - ASP.NET Core Microservices POC 

## Introduction

Welcome to the Mechanical Keyboard Enthusiasts Platform POC! This project is designed to provide a comprehensive platform for mechanical keyboard enthusiasts, enabling a vibrant community space, a detailed product catalog, customization tools, and build guides. The frontend is developed using Angular, while the backend is powered by .NET, with each service having its own separate database.

## Table of Contents

- [Introduction](#introduction)
- [Architecture](#architecture)
- [Services](#services)
- [Technologies](#technologies)
- [Setup and Installation](#setup-and-installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Architecture

The platform is built using a microservices architecture to ensure scalability, flexibility, and maintainability. Each service is independent and communicates with others through API calls.

### Core Services

1. **User Management Service**
   - Handles user registration, authentication, and profile management.
   
2. **Product Service**
   - Manages the catalog of mechanical keyboard products, including keyboards, switches, keycaps, and accessories.
   
3. **Customization Tool Service**
   - Offers tools for designing and visualizing custom keyboard layouts, keycaps, and lighting setups.
   
4. **Build Guide Service**
   - Provides step-by-step guides and tutorials for building and modding mechanical keyboards.

## Technologies

### Frontend
- **Framework:** Angular
- **Language:** TypeScript
- **Styling:** SCSS/CSS
- **Build Tool:** Angular CLI

### Backend
- **Framework:** .NET
- **Language:** C#
- **Database:** Each service uses its own separate database (SQL Server, PostgreSQL, or MongoDB based on service needs)
- **API Communication:** RESTful APIs

## Setup and Installation

### Prerequisites

- Node.js and npm (for Angular)
- .NET SDK
- SQL Server/PostgreSQL/MongoDB (depending on the service)

### Frontend Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/mechanical-keyboard-platform.git
   cd mechanical-keyboard-platform/frontend```

2. Install dependencies
    ```bash
    npm install
    ```

3. Run the Angular application:
    ```bash
    ng serve
    ```

## Usage
After setting up, you can access the platform through http://localhost:4200. Use the provided tools to register, browse products, customize keyboards, and follow build guides.

## Contributing
We welcome contributions to the Mechanical Keyboard Enthusiasts Platform! Please fork the repository and submit pull requests for review.

## License
This project is licensed under the MIT License.
