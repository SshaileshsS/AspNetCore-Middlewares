
// First Git Change.

//Creates an Instance of WebApplicationBuilder Class with some pre-configured defaults also sets up Kestrel.
var builder = WebApplication.CreateBuilder(args);

// Sets up a Web Application.
var app = builder.Build();

/* Start - Configure Middlewares Here....*/

DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
defaultFilesOptions.DefaultFileNames.Clear();
defaultFilesOptions.DefaultFileNames.Add("home.html");
//
app.UseDefaultFiles(defaultFilesOptions);

app.UseStaticFiles();

//app.UseWelcomePage();

// Maps a GET Request.
//app.MapGet("/", PrintMiddleware.writeAsync);

// Use Middleware Contains Two Parameters HttpContext, Next to invoke the Next Middleware.
app.Use(async (context, next) => {
    await context.Response.WriteAsync("First Middleware.");

    await next();
});

app.Use(async (context, nextMiddleware) => {
    await context.Response.WriteAsync(Environment.NewLine + "Second Middleware.");

    await nextMiddleware();
});

// Starts the Server.
app.Run(async (context) =>
{
    await context.Response.WriteAsync(Environment.NewLine + "Run Method Called");
});

// the following Run() will never be executed
app.Run();      // Run() is Terminal Middleware Should be the End Point of Middleware Pipeline.

/* End - Configure Middlewares Here....*/

