# 

## Dependencies 


## class declaration

- EF 

```csharp

public class AppDbContext : IdentityDbContext<IdentityUser>
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

```

- Build Pipeline

```csharp

builder.Services.AddAuthentication()
	.AddBearerToken(IdentityConstants.BearerScheme)
	.AddIdentityCookies();

builder.Services.AddAuthorizationBuilder();


builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddIdentityCore<IdentityUser>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddApiEndpoints();

```


- Application Pipeline

```

app.MapIdentityApi<IdentityUser>().WithOpenApi();

```