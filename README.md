# E-Gate Keeper

## Mô tả
Dự án này là một ví dụ về việc triển khai kiến trúc Clean Architecture sử dụng .NET Core. Clean Architecture giúp duy trì tính nhất quán, dễ bảo trì và kiểm thử ứng dụng bằng cách tách biệt các lớp ứng dụng theo chức năng.

## Cấu trúc dự án
Dự án được tổ chức theo các lớp chính như sau:

[![Clean Architecture Diagram](./images/Clean-Architecture-Diagram-Asp-Net.webp)](image_url)
### 1. Domain Layer
- Logic nghiệp vụ quan trọng phải nằm trong Domain.
- Sử dụng Entity và Value Object cho các đối tượng thuộc về Domain.
- Không để Domain phụ thuộc vào các tầng khác.
  
**Thư mục:** 
```
/Domain  
├── /Entities (Các thực thể của domain)
├── /ValueObjects (Các đối tượng giá trị)
├── /Events (Các sự kiện của domain)
├── /Enums (Các liệt kê của domain)
├── /Constants (Các hằng số của domain)
├── /Common (Các thành phần chung của domain)
└── /Exceptions (Các ngoại lệ đặc biệt của domain)
```

### 2. Application Layer
- Chứa logic điều phối, gọi tới các dịch vụ và repositories.
- Sử dụng Command và Query để phân tách các thao tác.
- Sử dụng DTO để chuyển đổi dữ liệu giữa các tầng.
  
**Thư mục:**
```
/Application  
├── /Common (Chứa các thành phần chung)
│   ├── /Behaviors (Các pipeline behaviors được áp dụng trong quá trình xử lý commands và queries, ví dụ như validation, logging, hoặc transaction management)
│   │   ├── LoggingBehavior.cs
│   │   ├── ValidationBehavior.cs
│   │   ├── TransactionBehavior.cs  (Quản lý giao dịch với Unit of Work)
│   ├── /Interfaces (Các giao diện được sử dụng trong tầng Application để trừu tượng hóa các dịch vụ. Các giao diện này giúp việc mock và test dễ dàng hơn)
│   │   ├── IUnitOfWork.cs
│   │   ├── IGenericRepository.cs
│   ├── /Mappings (Các cấu hình ánh xạ dữ liệu giữa các đối tượng (ví dụ: giữa Entity và DTO). Thường sử dụng với các thư viện như AutoMapper)
│   │   └── AutoMapperProfile.cs
│   ├── /Models (Các mô hình dữ liệu được sử dụng trong tầng Application. Các mô hình này có thể đại diện cho các đối tượng domain hoặc các đối tượng nội bộ)
│   ├── /Security (Các thành phần liên quan đến bảo mật trong ứng dụng, chẳng hạn như mã hóa, xác thực, hoặc quản lý quyền)
│   └── /Exceptions (Các ngoại lệ được định nghĩa riêng cho ứng dụng, giúp việc quản lý lỗi trở nên rõ ràng và có tổ chức)
├── /Features (Tổ chức mã nguồn theo từng tính năng cụ thể của ứng dụng. Mỗi tính năng sẽ có một thư mục riêng)
│   ├── /{FeatureName}
│   │   ├── /Commands (Các command và command handlers, được sử dụng để thực hiện các hành động cụ thể liên quan đến tính năng, như thêm, cập nhật, hoặc xóa dữ liệu)
│   │   │   ├── Create{FeatureName}Command.cs
│   │   │   ├── Create{FeatureName}CommandHandler.cs
│   │   │   └── Delete{FeatureName}Command.cs
│   │   ├── /Queries (Các query và query handlers, được sử dụng để lấy dữ liệu mà không làm thay đổi trạng thái của ứng dụng)
│   │   │   ├── Get{FeatureName}ByIdQuery.cs
│   │   │   ├── Get{FeatureName}ByIdQueryHandler.cs
│   │   └── /Events (Các sự kiện (event) liên quan đến tính năng. Các sự kiện này có thể được kích hoạt bởi các hành động cụ thể trong ứng dụng)
│   │       ├── {FeatureName}CreatedEvent.cs
│   │       └── {FeatureName}UpdatedEvent.cs
├── /Service (Chứa các dịch vụ dùng để thực hiện các nghiệp vụ không thuộc về một tính năng cụ thể)
│   ├── /{ServiceName}
└── /Dtos (Chứa các Data Transfer Objects (DTOs), được sử dụng để truyền tải dữ liệu giữa các tầng của ứng dụng)
    ├── {FeatureName}Dto.cs
```

### 3. Infrastructure Layer
- Chứa các chi tiết về cơ sở dữ liệu, tích hợp với các dịch vụ bên ngoài.
- Sử dụng Repository Pattern để quản lý dữ liệu.
- Đăng ký các dịch vụ vào DI container.
   
**Thư mục:**
```
/Infrastructure
├── /Data
│   ├── /Contexts (Quản lý các kết nối với CSDL)
│   │   ├── ApplicationDbContext.cs (Quản lý kết nối và truy vấn với cơ sở dữ liệu cho các thực thể trong ứng dụng)
│   │   └── IdentityDbContext.cs (Dành riêng cho việc quản lý dữ liệu Identity (người dùng, vai trò), giúp tích hợp dễ dàng với ASP.NET Core Identity)
│   ├── /Configurations (Chứa các cấu hình cho các thực thể)
│   │   ├── EntityConfiguration.cs (Các cấu hình cho thực thể, sử dụng Fluent API để định nghĩa cách các thực thể được ánh xạ tới cơ sở dữ liệu)
│   │   └── IdentityConfiguration.cs (Các cấu hình dành riêng cho các thực thể liên quan đến Identity, như cấu hình bảng Users, Roles)
│   ├── /Repositories
│   │   ├── GenericRepository.cs (Triển khai repository chung cho các thao tác CRUD với cơ sở dữ liệu. Cung cấp các phương thức cơ bản như Add, Update, Delete, GetAll, GetById cho các thực thể)
│   │   ├── UserRepository.cs (Repository cụ thể dành cho thực thể User, chứa các phương thức đặc biệt liên quan đến người dùng, chẳng hạn như tìm kiếm người dùng theo email)
│   ├── /UnitOfWork
│   │   ├── UnitOfWork.cs (Quản lý các repository và phiên giao dịch (transaction) với cơ sở dữ liệu)
│   └── /Migrations
├── /Identity
│   ├── /Services
│   │   ├── IdentityService.cs (Dịch vụ quản lý các nghiệp vụ liên quan đến người dùng và vai trò, như tạo mới người dùng, xác thực, hoặc quản lý quyền hạn)
│   ├── /Models
│   │   ├── ApplicationUser.cs (Lớp mô hình đại diện cho người dùng trong hệ thống, kế thừa từ lớp IdentityUser của ASP.NET Core Identity)
│   │   └── IdentityRole.cs (Lớp mô hình đại diện cho vai trò trong hệ thống, kế thừa từ lớp IdentityRole của ASP.NET Core Identity)
│   ├── /Claims
│   │   ├── ClaimsPrincipalExtensions.cs (Chứa các phương thức mở rộng để truy cập dễ dàng hơn vào các claims của người dùng, như lấy user ID hoặc roles từ ClaimsPrincipal)
│   └── /Jwt
│       ├── JwtTokenGenerator.cs (Lớp chịu trách nhiệm tạo và quản lý JWT (JSON Web Tokens) cho việc xác thực người dùng)
│       └── JwtSettings.cs (Chứa các cấu hình liên quan đến JWT, như secret key, thời hạn token)
├── /Security
│   ├── /Encryption
│   │   ├── EncryptionService.cs (Dịch vụ quản lý các thao tác mã hóa và giải mã dữ liệu, giúp bảo vệ thông tin nhạy cảm trong ứng dụng)
│   │   └── EncryptionSettings.cs (Chứa các cấu hình liên quan đến mã hóa, như các khóa mã hóa và thuật toán sử dụng)
│   ├── /Authorization
│   │   ├── Policies.cs (Định nghĩa các chính sách phân quyền trong ứng dụng, như yêu cầu quyền admin để truy cập một tính năng cụ thể)
│   │   └── AuthorizationService.cs (Dịch vụ quản lý việc phân quyền và kiểm tra quyền hạn của người dùng, sử dụng các chính sách đã định nghĩa)
├── /Services
│   ├── /EmailService.cs (Dịch vụ gửi email, quản lý việc gửi email từ ứng dụng, ví dụ như email xác nhận, thông báo, hoặc khôi phục mật khẩu)
│   ├── /PushNotificationService.cs (Dịch vụ gửi thông báo đẩy (push notifications), quản lý việc gửi thông báo đến các thiết bị của người dùng)
├── /Extensions
│   ├── /ServiceCollectionExtensions.cs (Chứa các phương thức mở rộng để đăng ký các dịch vụ vào Dependency Injection container)
│   └── /MiddlewareExtensions.cs (Chứa các phương thức mở rộng để thêm các middleware vào pipeline xử lý HTTP của ứng dụng, giúp cấu hình các xử lý trung gian như logging, authentication)
└── /External
    ├── /ApiClients
    │   ├── {Name}ApiClient.cs (Các lớp client cho việc gọi các API bên ngoài, quản lý việc giao tiếp với các dịch vụ ngoài ứng dụng, như dịch vụ thanh toán hoặc dịch vụ thông báo)
    └── /ThirdPartyIntegrations
        └── {ServiceName}Integration.cs (Chứa các lớp tích hợp với các dịch vụ bên thứ ba, quản lý việc tích hợp và giao tiếp với các hệ thống hoặc dịch vụ bên ngoài khác, ví dụ như tích hợp với một hệ thống quản lý danh tính của bên thứ ba)
```

### 4. Presentation Layer (WebApi)
- Chứa các thành phần liên quan đến API
  
**Thư mục:**
```
/Presentation
├── /Controllers (Chứa các lớp Controller của ứng dụng, mỗi controller sẽ đại diện cho một tập hợp các hành động liên quan đến một tính năng cụ thể)
│   ├── {FeatureName}Controller.cs
├── /Filters (Chứa các bộ lọc (filters) để áp dụng các logic cắt ngang cho các hành động của controller)
│   ├── ValidationFilter.cs
│   ├── ExceptionFilter.cs
│   ├── {FilterName}Filter.cs
├── /Middlewares (Chứa các lớp middleware để xử lý các yêu cầu HTTP trước khi chúng đến controller hoặc sau khi chúng đã được xử lý)
│   ├── CustomExceptionMiddleware.cs
│   ├── RequestLoggingMiddleware.cs
├── /Models (Chứa các lớp mô hình (models) được sử dụng để nhận và gửi dữ liệu qua API)
│   ├── {FeatureName}RequestModel.cs
│   ├── {FeatureName}ResponseModel.cs
├── /Dtos (Chứa các Data Transfer Objects (DTOs) được sử dụng để trao đổi dữ liệu giữa các tầng khác nhau của ứng dụng)
│   └── {FeatureName}Dto.cs
├── /Configurations (Chứa các cấu hình liên quan đến API)
│   ├── SwaggerConfiguration.cs (Cấu hình Swagger cho việc tạo tài liệu API tự động)
│   ├── ApiVersioningConfiguration.cs (Cấu hình phiên bản API để hỗ trợ nhiều phiên bản API trong cùng một ứng dụng)
└── /Extensions (Chứa các phương thức mở rộng)
    ├── ServiceCollectionExtensions.cs (Để thêm các dịch vụ vào IServiceCollection, giúp cấu hình Dependency Injection cho các dịch vụ như MediatR, Unit of Work)
    └── ApplicationBuilderExtensions.cs (Để thêm các middleware vào pipeline HTTP, ví dụ như thêm CustomExceptionMiddleware hoặc Swagger)
```

### 5. Test Projects
Chứa các dự án kiểm thử cho từng layer, bao gồm:
- **Domain.Tests:** Kiểm thử cho Domain Layer.
- **Application.Tests:** Kiểm thử cho Application Layer.
- **Infrastructure.Tests:** Kiểm thử cho Infrastructure Layer.
- **WebApi.Tests:** Kiểm thử cho WebApi Layer.

```
tests  
├── Domain.Tests  
│   └── UnitTests  
├── Application.Tests  
│   ├── UnitTests  
│   └── FunctionalTests  
├── Infrastructure.Tests  
│   └── IntegrationTests  
└── WebApi.Tests  
│   └── IntegrationTests  
```

## Thiết lập và chạy dự án

### 1. Cài đặt các công cụ cần thiết
Đảm bảo bạn đã cài đặt các công cụ sau:
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Entity Framework Core CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

### 2. Tạo và áp dụng migration
Tạo database và áp dụng các migration:
```bash
# Phụ trách phần migrations
dotnet ef migrations add <Name> --project src/Epay.eGateKeeper.Infrastructure --startup-project src/Epay.eGateKeeper.WebApi -o Demo/Migrations -- --environment Test

# Developer
dotnet ef migrations add <Name> --project src/Epay.eGateKeeper.Infrastructure --startup-project src/Epay.eGateKeeper.WebApi -- --environment Local
```
Cập nhật database:
```bash
dotnet ef database update --project src/Epay.eGateKeeper.Infrastructure --startup-project src/Epay.eGateKeeper.WebApi -- --environment Local
```
*Lưu ý: Không đẩy Migration của DEV lên git, chỉ người quản lý dự án tạo migration và update migration vào git*

### 3. Chạy ứng dụng
Chạy ứng dụng từ thư mục `WebApi`:
```bash
dotnet run --project src/Epay.eGateKeeper.WebApi
```

### 4. Chạy các kiểm thử
Chạy tất cả các bài kiểm thử:
```bash
dotnet test
```

## Ghi chú
- `src/Domain`: Chứa các thành phần cốt lõi của ứng dụng.
- `src/Application`: Chứa các logic nghiệp vụ.
- `src/Infrastructure`: Chứa các triển khai chi tiết và tích hợp hạ tầng.
- `src/WebApi`: Chứa các endpoint API và logic liên quan.
- `tests`: Chứa các dự án kiểm thử cho từng layer của ứng dụng.

## Conventional Commits

### Cấu trúc chung của một thông điệp commit theo chuẩn Conventional Commits:
```
<type>(<scope>): <subject>

<body>

<footer>
```
#### Các loại (types) thông dụng:
- feat: Thêm một tính năng mới
- fix: Sửa một lỗi
- docs: Thay đổi tài liệu
- style: Thay đổi về format, không ảnh hưởng tới mã code (spaces, formatting, missing semi-colons, etc.)
- refactor: Thay đổi mã nguồn mà không sửa lỗi hoặc thêm tính năng
- perf: Cải thiện hiệu suất
- test: Thêm hoặc sửa test
- build: Thay đổi hệ thống build hoặc các phụ thuộc bên ngoài (các thư viện, công cụ)
- ci: Thay đổi file cấu hình hoặc script liên quan tới CI (Continuous Integration)
- chore: Thay đổi nhỏ không ảnh hưởng tới mã nguồn (cập nhật dependencies, etc.)
- revert: Quay lại một commit trước đó

#### Ví dụ cụ thể:

1. Thêm một tính năng mới:
```
feat(auth): add login functionality

Implement login functionality with JWT authentication.

Closes #123
```

2. Sửa một lỗi:
```
fix(api): fix user registration error

Fixes a bug where the user registration endpoint would return a 500 error when the email was already in use.

Closes #456
```

3. Thay đổi tài liệu:
```
docs(readme): update installation instructions

Updated the installation instructions to include information about environment variables.
```

4. Cải thiện hiệu suất:
```
perf(database): optimize query performance

Optimized the user query by adding an index to the email column.
```

5. Thêm hoặc sửa test:
```
test(api): add tests for user registration

Added unit tests for the user registration endpoint.
```