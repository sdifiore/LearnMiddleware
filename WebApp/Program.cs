var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware #1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware #1: Before calling next\n");

    await next(context);

    await context.Response.WriteAsync("Middleware #1: After calling next\n");
});

// Middleware #2
app.Run(async (context) =>
//app.Run will always create a terminal middleware
{
    await context.Response.WriteAsync("Middleware #2: Before calling next\n");
});

// Middleware #3
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware #3: Before calling next\n");

    await next(context);

    await context.Response.WriteAsync("Middleware #3: After calling next\n");
});

app.Run();