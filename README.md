# TechMarket
```
/src
* ApplicationCore
* Infrastructure
* Web

/tests
* UnitTests
```

### Packages
```
/ApplicationCore
Install-Package Ardalis.Specification


/Infrastructure
Install-Package Microsoft.EntityFrameworkCore -v 5.0.13
Install-Package Ardalis.Specification.EntityFrameworkCore
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.13

/Web
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -v 5.0.10
Install-Package Microsoft.EntityFrameworkCore.Tools -v 5.0.13
```

### Migrations
```
/Infrastructure
Add-Migration InitialCreate -c MarketContext -s Web -o Data/Migrations
Update-Database -Context MarketContext -s Web
Add-Migration InitialIdentity -c AppIdentityDbContext -s Web -o Identity/Migrations
Update-Database -Context AppIdentityDbContext -s Web
```

### Resources
* https://github.com/dotnet-architecture/eShopOnWeb
* https://github.com/yigith/WatchShop
* https://www.postgresql.org
* https://www.npgsql.org/doc/types/basic.html
* https://www.npgsql.org/efcore/