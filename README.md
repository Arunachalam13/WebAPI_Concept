# WebAPI_Concept

# .NET Web API Interview Preparation

## Introduction to Web API

### What is Web API?
Web API (Application Programming Interface) is a framework that allows the development of HTTP-based services that can be accessed by various clients, including web applications, mobile apps, and IoT devices.

### Key Features of Web API
- **Platform Independent:** Can be consumed by any client (mobile, web, or desktop).
- **Lightweight & Efficient:** Uses JSON/XML over HTTP, making it efficient.
- **Scalable:** Designed to handle multiple requests and high traffic.
- **Follows REST Principles:** Uses standard HTTP methods like GET, POST, PUT, DELETE.

### Use Cases
- Creating **RESTful services** for mobile and web applications.
- **Exposing services** for third-party integrations (e.g., payment gateways, social media).
- **Building microservices** architecture for modular applications.
- **Consuming external APIs** (e.g., fetching weather data, stock prices).

### Example of a Simple Web API in .NET Core
```csharp
[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, World!");
    }
}
```
- `ApiController`: Defines the class as an API controller.  
- `Route("api/[controller]")`: Sets the route for accessing the API.  
- `HttpGet`: Specifies that this method handles HTTP GET requests.  
- `Ok("Hello, World!")`: Returns a response with a 200 OK status and message.

## RESTful Principles

### What is REST?
REST (Representational State Transfer) is an architectural style for building web services that communicate over HTTP. A RESTful API follows specific principles to ensure scalability, maintainability, and performance.

### Key RESTful Principles
1. **Client-Server Architecture**
   - The API and client applications are independent. The client only interacts with the API via HTTP requests.
2. **Statelessness**
   - Each request from the client contains all the necessary information. The server does not store any client state.
3. **Cacheability**
   - Responses must define whether they are cacheable or not, improving performance and scalability.
4. **Layered System**
   - The API can have multiple layers (e.g., security, caching, load balancing) without affecting client interaction.
5. **Uniform Interface**
   - The API should have a consistent way of interacting using HTTP methods and status codes.
6. **Code on Demand (Optional)**
   - The server can send executable code (e.g., JavaScript) to the client for execution, though this is not commonly used in APIs.

### HTTP Methods in REST
| Method   | Description |
|----------|------------|
| **GET**  | Retrieves data from the server |
| **POST** | Creates a new resource |
| **PUT**  | Updates an existing resource (or creates if it does not exist) |
| **DELETE** | Removes a resource |
| **PATCH** | Partially updates a resource |

### HTTP Status Codes in RESTful APIs
| Status Code | Meaning |
|-------------|---------|
| **200 OK** | Request was successful |
| **201 Created** | A new resource was created successfully |
| **204 No Content** | Request was successful but no response body |
| **400 Bad Request** | Invalid request sent by the client |
| **401 Unauthorized** | Authentication is required |
| **403 Forbidden** | Client does not have permission |
| **404 Not Found** | Resource not found |
| **500 Internal Server Error** | Server encountered an error |

### Example of RESTful API Endpoint
```csharp
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        var products = new List<string> { "Laptop", "Smartphone", "Tablet" };
        return Ok(products);
    }
}
```
- `GET api/products` → Returns a list of products.
- The response follows REST principles with proper status codes and uniform structure.

By following these principles, RESTful APIs become scalable, maintainable, and easy to integrate with various client applications.

## Web API vs WCF vs MVC

### Overview
| Feature | Web API | WCF | MVC |
|--------|--------|-----|-----|
| Purpose | Building RESTful services | Building SOAP/REST services | Building Web Applications (UI) |
| Protocols | HTTP | HTTP, TCP, Named Pipes, MSMQ | HTTP |
| Message Format | JSON, XML | SOAP (default), JSON, XML | HTML (Views) |
| Hosting | IIS, Self-hosting, Kestrel | IIS, Self-hosting, Windows Service | IIS, Kestrel |
| Testable with Browser | Yes | Only HTTP bindings | Yes |
| Best suited for | Lightweight services, mobile apps, RESTful APIs | Enterprise-level services, legacy support, inter-process communication | Web applications with UI (MVC pattern) |

### When to Use
- **Web API:**
  - When you need lightweight, RESTful services.
  - When targeting multiple platforms like mobile, browser, IoT.
- **WCF:**
  - When you need advanced features like duplex communication, transport security, reliable messaging.
  - For legacy systems or when working with SOAP.
- **MVC:**
  - When you need to build full-fledged web applications with frontend and backend logic.

### Key Takeaway
- Use **Web API** for modern RESTful services.
- Use **WCF** when working with legacy enterprise systems requiring SOAP or advanced features.
- Use **MVC** when you need to render HTML views and build web applications.




| Area                   | Description                                                                  |
| ---------------------- | ---------------------------------------------------------------------------- |
| **Backend Skills**     | Master ASP.NET Core Web API (Filters, Middleware, Auth, DI, etc.)            |
| **Clean Architecture** | Build sample projects using Domain-Driven Design                             |
| **SQL Proficiency**    | Joins, optimization, stored procs, query tuning                              |
| **Design Patterns**    | Factory, Singleton, Strategy, Dependency Injection, etc.                     |
| **Unit Testing**       | Learn XUnit or NUnit for API testing                                         |
| **DSA**                | Learn basic Data Structures + Algorithms (2–3 questions/day from LeetCode)   |
| **System Design**      | Basics like designing a login system, e-commerce app, RESTful APIs           |
| **Git & CI/CD**        | Use GitHub for your portfolio and CI pipelines (GitHub Actions/Azure DevOps) |

References videos:

Build REST APIs in .NET 9 – Full Course for Beginners (FreeCodeCamp) - https://www.youtube.com/watch?v=38GNKtclDdE&t=1271s