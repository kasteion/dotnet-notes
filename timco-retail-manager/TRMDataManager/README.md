# TRMDataManager

Nuevo proyecto ASP.NET Framework 4.7.2 

**ASP.NET 4.7.2 Templates**

- Web API -- MVC & Web API
- Change Authentication -- Single User Authentication

## Upgrade NuGet Packages

Right click on references --> Manage NuGet Packages

Go to updates --> Select all packages --> Unselect bootstrap & Entity Framework --> Update

In `App_Start/IdentityConfig.cs` we found the marriage between mvc and api it is configured if we need it

```
url: "{controller}/{action}/{id}",
```

In `App_Start/WebApiConfig.cs` we found the routing for the api

```
routeTemplate: "api/{controller}/{id}",
```

In `App_Start/IdentityConfig.cs` we found the configuration for users validation and pasword validation.

```
manager.UserValidator = new UserValidator<ApplicationUser>(manager)
{
    // False because it can be an email
    AllowOnlyAlphanumericUserNames = false,
    // True because we dont want users having the same user
    RequireUniqueEmail = true
};

manager.PasswordValidator = new PasswordValidator
{
    RequiredLength = 6,
    RequireNonLetterOrDigit = true,
    RequireDigit = true,
    RequireLowercase = true,
    RequireUppercase = true,
};
```

In `Controllers/ValuesController.cs` we found

```
[Authorize]
```

That means we have to login to use this part of the api so first we have to create a user with a POST request to /api/account/register using Postman.

Then we need to get a token sending a GET request to /token (Notice it is not /api there just /token), ther format of the body on this request has to be x-www-form-urlencode:

- First Key: grant_type -- Value: password
- Second Key: username -- Value: email@example.com 
- Third Key: password -- Value: P@ssw0rd!

It gives us:

```json
{
    "acces_token": "...",
    "token_type": "bearer",
    "expires_in": ...,
    "username": "email@example.com",
    ".issued": "...",
    ".expires": "..."
}
```

Now we can make a GET request to /api/values with the value of acces_token on Authorization or we could create a Header:

- Key: Authorization
- Value: Bearer + " " + token

In `Controllers/ValuesController.cs`

```
// ...

using Microsoft.AspNet.Identity;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            // To get the username... just as an example for future use when we want to authorize might come handy
            string userId = RequestContext.Princpal.Identity.GetUserId();
            return new string[] { "value1", "value2" };
        }
    }
}
```

We could check in the SQL Server Object Explorer the database for the project if the UserId.

We could change the type of the Get method.

```
public IHttpActionResult Get()
{
    return Ok(new string[] { "value1", "value2", userId })
}
```

But it requires us to do more documentation because the datatype inside is not clear enough.

Notice that the `Controllers/HomeController` is an MVC Controller because it inherits from Controller class. 
On the other side `Controller/ValuesController` is an API Controller beacuse it inherits from ApiController class.