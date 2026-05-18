# SmartProducts

Aplicación Full Stack desarrollada como prueba técnica utilizando arquitectura enterprise.

## 🚀 Tecnologías Utilizadas

### Backend
- .NET 8 Web API
- Clean Architecture
- DDD (Domain-Driven Design)
- CQRS con MediatR
- Entity Framework Core 8
- SQL Server 2022
- FluentValidation
- JWT Authentication
- Refresh Tokens
- Swagger/OpenAPI
- Docker

### Frontend
- Angular 17 (Standalone Components)
- TypeScript
- Bootstrap 5
- Reactive Forms
- Http Interceptor
- Route Guards
- Docker (Nginx)

### Infraestructura
- Docker Compose
- SQL Server en contenedor
- Nginx para servir Angular

---

# 🏗️ Arquitectura de la Solución

```text
SmartProducts/
│
├── SmartProducts.Api/              # API REST
├── SmartProducts.Application/      # Casos de uso (CQRS)
├── SmartProducts.Domain/           # Entidades y reglas de negocio
├── SmartProducts.Infrastructure/   # EF Core, JWT, servicios
├── smart-products-web/             # Frontend Angular
│
├── docker-compose.yml
├── SmartProducts.sln
└── README.md
```

---

# 📦 Backend Structure

## SmartProducts.Domain
- `Entities/Product.cs`
- `Common/BaseEntity.cs`
- `Common/AuditableEntity.cs`

## SmartProducts.Application
- DTOs
- Interfaces
- Commands
- Queries
- Handlers
- Validators
- Pipeline Behaviors
- Result Pattern

## SmartProducts.Infrastructure
- Persistence (`AppDbContext`)
- Entity Configurations
- Repositories
- Services
- JWT Authentication
- Migrations

## SmartProducts.Api
- Controllers
- Middleware
- Swagger Extensions
- Program.cs

---

# ✨ Funcionalidades Implementadas

## 🔐 Autenticación
- Login con JWT.
- Generación de Refresh Token.
- Endpoint de login demo.
- Protección de endpoints con `[Authorize]`.
- Swagger con botón `Authorize`.

## 📦 Productos
- Crear producto.
- Listar productos.
- Validación de datos.
- Persistencia en SQL Server.

## 🧠 Buenas prácticas
- Clean Architecture.
- DDD.
- CQRS.
- Repository Pattern.
- Service Layer.
- Pipeline Behaviors.
- Global Exception Middleware.
- Dependency Injection.

## 🖥️ Frontend Angular
- Login automático.
- Almacenamiento del token en `localStorage`.
- Interceptor JWT.
- Auth Guard.
- Listado de productos.
- Creación de productos.
- Búsqueda por código y nombre.
- Logout.
- Diseño responsivo con Bootstrap.

## 🐳 Docker
- SQL Server.
- API .NET 8.
- Angular 17 con Nginx.
- Orquestación con Docker Compose.

---

# 🔗 Endpoints

## Auth
### POST `/api/Auth/login`
Genera token JWT y refresh token.

#### Response
```json
{
  "accessToken": "eyJhbGciOi...",
  "refreshToken": "..."
}
```

## Products
### GET `/api/Products`
Obtiene la lista de productos.

### POST `/api/Products`
Crea un nuevo producto.

#### Request
```json
{
  "name": "Laptop Dell",
  "price": 3500
}
```

#### Response
```json
1
```

---

# 🗄️ Modelo de Datos

## Products
| Campo | Tipo |
|------|------|
| Id | int |
| Name | nvarchar(100) |
| Price | decimal(18,2) |
| CreatedAt | datetime2 |
| UpdatedAt | datetime2 nullable |

---

# 🐳 Docker Compose

Servicios incluidos:
- `sqlserver`
- `api`
- `frontend`

### URLs
- Frontend: http://localhost:4200
- Swagger: http://localhost:5063/swagger
- SQL Server: localhost,1433

---

# 🚀 Cómo ejecutar el proyecto

## 1. Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd SmartProducts
```

## 2. Levantar contenedores

```bash
docker compose up --build -d
```

## 3. Abrir la aplicación

- Frontend: http://localhost:4200
- Swagger: http://localhost:5063/swagger

---

# 🔐 Flujo de Uso

1. Abrir el frontend.
2. Clic en **Iniciar Sesión**.
3. Angular consume `/api/Auth/login`.
4. Se almacena el JWT.
5. Se redirige al listado de productos.
6. Crear productos.
7. Buscar por código o nombre.
8. Cerrar sesión.

---

# 🧪 Pruebas Manuales

## Swagger
1. Ejecutar `POST /api/Auth/login`.
2. Copiar `accessToken`.
3. Click en `Authorize`.
4. Pegar `Bearer {token}`.
5. Ejecutar `POST /api/Products`.
6. Ejecutar `GET /api/Products`.

## Frontend
1. Login.
2. Crear producto.
3. Consultar productos.
4. Buscar.
5. Logout.

---

# 📁 Migraciones

Las migraciones se encuentran en:

```text
SmartProducts.Infrastructure/Persistence/Migrations
```

Incluyen:
- `InitialCreate.cs`
- `AppDbContextModelSnapshot.cs`

---

# 🔧 Comandos Útiles

## Crear migración

```bash
dotnet ef migrations add InitialCreate --project SmartProducts.Infrastructure --startup-project SmartProducts.Api --output-dir Persistence/Migrations
```

## Actualizar base de datos

```bash
dotnet ef database update --project SmartProducts.Infrastructure --startup-project SmartProducts.Api
```

## Ejecutar backend localmente

```bash
dotnet run --project SmartProducts.Api
```

## Ejecutar Angular localmente

```bash
cd smart-products-web
ng serve
```


# 📌 Credenciales de SQL Server

- Server: `localhost,1433`
- User: `sa`
- Password: `Str0ng!SqlServer2026#Secure`

---

# 👨‍💻 Autor

Desarrollado como solución enterprise para una prueba técnica utilizando buenas prácticas de arquitectura y desarrollo Full Stack.

