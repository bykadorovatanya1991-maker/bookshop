# 📚 Bookshop

An online bookshop with a book catalog, author pages, a shopping cart and checkout.

🔗 **Try it live:** https://bookshop.ngrok.dev/

## Tech stack

**Backend**
- ASP.NET Core Minimal API (.NET 10)
- Built-in dependency injection: services registered as scoped and injected into the endpoint handlers
- Entity Framework Core 10 with SQL Server, code-first with migrations
- DTOs for requests and responses, data-annotation validation for orders
- Sample books and authors seeded on startup  

**Frontend**
- Vanilla HTML, CSS and JavaScript (no framework), served as static files from the API
- Fetch API for backend calls
- Bootstrap 5.3, Bootstrap Icons, Google Fonts (Figtree)
- Cart stored in `localStorage`
- Shared header loaded as a reusable partial on every page

## Architecture

```
Frontend        HTML / CSS / JS pages, served as static files from Bookshop.Api/wwwroot
     │  fetch → JSON (REST)
     ▼
Backend
  Bookshop.Api        presentation: endpoints, DI registration, request validation
  Bookshop.Business   business logic: services, request and response DTOs
  Bookshop.Data       data access: entities, DbContext, migrations, seed data
     │  EF Core
     ▼
Database        SQL Server
```

Each backend project references only the one below it.

## API endpoints

The frontend talks to the backend through these REST endpoints:

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/books` | List books, search by title or author, or load by IDs (cart) |
| GET | `/api/books/{id}` | Book details |
| GET | `/api/authors` | List and search authors |
| GET | `/api/authors/{id}` | Author details with their books |
| POST | `/api/orders` | Place an order (email, phone, items) |

## Screens

- **Books**: responsive grid of book cards with search
- **Book details**: cover, description, price, "add to cart", link to the author
- **Authors**: searchable author list
- **Author page**: portrait, life dates, biography, available books
- **Cart**: change quantities, remove items, running total, checkout with email and phone, order confirmation
- **Header**: slide-out navigation menu and cart item counter
