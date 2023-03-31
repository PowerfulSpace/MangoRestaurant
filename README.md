# MangoRestaurant

- Микросервис каталога Товаров;

-Микросервис Identity Server;

-Микросервис для Купонов;

-Микросервис Корзины Покупок;

-Микросервис Заказов;

-Микросервис Почтовой Рассылки;

-Микросервис для on-line Платежей;

-MVC Web Application.

            API для товаров и CRUD операции

1. Создание репозитория
2. Создание проекта
3. Разделение на FrontEnd и Services ( Создаём директории)
4. В директории FrontEnd создаём проект: Веб приложение ASP.NET Core (MVC) 
    PS.MangoRestaurant.Web
5. В директории Services создаём проект: Веб-API ASP.NET Core
    PS.MangoRestaurant.Services.ProductAPI



6. Установка Nuget пакетов для PS.MangoRestaurant.Services.ProductAPI
	AutoMapper
	AutoMapper.Extensions.Microsoft.DependencyInjection
	Microsoft.AspNetCore.Authentication.JwtBearer
	Microsoft.EntityFrameworkCore.SqlServer
	Microsoft.EntityFrameworkCore.Tools
	Swashbuckle.AspNetCore
	Swashbuckle.AspNetCore.Annotations
	Swashbuckle.AspNetCore.SwaggerUI
7. Устанавливает директории для проекта PS.MangoRestaurant.Services.ProductAPI
    Controllers
    DbContext
    Models
    Repository
8. Добавили модель в PS.MangoRestaurant.Services.ProductAPI.Models
    Product
8. Добавили Dto модели в PS.MangoRestaurant.Services.ProductAPI.Models
    ProductDto - описывает нашу модель Product
    ResponseDto - для получение ответа
9. Настройка контекста бд для ProductAPI
    -Создание класса ApplicationDbContext для работы с бд
    -Добавил в конфигурацию appsettings строку подключения DefaultConnection
    -Подкоючил в Program работу в бд
10. Добавление миграции в проект PS.MangoRestaurant.Services.ProductAPI
11. Создаём в PS.MangoRestaurant.Services.ProductAPI конфигурацию для маппинга
    MappingConfig
12. Подключаем мапинг продукта в Program   
13. Создание репозитория для выполнения всех CRUD операций в PS.MangoRestaurant.Services.ProductAPI в дериктории Repository, и реализуем
    ProductRepository
    IProductRepository
14. Создать API Controller для работы с API в PS.MangoRestaurant.Services.ProductAPI.Models и реализовать там все методы CRUD операций
    ProductAPIController
15. Добавление Seed для наших продуктов в бд, По желанию. Выполнить миграцию



16. Подключаем API сервис в WEB приложении PS.MangoRestaurant.Web
    в appsettings.json создаём urls сервисы
17. Создаём класс для удобства в работе с API который будет статическим и хранить константы
    SD
18. Добавили Nuget пакет в  PS.MangoRestaurant.Web
    Newtonsoft.Json
    Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
19. Создание своих собственной модели DTO для работы с product в PS.MangoRestaurant.Web
    ProductDto
    ResponseDto
20. Создание дериктории Services в PS.MangoRestaurant.Web для работы с репозиториями подключенных сервисов
21. Создание интерфейса сервиса со всеми CRUD операциями в PS.MangoRestaurant.Web в директории Services.IServices
    IProductService
22. Создание модели запроссов который будет использоваться для отправки на разные сервисы API
    APIRequest
23. Создание интерфейса базового сервиса и его реализация
    IBaseService
    BaseService
24. Реализация IProductService
    ProductService
25. Настроить доступ к сервисам, через внедрение зависимости в Program PS.MangoRestaurant.Web
    builder.Services.AddHttpClient<IProductService, ProductService>();
    builder.Services.AddScoped<IProductService, ProductService>();
26. Настроить базовый путь для ProductAPIBase
    SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
27. Подключение в _Layout Program PS.MangoRestaurant.Web работу с иконками
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.4/css/all.css" integrity="sha384-DyZ88mC6Up2uqS4h/KRgHuoeGwBcD4Ng9SiP4dIRy0EXTlnuz47vAwmeGwVChigm" crossorigin="anonymous" />
29. Изменение стиля страницы, по желанию
    Добавление логотипа
    Изменение колонтиутлов на тёмный
30. Добавление контроллера в PS.MangoRestaurant.Web и создание методов на CRUD операции
    ProductController
        ProductIndex
        ProductCreate
        ProductEdit
        ProductDelete
31. Добавление представления в PS.MangoRestaurant.Web
    ProductIndex
    ProductCreate
    ProductEdit
    ProductDelete





                        Identity Server
32. Перейдём на сайт: https://duendesoftware.com/ и находим команду
    https://docs.duendesoftware.com/identityserver/v6/quickstarts/0_overview/
33. Идём в консоль, и выполняем команды. Закгрузит всё необходимоею, добавит папку с ресурсами
    В повершеле меняем путь на путь к нашему проекту, через команду cd ПУТЬ
    ПУТЬ dotnet new --install Duende.IdentityServer.Templates
    ПУТЬ dotnet new isui
34. Создадим новый сервис для идентификации PS.MangoRestaurant.Services.Identity
35. Установим Nuget пакеты
    Duende.IdentityServer.AspNetIdentity
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.AspNetCore.Identity.EntityFrameworkCore
    Microsoft.AspNetCore.Identity.UI
    Microsoft.EntityFrameworkCore.Tools
36. Создаём дерикторию DbContexts для работы с бд в PS.MangoRestaurant.Services.Identity
    ApplicationDbContext
37. Добавим модель в PS.MangoRestaurant.Services.Identity
    ApplicationUser
38. Создаём класс для удобства в работе с API который будет статическим и хранить константы в PS.MangoRestaurant.Services.Identity и дабавляем в него константы полей ролей, коллекцию ресурсов,
коллекциб областей видимости, клиенты
    SD - статические детали
39. Добавляем строку подключения к бд в проект PS.MangoRestaurant.Services.Identity
40. Настроим работу в Program в проекте PS.MangoRestaurant.Services.Identity
    -Подключение к бд
    -система идентификации
    -запуск identity servera
    -включить в конвеер identityServer
41. Добавляем директорию Initializer для создания данных при отсутсвии данных и реализовываем
    IDbInitializer
    DbInitializer
42. Настраиваем в Program подключения и запуска Inizialize
43. Настройка методов контроллера атрибутами для авторизованных пользователей в PS.MangoRestaurant.Services.ProductAPI
44. Настрока сервиса аутентификации и политику авторизации в Program в PS.MangoRestaurant.Services.ProductAPI
45. Настройка swager для обеспечения безопасности в  PS.MangoRestaurant.Services.ProductAPI
46. Настраиваем вызов нашего Identity Server в PS.MangoRestaurant.Web, в appsettongs по ключу API на устанавливаем ключ ссылки на аутентификацию нашего сервиса
47. Установим Nuget пакеты в Program в PS.MangoRestaurant.Web
    Microsoft.AspNetCore.Authentication
    Microsoft.AspNetCore.Authentication.OpenIdConnect
    System.IdentityModel.Tokens.Jwt
48. Настройка аутентификации с помощи протокола oidc в Program в PS.MangoRestaurant.Web
49. Добавляем ссылку на главной странице, для аутентифицакии пользователей. В PS.MangoRestaurant.Web в папке Shared добавляем новое частичное представление и подключим в Layout
    _LoginPartial
50. Изменяем Index для корректной работы с identity Serverom в PS.MangoRestaurant.Services.Identity в контроллере Account ( Или если используеться Pages. то в Pages/Account/Login/index.cshtml)
    Убираем тестовое внедрение TestUserStore. Настраиваем под себя
    Настраиваем входи Login     Post
    Настраиваем выход Logoutn   Post
51. Регистрация пользователя в PS.MangoRestaurant.Services.Identity
    Добавим RegisterViewModel
    Изменил в контроллере Login Post Для правильного принятия пользователя UserLoginSuccessEvent
52. Настраиваем передачу требований в токоне. PS.MangoRestaurant.Services.Identity создаёмновую директорию Services и добавляем класс ProfileService который будет наследоваться от IProfileService и реализуем метоыды. Это нужно для доступа ко всем данным о пользователи, что бы настроить под себя. И добавим в Program в контейнер зависимостей наш сервис
    GetProfileDataAsync
    IsActiveAsync
53. В PS.MangoRestaurant.Web в контроллере Home методе Login проверяем какой приходит токен
54. в интерфейсе IProductService в наши методы, добавляем параметр string token. В приложении PS.MangoRestaurant.Web
55. в ProductService приложения PS.MangoRestaurant.Web изменяем тип входных параметров добавляя string token и устанавливая этот параметр в свойство AccessToken, и так же изменяем контроллер ProductController
Добавляя в методы получения токена и передачу в методы




                    Настройка страницы Home и Detail
56. Вывод всех товаров на глайной странице в PS.MangoRestaurant.Web
57. Создание представления для товаров
58. Создание метода Details а так же его представления
59. Изменил модель ProductDto в PS.MangoRestaurant.Web
    -добавим новое свойство Count
    -Установим конструктор который будет устанавливать по умолчанию значение count в 1



                  Корзина покупок
60. Создание проекта PS.MangoRestaurant.Services.ShoppingCartAPI
61. Создание строки подключения к бд в appsetings
62. Добавление пакетов NUGEt
    - AutoMapper
    - AutoMapper.Extensions.Microsoft.DependencyInjection
    - Microsoft.AspNetCore.Authentication.JwtBearer
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
    - Newtonsoft.Json
    - Swashbuckle.AspNetCore.Annotations
    - Swashbuckle.AspNetCore.SwaggerUI
63. Настройка класса Program
64. Создание класса ApplicationDbContext в папке DbContext
65. Создаём класс MappingConfig
66. Создание модели
    - Product
    - CartHeader
    - CartDetails
    - Cart
67. Создание моделей DTO
    - ResponseDto
    - ProductDto
    - CartHeaderDto
    - CartDetailsDto
    - CartDto
68. Создание миграции
69. Настройка MappingConfig