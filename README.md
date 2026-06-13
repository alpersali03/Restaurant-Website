# Restaurant Website

`Restaurant Website` is an ASP.NET Core MVC application for browsing a restaurant menu, managing orders, and completing checkout through a provider-backed payment flow.

The project includes:

- customer-facing menu, product, cart, and checkout pages
- admin-style CRUD pages for products, categories, coupons, reservations, reviews, and payments
- ASP.NET Core Identity authentication
- Entity Framework Core with SQL Server
- automated unit and integration tests
- a configurable payment gateway with `Demo` and `Stripe` modes

## Tech Stack

- `.NET 8`
- `ASP.NET Core MVC`
- `Entity Framework Core`
- `SQL Server`
- `ASP.NET Core Identity`
- `AutoMapper`
- `xUnit`
- `Stripe.net`

## Main Features

### Customer features

- homepage with featured dishes, categories, and review highlights
- menu browsing
- product details
- cart/order management
- checkout flow with payment session handoff
- authenticated order access

### Admin/back-office features

- manage categories
- manage products
- manage coupons
- manage reservations
- manage reviews
- view payments and payment status

### Payment flow

The application uses a provider-backed checkout model.

- `Demo` gateway is the default for local development
- `Stripe` gateway is available for real payment-session creation
- the application stores payment transaction metadata and status
- raw card details are not collected in the app UI

## Solution Structure

```text
Restaurant-Website/
|-- Restaurant.sln
|-- README.md
|-- Restaurant/
|   |-- Controllers/
|   |-- Data/
|   |-- DTOs/
|   |-- Extensions/
|   |-- Migrations/
|   |-- Models/
|   |-- Options/
|   |-- Services/
|   |   `-- Payments/
|   |-- Views/
|   `-- wwwroot/
`-- Restaurant.Tests/
```

## Getting Started

### Prerequisites

Install:

- `.NET 8 SDK`
- `SQL Server` or `SQL Server Express/LocalDB`

### 1. Clone the repository

```bash
git clone https://github.com/alpersali03/Restaurant-Website.git
cd Restaurant-Website
```

### 2. Configure the database connection

The default connection string is stored in [Restaurant/appsettings.json](C:/Users/PC/Documents/GitHub/Restaurant-Website/Restaurant/appsettings.json):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Restaurant;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Update it if your SQL Server instance is different.

### 3. Apply database migrations

```bash
dotnet ef database update --project Restaurant
```

If `dotnet ef` is not installed:

```bash
dotnet tool install --global dotnet-ef
```

### 4. Run the application

```bash
dotnet run --project Restaurant
```

By default, ASP.NET Core will print the local application URL in the terminal.

## Payment Configuration

Payment options are configured in [Restaurant/appsettings.json](C:/Users/PC/Documents/GitHub/Restaurant-Website/Restaurant/appsettings.json):

```json
"Payments": {
  "Gateway": "Demo",
  "Currency": "usd",
  "ApplicationBaseUrl": "https://localhost"
}
```

### Demo mode

Use this for local development:

```json
"Payments": {
  "Gateway": "Demo"
}
```

### Stripe mode

To use Stripe, configure:

```json
"Payments": {
  "Gateway": "Stripe",
  "Currency": "usd",
  "ApplicationBaseUrl": "https://localhost"
}
```

And provide your Stripe secret key through user secrets or environment variables.

Suggested user secret:

```bash
dotnet user-secrets set "Payments:Stripe:SecretKey" "your_stripe_secret_key" --project Restaurant
```

## Authentication

The project uses `AddDefaultIdentity<IdentityUser>()` with EF Core stores.

- registration and login are provided through ASP.NET Core Identity UI
- authenticated users can access order and checkout flows
- authorization is enabled in the request pipeline

## Testing

Run all tests:

```bash
dotnet test Restaurant.sln
```

Current automated coverage includes:

- service tests for product details, category deletion, and checkout behavior
- integration tests for authenticated order/checkout flows

## Important Project Notes

- the app targets `net8.0`
- the default payment gateway is `Demo`
- SQL Server is the configured runtime database provider
- the project includes EF Core migrations in `Restaurant/Migrations`
- tests use `EF Core InMemory` and `WebApplicationFactory`

## Useful Commands

Build the solution:

```bash
dotnet build Restaurant.sln
```

Run tests:

```bash
dotnet test Restaurant.sln
```

Create a new migration:

```bash
dotnet ef migrations add YourMigrationName --project Restaurant
```

Apply migrations:

```bash
dotnet ef database update --project Restaurant
```

## Current Architecture

The application follows a straightforward MVC + service-layer structure:

- `Controllers` handle routing and request flow
- `Services` contain business logic
- `DTOs` shape input and view data
- `Data` contains EF Core entities and `ApplicationDbContext`
- `Views` provide Razor-based UI

This keeps controller logic smaller and makes the application easier to test.

## Future Improvements

Good next steps for the project:

- add stronger role-based authorization for admin pages
- improve validation coverage across all forms
- replace development-oriented seed behavior with deterministic migration-safe seed data
- expand integration tests around admin workflows
- add deployment documentation

## License

No license file is currently included in the repository. Add one if you want to define usage and distribution terms clearly.
