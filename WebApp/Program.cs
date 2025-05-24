var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middleware #1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware #1: Before calling next\n");
    // First call based purely context

    await next(context);

    await context.Response.WriteAsync("Middleware #1: After calling next\n");
    // Context most likely changed by previous instructions
});

// Middleware #2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware #2: Before calling next\n");

    //await next(context);
    // Calling next is optional, if not called, the request will not proceed to the next middleware
    // Thus this is a terminal midleware

    await context.Response.WriteAsync("Middleware #2: After calling next\n");
});

// Middleware #3
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware #3: Before calling next\n");

    await next(context);
    //remving HttpContext and RequestDelegate make required using next(context)

    await context.Response.WriteAsync("Middleware #3: After calling next\n");
});
app.Run();